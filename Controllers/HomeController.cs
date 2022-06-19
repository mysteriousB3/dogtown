using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dog7.Models;
using Microsoft.AspNetCore.Authorization;
using dog7.Data;
using Microsoft.EntityFrameworkCore;

namespace dog7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dog7DbContext _context;

        public HomeController(ILogger<HomeController> logger, dog7DbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(){
            var dogList = dog();
            ViewBag.dogList= dogList;

            var suggestionTable = suggestion();
            ViewBag.suggestionTable = suggestionTable;

            var cardList = card();
            ViewBag.card = cardList;
            

            ViewBag.numberOfPost = await _context.SellingPost.CountAsync();
            return View();
        }
        public IActionResult dog(){
            var result = _context.Breed.Select(x=>x).ToList();
            foreach(var i in result){
                i.breedPic= "dogPic/"+i.breedId+"breedPic.png";                
            }//eloop
            var result2 = result.Select(x=> new{
                x.breedId,
                x.breedNameEng,
                x.breedNameThai,
                x.breedPic,
                x.breedDescription,
                x.total
            }).ToList();
            return Ok(result2);
        }//ef

        public IActionResult suggestion(){
            var  result = _context.SellingPost
            .Include(x=>x.seller)
            .OrderByDescending(x=>x.sellingPostPostingDateTime)
            .OrderByDescending(x=>x.postLike)
            .ToList();
            var result2 = result.Take(3);            
            foreach(var i in result2){
                if(System.IO.File.Exists("sellingPostPic/"+i.sellingPostId+"sellingPostPic1.png")){
                    i.sellingPostPic1="sellingPostPic/"+i.sellingPostId+"sellingPostPic1.png";
                }//econ
                if(System.IO.File.Exists("sellingPostPic/"+i.sellingPostId+"sellingPostPic2.png")){
                    i.sellingPostPic2="sellingPostPic/"+i.sellingPostId+"sellingPostPic2.png";
                }//econ
                if(System.IO.File.Exists("sellingPostPic/"+i.sellingPostId+"sellingPostPic3.png")){
                    i.sellingPostPic3="sellingPostPic/"+i.sellingPostId+"sellingPostPic3.png";
                }//econ
                if(System.IO.File.Exists("sellingPostPic/"+i.sellingPostId+"sellingPostPic4.png")){
                    i.sellingPostPic4="sellingPostPic/"+i.sellingPostId+"sellingPostPic4.png";
                }//econ
                if(System.IO.File.Exists("sellingPostPic/"+i.sellingPostId+"sellingPostPic5.png")){
                    i.sellingPostPic5="sellingPostPic/"+i.sellingPostId+"sellingPostPic5.png";
                }//econ                     

            }//eloop
            foreach(var i in result2){
                if(i.sellingPostPic1==""){
                    i.sellingPostPic1="sellingPostPic/default.png";
                }
                if(i.sellingPostPic2==""){
                    i.sellingPostPic2="sellingPostPic/default.png";
                }
                if(i.sellingPostPic3==""){
                    i.sellingPostPic3="sellingPostPic/default.png";
                }
                if(i.sellingPostPic4==""){
                    i.sellingPostPic4="sellingPostPic/default.png";
                }
                if(i.sellingPostPic5==""){
                    i.sellingPostPic5="sellingPostPic/default.png";
                }
            }//eloop
            var result3 = result2.Select(x=>new{
                x.sellerId,
                x.sellingPostId,
                x.sellingPostName,
                x.seller.farmName,
                x.price,
                x.sellingPostPic1,
                x.sellingPostPic2,
                x.sellingPostPic3,
                x.sellingPostPic4,
                x.sellingPostPic5,
                x.sellingPostPostingDateTime
            })
            .ToList();
            return Ok(result3);           
        }//ef

        public IActionResult card(){
            var result = _context.SellingPost
            .Include(x=>x.seller)
            .OrderByDescending(x=>x.sellingPostPostingDateTime)
            .ToList();
            var result2 = result.Take(8);
            foreach(var i in result2){
                if(System.IO.File.Exists("sellingPostPic/"+i.sellingPostId+"sellingPostPic1.png")){
                    i.sellingPostPic1="sellingPostPic/"+i.sellingPostId+"sellingPostPic1.png";
                }//econ
                else{
                    i.sellingPostPic1="sellingPostPic/default.png";
                }//econ
            }//eloop

            var result3 = result2.Select(x=>new {
                x.sellerId,
                x.sellingPostId,
                x.sellingPostName,
                x.seller.farmName,
                x.price,
                x.sellingPostPic1,
                x.view,
                x.postLike,
                x.sellingPostPostingDateTime,
                x.pedegree,
                x.seller.sellerIdCard,
                x.seller.sellerFarmRegisterPic
            }).ToList();
            
                        
            return Ok(result3);
        }//ef

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
