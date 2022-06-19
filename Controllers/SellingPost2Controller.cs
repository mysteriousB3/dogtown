//Author Anan Osothsilp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using dog7.Data;
using dog7.Models;
using Microsoft.AspNetCore.Identity;

namespace dog7.Controllers
{
    public class SellingPost2Controller : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private dog7DbContext _context;
        private RoleManager<AppRole> _roleManager;

        public SellingPost2Controller(SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,
                                    dog7DbContext db, RoleManager<AppRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = db;
            _roleManager = roleManager;
        }//end function



        // POST: SellingPost/Add
        [HttpPost]
        public async Task<IActionResult> Add(SellingPost sellingPost)
        {
          
          
            //check first whether the current package of seller have available post left for post or not
            var checkAvailable = await _context.SellerPackage.Where(x => x.sellerId == sellingPost.sellerId && x.packageStatus == 1).Include(x=>x.packageDetail).ToListAsync();
            var sellerPackage = checkAvailable[0];
           
            if (sellerPackage.totalPostAvailable == 0)
            {
                return Json(new
                {
                    error = 1,
                    message = "คุณได้โพสต์ประกาศขายเกินกว่าจำนวนโพสต์ที่สามารถโพสต์ได้ในแพ็คเกจของคุณ",
                    exception = "คุณได้โพสต์ประกาศขายเกินกว่าจำนวนโพสต์ที่สามารถโพสต์ได้ในแพ็คเกจของคุณ"
                });
            }//econ
            try
            {

                //=== file for sellingPostPic1 ===
                var sellingPostPic1_data = sellingPost.sellingPostPic1;
                sellingPost.sellingPostPic1 = "";


                //=== file for sellingPostPic2 ===
                var sellingPostPic2_data = sellingPost.sellingPostPic2;
                sellingPost.sellingPostPic2 = "";


                //=== file for sellingPostPic3 ===
                var sellingPostPic3_data = sellingPost.sellingPostPic3;
                sellingPost.sellingPostPic3 = "";


                //=== file for sellingPostPic4 ===
                var sellingPostPic4_data = sellingPost.sellingPostPic4;
                sellingPost.sellingPostPic4 = "";


                //=== file for sellingPostPic5 ===
                var sellingPostPic5_data = sellingPost.sellingPostPic5;
                sellingPost.sellingPostPic5 = "";

                //increase total post
                var seller = await _context.Seller.Where(x => x.sellerId == sellingPost.sellerId).ToListAsync();
                var seller2 = seller[0];
                seller2.totalPost = seller2.totalPost + 1;
                _context.Update(seller2);
                await _context.SaveChangesAsync();

                //decrese the package total post available
                sellerPackage.totalPostAvailable = sellerPackage.totalPostAvailable - 1;
                _context.Update(sellerPackage);
                await _context.SaveChangesAsync();

                //add selling post
                sellingPost.view = 0;
                sellingPost.postLike = 0;
                sellingPost.sellingPostPostingDateTime = DateTime.Now;
                sellingPost.sellingPostPicUpdateDateTime = DateTime.Now;
                sellingPost.sellingPostPostExpiredDate = sellingPost.sellingPostPostingDateTime.AddDays(sellerPackage.packageDetail.periodOfEachSellingPost);
                _context.Add(sellingPost);
                await _context.SaveChangesAsync();

                //increse the dog breed number
                var breed = _context.Breed.Where(x => x.breedId == sellingPost.breedId).Select(x => x).ToList();
                var breed2 = breed[0];
                breed2.total = breed2.total + 1;
                _context.Update(breed2);
                _context.SaveChanges();





                //=== file handling for sellingPostPic1 ===
                if (sellingPostPic1_data != null && sellingPostPic1_data.Contains("base64"))
                {
                    sellingPostPic1_data = sellingPostPic1_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic1.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic1_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellingPostPic2 ===
                if (sellingPostPic2_data != null && sellingPostPic2_data.Contains("base64"))
                {
                    sellingPostPic2_data = sellingPostPic2_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic2.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic2_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellingPostPic3 ===
                if (sellingPostPic3_data != null && sellingPostPic3_data.Contains("base64"))
                {
                    sellingPostPic3_data = sellingPostPic3_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic3.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic3_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellingPostPic4 ===
                if (sellingPostPic4_data != null && sellingPostPic4_data.Contains("base64"))
                {
                    sellingPostPic4_data = sellingPostPic4_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic4.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic4_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellingPostPic5 ===
                if (sellingPostPic5_data != null && sellingPostPic5_data.Contains("base64"))
                {
                    sellingPostPic5_data = sellingPostPic5_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic5.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic5_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if
                var id2 = await _context.SellingPost.Where(x=>x.sellerId == sellingPost.sellerId).OrderByDescending(x=>x.sellingPostId).ToListAsync();
                var forId = id2[0];
                var theId = forId.sellingPostId;
                

                return Json(new
                {
                    error = -1,
                    message = "no Error",
                    id = theId
                    
                });
            }//end try
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "there is error",
                    exception = ex.Message
                });
            }  //end Exception

        }//end function


        public async Task<IActionResult> ExploreSellingPost(int? id)
        {
            if (id == null)
            {
                return Json(new
                {
                    error = 1,
                    message = "no",
                    exception = " please define id"
                });
            }//econ

            var sellingPost = await _context.SellingPost
            .Where(x => x.sellingPostId == id)
            .Include(x=>x.seller)
            .Include(x=>x.breed)
            .Include(x=>x.gender)
            .ToListAsync();
            

            //update each post view first
             if(!_signInManager.IsSignedIn(User)){
                var seller = await _context.Seller.Where(x=>x.sellerId == sellingPost[0].sellerId).ToListAsync();
                var  seller2 = seller[0];
                seller2.totalPostView = seller2.totalPostView+1;
                _context.Update(seller2);
                await _context.SaveChangesAsync();
                
                //update view of each selling post
                var toUpSellingPost = sellingPost[0];
                toUpSellingPost.view = toUpSellingPost.view+1;
                _context.Update(toUpSellingPost);
                await _context.SaveChangesAsync();
            }//con

            else if(_signInManager.IsSignedIn(User)){
                var user = _userManager.GetUserAsync(User).Result;
                var toUpSellingPost = sellingPost[0];
                //find wheter user like the post yet
                var sellingPostFeedback = _context.SellingPostFeedback.Where(x=>x.userId == user.Id && x.sellingPostId == toUpSellingPost.sellingPostId).ToList();
                if(sellingPostFeedback.Count > 0){
                    ViewBag.likeOrNot = 1;
                }
                else if(sellingPost.Count()<=0){
                    ViewBag.likeOrNot = 0;
                }

                if(user.isSeller != sellingPost[0].sellerId){
                    var seller = await _context.Seller.Where(x=>x.sellerId == sellingPost[0].sellerId).ToListAsync();
                    var  seller2 = seller[0];
                    seller2.totalPostView = seller2.totalPostView+1;
                    _context.Update(seller2);
                    await _context.SaveChangesAsync();

                    //update view of each selling post
                    toUpSellingPost = sellingPost[0];
                    toUpSellingPost.view = toUpSellingPost.view+1;
                    _context.Update(toUpSellingPost);
                    await _context.SaveChangesAsync(); 
                }//econ
            }//econ
            

            var theSeller = await _context.Seller.Where(x => x.sellerId == sellingPost[0].sellerId).Select(x => new
            {
                sellerId = x.sellerId,
                userId = x.userId,
                // totalPostAvailable = x.totalPostAvailable,
                farmName = x.farmName,
                sellerProfilePic = "",
                sellerProfilePhoneNumber = x.sellerProfilePhoneNumber,
                sellerProfileDescription = x.sellerProfileDescription,
                editProfileDatetime = x.editProfileDatetime,
                profileView = x.profileView,
                number = x.sellerAddress.number,
                soi = x.sellerAddress.soi,
                moo = x.sellerAddress.moo,
                tambon = x.sellerAddress.tambon,
                amphoe = x.sellerAddress.amphoe,
                street = x.sellerAddress.street,
                province = x.sellerAddress.province,
                postNumber = x.sellerAddress.postNumber,
                farmRegister =x.farmRegister
            }).ToListAsync();
            ViewBag.seller = theSeller;
            ViewBag.theId = theSeller[0].sellerId;
            
            
            
            foreach(var i in sellingPost){
            //check and assign picture part
              if (System.IO.File.Exists("sellingPostPic/" + i.sellingPostId + "sellingPostPic1.png"))
              {
                  i.sellingPostPic1 = ("/sellingPostPic/" + i.sellingPostId + "sellingPostPic1.png").ToString();
              }//econ
              if (System.IO.File.Exists("sellingPostPic/" + i.sellingPostId + "sellingPostPic2.png"))
              {
                  i.sellingPostPic2 = "/sellingPostPic/" + i.sellingPostId + "sellingPostPic2.png";
              }//econ
              if (System.IO.File.Exists("sellingPostPic/" + i.sellingPostId + "sellingPostPic3.png"))
              {
                  i.sellingPostPic3 = "/sellingPostPic/" + i.sellingPostId + "sellingPostPic3.png";
              }//econ
              if (System.IO.File.Exists("sellingPostPic/" + i.sellingPostId + "sellingPostPic4.png"))
              {
                  i.sellingPostPic4 = "/sellingPostPic/" + i.sellingPostId + "sellingPostPic4.png";
              }//econ
              if (System.IO.File.Exists("sellingPostPic/" + i.sellingPostId + "sellingPostPic5.png"))
              {
                  i.sellingPostPic5 = "/sellingPostPic/" + i.sellingPostId + "sellingPostPic5.png";
              }//econ
            }//eloop

            foreach(var i in sellingPost){
              if (i.sellingPostPic1 == "")
              {
                  i.sellingPostPic1 = "/sellingPostPic/default.png";
              }
              if (i.sellingPostPic2 == "")
              {
                  i.sellingPostPic2 = "/sellingPostPic/default.png";
              }
              if (i.sellingPostPic3 == "")
              {
                  i.sellingPostPic3 = "/sellingPostPic/default.png";
              }
              if (i.sellingPostPic4 == "")
              {
                  i.sellingPostPic4 = "/sellingPostPic/default.png";
              }
              if (i.sellingPostPic5 == "")
              {
                  i.sellingPostPic5 = "/sellingPostPic/default.png";
              }
            }//eloop
            var sellingPost2 = sellingPost.Select(x=> new{
              sellerId = x.sellerId,
              sellingPostId = x.sellingPostId,
              sellingPostName= x.sellingPostName,
              sellingPostDescription = x.sellingPostDescription,
              farmName = x.seller.farmName,
              pedegree = x.pedegree,
              dateOfBirth = x.dateOfBirth,
              price = x.price,
              sellingPostPic1 = x.sellingPostPic1,
              sellingPostPic2 = x.sellingPostPic2,
              sellingPostPic3 = x.sellingPostPic3,
              sellingPostPic4 = x.sellingPostPic4,
              sellingPostPic5 = x.sellingPostPic5,
              sellingPostPostingDateTime = x.sellingPostPostingDateTime,
              postLike = x.postLike,
              view =x.view,
              breedId = x.breedId,
              genderId = x.genderId,
              breedNameThai = x.breed.breedNameThai,
              genderName = x.gender.genderName,
              sellingPostPicUpdateDateTime = x.sellingPostPicUpdateDateTime,
              sellingPostPostExpiredDate = x.sellingPostPostExpiredDate
            }).ToList();
            ViewBag.sellingPost3 = sellingPost2;

            //custom queries from FK data table
            ViewBag.genders = _context.Gender.Select(x => new { x.genderId, value = x.genderName });
            //ViewBag.select_gender = ViewBag.genders[0];
            ViewBag.breeds = _context.Breed.Select(x => new { x.breedId, value = x.breedNameEng + " " + x.breedNameThai });
            
            return View();
        }//ef

        public async Task<IActionResult> Edit(SellingPost sellingPost){
            try{
                if(sellingPost.sellingPostPicUpdateDateTime.ToString().Substring(0,4) == "1/1/"){
                sellingPost.sellingPostPicUpdateDateTime=DateTime.Now;
            }
            //=== file for sellingPostPic1 ===
                var sellingPostPic1_data = sellingPost.sellingPostPic1;
                sellingPost.sellingPostPic1 = "";


                //=== file for sellingPostPic2 ===
                var sellingPostPic2_data = sellingPost.sellingPostPic2;
                sellingPost.sellingPostPic2 = "";


                //=== file for sellingPostPic3 ===
                var sellingPostPic3_data = sellingPost.sellingPostPic3;
                sellingPost.sellingPostPic3 = "";


                //=== file for sellingPostPic4 ===
                var sellingPostPic4_data = sellingPost.sellingPostPic4;
                sellingPost.sellingPostPic4 = "";


                //=== file for sellingPostPic5 ===
                var sellingPostPic5_data = sellingPost.sellingPostPic5;
                sellingPost.sellingPostPic5 = "";

                //update
                _context.Update(sellingPost);
                await _context.SaveChangesAsync();

                //=== file handling for sellingPostPic1 ===
                if (sellingPostPic1_data != null && sellingPostPic1_data.Contains("base64"))
                {
                    sellingPostPic1_data = sellingPostPic1_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic1.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic1_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellingPostPic2 ===
                if (sellingPostPic2_data != null && sellingPostPic2_data.Contains("base64"))
                {
                    sellingPostPic2_data = sellingPostPic2_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic2.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic2_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellingPostPic3 ===
                if (sellingPostPic3_data != null && sellingPostPic3_data.Contains("base64"))
                {
                    sellingPostPic3_data = sellingPostPic3_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic3.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic3_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellingPostPic4 ===
                if (sellingPostPic4_data != null && sellingPostPic4_data.Contains("base64"))
                {
                    sellingPostPic4_data = sellingPostPic4_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic4.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic4_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellingPostPic5 ===
                if (sellingPostPic5_data != null && sellingPostPic5_data.Contains("base64"))
                {
                    sellingPostPic5_data = sellingPostPic5_data.Split(',')[1];
                    string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic5.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellingPostPic5_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if
                 return Json(new
                {
                    error = -1,
                    message = "no Error"                    
                });
            }//etry
             catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "there is error",
                    exception = ex.Message
                });
            }  //end Exception
        }//ef
    
        [HttpPost]
        public async Task<IActionResult> Like(SellingPostFeedback sellingPostFeedback){
            try{
                //add in like table
                await _context.SellingPostFeedback.AddAsync(sellingPostFeedback);
                await _context.SaveChangesAsync();

                //update each post like
                var sellingPost = await _context.SellingPost.Where(x=>x.sellingPostId == sellingPostFeedback.sellingPostId).ToListAsync();
                var sellingPost2 = sellingPost[0];
                sellingPost2.postLike = sellingPost2.postLike + 1;
                _context.Update(sellingPost2);
                await _context.SaveChangesAsync();


                //update total like for seller
                var seller = await _context.Seller.Where(x=>x.sellerId == sellingPost2.sellerId).ToListAsync();
                var seller2 = seller[0];
                seller2.totalLike = seller2.totalLike + 1;
                _context.Update(seller2);
                await _context.SaveChangesAsync();
                
                return Json(new
                {
                    error = -1,
                    message = "no error",
                    newLike = sellingPost2.postLike
                });          
            }//etry
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "there is error",
                    exception = ex.Message
                });
            }  //end Exception

        }//ef
        [HttpPost]
        public async Task<IActionResult> DisLike(SellingPostFeedback sellingPostFeedback){
            try{
                //delete in like table
                var sellingPostFeedback2 = await _context.SellingPostFeedback.Where(x=>x.userId == sellingPostFeedback.userId && x.sellingPostId == sellingPostFeedback.sellingPostId).ToListAsync();
                var sellingPostFeedback1 = sellingPostFeedback2[0];
                _context.Remove(sellingPostFeedback1);
                await _context.SaveChangesAsync();


                //update each post like
                var sellingPost = await _context.SellingPost.Where(x=>x.sellingPostId == sellingPostFeedback.sellingPostId).ToListAsync();
                var sellingPost2 = sellingPost[0];
                sellingPost2.postLike = sellingPost2.postLike - 1;
                _context.Update(sellingPost2);
                await _context.SaveChangesAsync();


                //update total like for seller
                var seller = await _context.Seller.Where(x=>x.sellerId == sellingPost2.sellerId).ToListAsync();
                var seller2 = seller[0];
                seller2.totalLike = seller2.totalLike - 1;
                _context.Update(seller2);
                await _context.SaveChangesAsync();
                
                return Json(new
                {
                    error = -1,
                    message = "no error",
                    newLike = sellingPost2.postLike
                });          
            }//etry
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "there is error",
                    exception = ex.Message
                });
            }  //end Exception

        }//ef
        
        [HttpGet]
        public async Task<IActionResult> Index(){
            var sellingPost = await _context.SellingPost.Select(x=> new{
                sellingPostId = x.sellingPostId,
                sellingPostName = x.sellingPostName,
                breedNameThai = x.breed.breedNameThai,
                genderName = x.gender.genderName,
                price = x.price,
                sellingPostPostingDateTime = x.sellingPostPostingDateTime,
                postLike = x.postLike,
                view = x.view,
                sellingPostPic1 =""

            }).ToListAsync();
            ViewBag.sellingPosts = sellingPost;
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Delete(SellingPost toDelete){
            try{
                var sellingPost = await _context.SellingPost.Where(x=>x.sellingPostId == toDelete.sellingPostId).Include(x=>x.gender)
                .Include(x=>x.breed)
                .Include(x=>x.seller)
                .ToListAsync();

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

                    await _context.AddRangeAsync(expiredSellingPost);
                    await _context.SaveChangesAsync();
                }//eloop
                return Json(new
                    {
                        error = -1,
                        message = "no error"
                    }); 
            }//etry
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "there is error",
                    exception = ex.Message
                });
            }  //end Exception

        }//ef    
    
        [HttpGet]
        public async Task<IActionResult> ExploreEachBreed(int? id){
            if(id == null){
                return NotFound();
            }//econ
            var breed = await _context.Breed.FirstOrDefaultAsync(x=>x.breedId == id);
            ViewBag.breed = breed;

            var sellingPost = await _context.SellingPost.Where(x=>x.breedId == id).Select(x=> new{
                sellingPostId = x.sellingPostId,
                sellingPostName = x.sellingPostName,
                breedNameThai = x.breed.breedNameThai,
                genderName = x.gender.genderName,
                price = x.price,
                sellingPostPostingDateTime = x.sellingPostPostingDateTime,
                postLike = x.postLike,
                view = x.view,
                sellingPostPic1 =""

            }).ToListAsync();
            ViewBag.sellingPosts = sellingPost;
            return View();

        }//ef
    }//end class

    
}//end namespace
