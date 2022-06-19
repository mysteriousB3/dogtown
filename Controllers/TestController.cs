using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using dog7.Services;
using Microsoft.AspNetCore.Identity;
using dog7.Data;
using dog7.Models;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace dog7.Controllers{
    public class TestController:Controller{
        private IMyService _myService;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private dog7DbContext _context;
        private RoleManager<AppRole> _roleManager;

        public TestController(IMyService myService,SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,
                                    dog7DbContext db, RoleManager<AppRole> roleManager){
            _myService = myService;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = db;
            _roleManager = roleManager;

        }
        // [HttpGet]
        // public async Task<IActionResult> startTask1()
        // {
        //     var jobId = BackgroundJob.Enqueue(
        //         () => Console.WriteLine("do once now completd"));
        //     return Ok(new { jobId, msg = $" job id: {jobId} is success" });
        // }//ef
        // [HttpGet]
        // public async Task<IActionResult> startTask2()
        // {
        //     var jobId = BackgroundJob.Schedule(
        //         () => Console.WriteLine("do once after 10 seconds compoleted !"),
        //         TimeSpan.FromSeconds(10));

        //     return Ok(new { jobId, msg = $" job id: {jobId} is success" });
        // }//ef

        // [HttpGet]
        // public async Task<IActionResult> startTask3()
        // {

        //     RecurringJob.AddOrUpdate(
        //         "do recurring job",
        //         () => Console.WriteLine("execute every 10 seconds !"),
        //         "*/10 * * * * *");

        //     return Ok(new { msg = "recurring job was started." });
        // }//ef

        [HttpGet]
        public IActionResult startKillExpiredSellingPost()
        {

            var manager = new RecurringJobManager();
            manager.AddOrUpdate(
                "do recurring job",
                  () =>  killExpiredSellingPost(),
                "*/10 * * * * *");  

            return Ok(new { msg = "recurring job was started." });
        }//ef
        public async Task<IActionResult> killExpiredSellingPost(){
            var toDay= DateTime.Now;
            var sellingPost = await _context.SellingPost.Where(x=>x.sellingPostPostExpiredDate < toDay)
            .Include(x=>x.gender)
            .Include(x=>x.breed)
            .Include(x=>x.seller)
            .ToListAsync();
            if(sellingPost == null){
                return Ok("null");
            }
            
            //delete
            _context.RemoveRange(sellingPost);
            await _context.SaveChangesAsync();

            //increse number post back to seller
            foreach(var i in sellingPost){
                var sellerPackage = await _context.SellerPackage.FirstOrDefaultAsync(x=>x.sellerId == i.sellerId && x.packageStatus==1);
                sellerPackage.totalPostAvailable = sellerPackage.totalPostAvailable+1;
                _context.Update(sellerPackage);
                await _context.SaveChangesAsync();
            }//eloop

            //decrese the number of breed
            foreach(var i in sellingPost){
                var breed = await _context.Breed.FirstOrDefaultAsync(x=>x.breedId == i.breedId);
                breed.total =breed.total-1;
                _context.Update(breed);
                await _context.SaveChangesAsync();

            }//eloop

            var expiredSellingPost = new List<ExpiredSellingPost>();

            foreach (var i in sellingPost){
                int sellingPostId = i.sellingPostId;
                string gender = i.gender.genderName;
                string breed = i.breed.breedNameThai;
                int sellerId = i.sellerId;
                string farmName = i.seller.farmName;
                int price = i.price;
                string sellingPostName = i.sellingPostName;
                string sellingPostDescription = i.sellingPostDescription;
                DateTime dateOfBirth = i.dateOfBirth;
                string pedegree = "";
                if(i.pedegree == 1){
                    pedegree ="ออกได้";
                }//econ
                else if(i.pedegree != 1){
                    pedegree = "ออกให้ไม่ได้";
                }
                DateTime sellingPostPostingDateTime = i.sellingPostPostingDateTime;
                DateTime sellingPostPostExpiredDate = i.sellingPostPostExpiredDate;
                int postLike = i.postLike;
                int view = i.view;
                DateTime sellingPostPicUpdateDateTime = i.sellingPostPicUpdateDateTime;
                expiredSellingPost.Add(new ExpiredSellingPost(sellingPostId,gender,breed,sellerId,farmName,price,sellingPostName,sellingPostDescription,dateOfBirth,pedegree,sellingPostPostingDateTime,sellingPostPostExpiredDate,postLike,view,sellingPostPicUpdateDateTime));

                
            }//eloop
            await _context.AddRangeAsync(expiredSellingPost);
            await _context.SaveChangesAsync();
            return Json(expiredSellingPost);
            
             
            
        }//ef
        

        public IActionResult startKillExpiredSellerPackage()
        {

            var manager = new RecurringJobManager();
            manager.AddOrUpdate(
                "do recurring job",
                  () =>  killExpiredSellerPackage(),
                "*/10 * * * * *");  

            return Ok(new { msg = "recurring job was started." });
        }//ef

        public async Task<IActionResult> killExpiredSellerPackage(){
            var toDay = DateTime.Now;
            //get expired seller package
            var sellerPackage = await _context.SellerPackage.Where(x=>x.packageEndingDateTime < toDay && x.packageDetailId != 1 && x.packageStatus ==1).ToListAsync();

            //after done with all of its selling post
            //go to change the package to back to the starter pack with 5 available selling posts
            foreach(var i in sellerPackage){
                i.packageStatus = -1;

                //get back the starter package
                var oldSellerPackage = await _context.SellerPackage.FirstOrDefaultAsync(x=>x.sellerId == i.sellerId && x.packageDetailId ==1);
                oldSellerPackage.packageStatus = 1;
                oldSellerPackage.totalPostAvailable = 5;
                _context.Update(oldSellerPackage);
                await _context.SaveChangesAsync();

                _context.Update(i);
                await _context.SaveChangesAsync();
            }//eloop

            var expiredSellingPost = new List<ExpiredSellingPost>();
            //go to migrate all selling post
            foreach (var i in sellerPackage){
                //get all of selling post of each seller round by round
                var sellingPost = await _context.SellingPost.Where(x=>x.sellerId == i.sellerId).Include(x=>x.gender).Include(x=>x.breed).Include(x=>x.seller).ToListAsync();
                if(sellingPost == null){
                    return Ok("null");
                }//econ

                //delete
                _context.RemoveRange(sellingPost);
                await _context.SaveChangesAsync();

                //decrese the number of breed
                foreach(var j in sellingPost){
                    var breed = await _context.Breed.FirstOrDefaultAsync(x=>x.breedId == j.breedId);
                    breed.total =breed.total-1;
                    _context.Update(breed);
                    await _context.SaveChangesAsync();

                }//eloop
                
                //migrate expired(unused old expired because of expired seller package) to ExpiredSellingPost
                
                foreach (var j in sellingPost){
                    int sellingPostId = j.sellingPostId;
                    string gender = j.gender.genderName;
                    string breed = j.breed.breedNameThai;
                    int sellerId = j.sellerId;
                    string farmName = j.seller.farmName;
                    int price = j.price;
                    string sellingPostName = j.sellingPostName;
                    string sellingPostDescription = j.sellingPostDescription;
                    DateTime dateOfBirth = j.dateOfBirth;
                    string pedegree = "";
                    if(j.pedegree == 1){
                        pedegree ="ออกได้";
                    }//econ
                    else if(j.pedegree != 1){
                        pedegree = "ออกให้ไม่ได้";
                    }
                    DateTime sellingPostPostingDateTime = j.sellingPostPostingDateTime;
                    DateTime sellingPostPostExpiredDate = j.sellingPostPostExpiredDate;
                    int postLike = j.postLike;
                    int view = j.view;
                    DateTime sellingPostPicUpdateDateTime = j.sellingPostPicUpdateDateTime;
                    expiredSellingPost.Add(new ExpiredSellingPost(sellingPostId,gender,breed,sellerId,farmName,price,sellingPostName,sellingPostDescription,dateOfBirth,pedegree,sellingPostPostingDateTime,sellingPostPostExpiredDate,postLike,view,sellingPostPicUpdateDateTime));

                    
                }//eloop
            }//eloop
            await _context.AddRangeAsync(expiredSellingPost);
            await _context.SaveChangesAsync();
            
            

            return Ok(sellerPackage);
        }//ef

        public IActionResult test1(){
            TestDO ob = new TestDO();
            ob.test = 1;
            ob.result ="test result";

            return Ok(ob);
        }//ef
    }//ec

    public class TestDO{
        public int test;
        public string result;
    }//ec

}//en