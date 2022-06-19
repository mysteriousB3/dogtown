using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dog7.Controllers;
using dog7.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dog7.Models
{
    public class Seller2Controller : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private dog7DbContext _context;
        private RoleManager<AppRole> _roleManager;
        private SellerPackage2Controller _m1;

        public Seller2Controller(SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,
                                    dog7DbContext db, RoleManager<AppRole> roleManager, SellerPackage2Controller m1)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = db;
            _roleManager = roleManager;
            _m1 = m1;
        }
        [HttpGet]
        public async Task<IActionResult> OpenShop()
        {
            ViewBag.user = await _userManager.GetUserAsync(User);
            return View();
        }//ef


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> OpenShopAddress(SellerAddress sellerAddress)
        {
            sellerAddress.changeSellerAddress = DateTime.Now;

            try
            {
                await _context.AddAsync(sellerAddress);
                await _context.SaveChangesAsync();
                return Json(new
                {
                    error = -1,
                    message = "yes"
                });
            }//etry
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "yes",
                    exception = ex.Message
                });
            }  //end Exception


        }//ef

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> OpenShop(Seller seller)
        {

            //seller part

            seller.sellerRegistrationDateTime = DateTime.Now;
            // seller.totalPostAvailable=5;
            var address = _context.SellerAddress.Where(x => x.userId == seller.userId.ToString()).ToList()[0];
            seller.sellerAddressId = address.sellerAddressId;



            try
            {

                //=== file for sellerIdCardFront ===
                var sellerIdCardFront_data = seller.sellerIdCardFront;
                seller.sellerIdCardFront = "";


                //=== file for sellerIdCardBack ===
                var sellerIdCardBack_data = seller.sellerIdCardBack;
                seller.sellerIdCardBack = "";


                //=== file for selllerBookBankAccountPic ===
                var selllerBookBankAccountPic_data = seller.selllerBookBankAccountPic;
                seller.selllerBookBankAccountPic = "";


                //=== file for sellerFarmRegisterPic ===
                var sellerFarmRegisterPic_data = seller.sellerFarmRegisterPic;
                seller.sellerFarmRegisterPic = "";






                await _context.AddAsync(seller);
                await _context.SaveChangesAsync();


                //go to update in AppuserId to be -1 mean waiting for invertigation
                var user = _userManager.GetUserAsync(User).Result;
                user.isSeller = -1;
                await _userManager.UpdateAsync(user);

                //initiate starter package for new seller 
                var seller2 = _context.Seller.Where(x => x.userId == user.Id).ToList();
                await _m1.Initiate(seller2[0].sellerId);

                //=== file handling for sellerIdCardFront ===
                if (sellerIdCardFront_data != null && sellerIdCardFront_data.Contains("base64"))
                {
                    sellerIdCardFront_data = sellerIdCardFront_data.Split(',')[1];
                    string fileName = seller.sellerId.ToString() + "sellerIdCardFront.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellerIdCardFront_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellerIdCardBack ===
                if (sellerIdCardBack_data != null && sellerIdCardBack_data.Contains("base64"))
                {
                    sellerIdCardBack_data = sellerIdCardBack_data.Split(',')[1];
                    string fileName = seller.sellerId.ToString() + "sellerIdCardBack.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellerIdCardBack_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for selllerBookBankAccountPic ===
                if (selllerBookBankAccountPic_data != null && selllerBookBankAccountPic_data.Contains("base64"))
                {
                    selllerBookBankAccountPic_data = selllerBookBankAccountPic_data.Split(',')[1];
                    string fileName = seller.sellerId.ToString() + "selllerBookBankAccountPic.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                    var bytess = Convert.FromBase64String(selllerBookBankAccountPic_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                //=== file handling for sellerFarmRegisterPic ===
                if (sellerFarmRegisterPic_data != null && sellerFarmRegisterPic_data.Contains("base64"))
                {   
                    seller2[0].farmRegister = 1;
                    _context.Update(seller2[0]);
                    await _context.SaveChangesAsync();
                    
                    sellerFarmRegisterPic_data = sellerFarmRegisterPic_data.Split(',')[1];
                    string fileName = seller.sellerId.ToString() + "sellerFarmRegisterPic.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                    var bytess = Convert.FromBase64String(sellerFarmRegisterPic_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                return Json(new
                {
                    error = -1,
                    message = "yes"
                });
            }//end try
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "yes",
                    exception = ex.Message
                });
            }  //end Exception

        }//end function

        [HttpGet]
        [Authorize]
        public IActionResult CompleteShop()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user.isSeller <= 0)
            {
                RedirectToAction("Index", "home");
            }
            ViewBag.sellerId = _context.Seller.Where(x => x.sellerId == user.isSeller).Select(x => x.sellerId).ToList()[0];
            return View();
        }//ef

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CompleteShop(Seller seller)
        {
            var seller2 = await _context.Seller.FindAsync(seller.sellerId);
            seller2.profileView = 0;
            seller2.farmName = seller.farmName;
            seller2.sellerProfilePhoneNumber = seller.sellerProfilePhoneNumber;
            seller2.sellerProfileDescription = seller.sellerProfileDescription;
            // seller2.editProfileDatetime = DateTime.Now;

            try
            {
                _context.Seller.Update(seller2);
                await _context.SaveChangesAsync();

                var sellerProfilePic_data = seller.sellerProfilePic;
                seller.sellerProfilePic = "";
                //=== file handling for  ===
                if (sellerProfilePic_data != null && sellerProfilePic_data.Contains("base64"))
                {
                    sellerProfilePic_data = sellerProfilePic_data.Split(',')[1];
                    string fileName = seller2.sellerId.ToString() + "sellerProfilePic.png";
                    string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerProfilePic/{fileName}");
                    var bytess = Convert.FromBase64String(sellerProfilePic_data);
                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }//end using         
                }//end if

                return Json(new
                {
                    error = -1,
                    message = "yes"
                });
            }//etry
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "yes",
                    exception = ex.Message
                });
            }  //end Exception
        }//ef

        [HttpGet]
        public async Task<IActionResult> MyShop(int? id)
        {
            if (id == null)
            {
                RedirectToAction("Index", "home");
            }
            //count the number of review
            ViewBag.totalReview=await _context.SellerFeedback.Where(x=>x.sellerId ==id).CountAsync();
            ViewBag.total5Review=await _context.SellerFeedback.Where(x=>x.sellerId ==id && x.feedbackStar==5).CountAsync();

            ViewBag.seller = await _context.Seller.Where(x => x.sellerId == id).Select(x => new
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
                totalPost = x.totalPost,
                totalPostView = x.totalPostView,
                farmRegister = x.farmRegister
            }).ToListAsync();
            //seller id
            ViewBag.theId = id;

            //get all selling post from other function
            ViewBag.sellingPostCard = await SellingPostCard(id);

            //custom queries from FK data table
            ViewBag.genders = _context.Gender.Select(x => new { x.genderId, value = x.genderName });
            //ViewBag.select_gender = ViewBag.genders[0];
            ViewBag.breeds = _context.Breed.Select(x => new { x.breedId, value = x.breedNameEng + " " + x.breedNameThai });
            
            //update profile view even if user do not log in, and if log in, the user must not be the same as shop owner
            if(!_signInManager.IsSignedIn(User)){
                var seller = await _context.Seller.Where(x=>x.sellerId == id).ToListAsync();
                var  seller2 = seller[0];
                seller2.profileView = seller2.profileView+1;
                _context.Update(seller2);
                await _context.SaveChangesAsync();              
            }//con

            else if(_signInManager.IsSignedIn(User)){
                var user = _userManager.GetUserAsync(User).Result;
                if(user.isSeller != id){
                    var seller = await _context.Seller.Where(x=>x.sellerId == id).ToListAsync();
                    var  seller2 = seller[0];
                    seller2.profileView = seller2.profileView+1;
                    _context.Update(seller2);
                    await _context.SaveChangesAsync(); 
                }//econ
            }//econ

            //get seller feed post to show
            var sellerFeedPosts = await _context.SellerFeedPost.Where(x=>x.sellerId ==id).Select(x=> new{
                sellerFeedPostId = x.sellerFeedPostId,
                sellerId = x.sellerId,
                feedPostPic1="",
                feedPostPic2="",
                feedPostPic3="",
                feedPostPic4="",
                feedPostPic5="",
                postingDateTime = x.postingDateTime,
                description = x.description
            })
            .OrderByDescending(x=>x.postingDateTime)
            .ToListAsync();
            ViewBag.sellerFeedPosts = sellerFeedPosts;

            

            return View();
        }//ef

        public async Task<IActionResult> SellingPostCard(int? id){
            var result = await _context.SellingPost
            .Where(x=>x.sellerId == id)
            .Include(x=>x.seller)
            .OrderByDescending(x=>x.sellingPostPostingDateTime)
            .ToListAsync();
            var result2 = result;
            foreach(var i in result2){
                if(System.IO.File.Exists("sellingPostPic/"+i.sellingPostId+"sellingPostPic1.png")){
                    i.sellingPostPic1="/sellingPostPic/"+i.sellingPostId+"sellingPostPic1.png";
                }//econ
                else{
                    i.sellingPostPic1="/sellingPostPic/default.png";
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
                x.seller.sellerFarmRegisterPic,
                x.sellingPostPostExpiredDate
            }).ToList();
            return Ok(result3);
        }//ef

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> editSellerProfile (int? id){
            if (id == null)
            {
                RedirectToAction("Index", "home");
            }
            var sellerProfile = await _context.Seller.Where(x=>x.sellerId == id).Select(x=>new{
                sellerId =x.sellerId,
                farmName = x.farmName,
                sellerProfilePic = "",
                sellerProfilePhoneNumber =x.sellerProfilePhoneNumber,
                sellerProfileDescription = x.sellerProfileDescription,
                editProfileDatetime = x.editProfileDatetime,
                sellerAddressId = x.sellerAddressId,
                number = x.sellerAddress.number,
                soi = x.sellerAddress.soi,
                moo = x.sellerAddress.moo,
                tambon = x.sellerAddress.tambon,
                amphoe = x.sellerAddress.amphoe,
                street = x.sellerAddress.street,
                province = x.sellerAddress.province,
                postNumber = x.sellerAddress.postNumber,
                userId = x.userId
            }).ToListAsync();
            ViewBag.sellerProfile = sellerProfile[0];
            ViewBag.today = DateTime.Now;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> editSellerProfile (EditSellerProfile sellerProfile){
            try{
                var sellerProfilePic_data = sellerProfile.sellerProfilePic;
                sellerProfile.sellerProfilePic = "";
                
                //seller part (profile)
                var seller2 = await _context.Seller.Where(x=>x.sellerId == sellerProfile.sellerId).ToListAsync();
                var seller = seller2[0];
                seller.farmName = sellerProfile.farmName;
                seller.sellerProfileDescription = sellerProfile.sellerProfileDescription;
                seller.sellerProfilePhoneNumber = sellerProfile.sellerProfilePhoneNumber;
                seller.editProfileDatetime = DateTime.Now;
                _context.Seller.Update(seller);
                await _context.SaveChangesAsync();
                //seller address part
                var sellerAddress2 = await _context.SellerAddress.Where(x=>x.sellerAddressId == sellerProfile.sellerAddressId).ToListAsync();
                var sellerAddress = sellerAddress2[0];
                sellerAddress.number = sellerProfile.number;
                sellerAddress.soi = sellerProfile.soi;
                sellerAddress.moo = sellerProfile.moo;
                sellerAddress.tambon = sellerProfile.tambon;
                sellerAddress.amphoe = sellerProfile.amphoe;
                sellerAddress.street = sellerProfile.street;
                sellerAddress.province = sellerProfile.province;
                sellerAddress.postNumber = sellerProfile.postNumber;
                sellerAddress.changeSellerAddress =DateTime.Now;
                _context.SellerAddress.Update(sellerAddress);
                await _context.SaveChangesAsync();
                

                //profile image part
                if(sellerProfilePic_data !=null &&sellerProfilePic_data.Contains("base64"))
                {
                  sellerProfilePic_data = sellerProfilePic_data.Split(',')[1];
                  string fileName = sellerProfile.sellerId.ToString() + "sellerProfilePic.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerProfilePic/{fileName}");
                  var bytess = Convert.FromBase64String(sellerProfilePic_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if
                return Json( new {
                              error=-1,
                              message = "yes"
                });
            }//etry
            catch(Exception ex){
                    return Json( new {
                              error=1,
                              message = "yes",
                              exception = ex.Message
                    });
               }  //end Exception
        }//ef
    
        [HttpPost]
        public async Task<IActionResult> DeactivateSeller (EditSellerProfile dSeller){
            try{
                var deSeller = await _context.Seller.FirstOrDefaultAsync(x=>x.sellerId == dSeller.sellerId);

                //prepare the starter package incase user comeback
                var sellerPackage = await _context.SellerPackage.FirstOrDefaultAsync(x=>x.sellerId == deSeller.sellerId && x.packageStatus ==1);
                sellerPackage.packageStatus = -1;
                _context.Update(sellerPackage);
                await _context.SaveChangesAsync();

                var oldSellerPackage = await _context.SellerPackage.FirstOrDefaultAsync(x=>x.sellerId == deSeller.sellerId && x.packageDetailId ==1);
                oldSellerPackage.packageStatus = 1;
                oldSellerPackage.totalPostAvailable = 5;
                _context.Update(oldSellerPackage);
                await _context.SaveChangesAsync();

                //unseller in user
                var user = await _context.AppUsers.FirstOrDefaultAsync(x=>x.isSeller == deSeller.sellerId);
                user.isSeller=0;
                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();

                //get all of selling post of the seller
                var sellingPost = await _context.SellingPost.Where(x=>x.sellerId == deSeller.sellerId).Include(x=>x.gender).Include(x=>x.breed).Include(x=>x.seller).ToListAsync();

                if(sellingPost != null){
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
                    var expiredSellingPost = new List<ExpiredSellingPost>();
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
                    await _context.AddRangeAsync(expiredSellingPost);
                    await _context.SaveChangesAsync();

                }//econ
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

        
        public async Task<IActionResult> ReOpen(){
            
            try{
                
                var user = _userManager.GetUserAsync(User).Result;

                var seller = await _context.Seller.FirstOrDefaultAsync(x=>x.userId == user.Id);
                user.isSeller = seller.sellerId;
                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();
                return View("Views/Home/Index.cshtml");
                
            }//etry
            catch 
            {
                return NotFound();
            }  //end Exception

        }//ef
        
        public async Task<IActionResult> DeactivateUser(AppUser user){
            try{
                var theUser = await _context.AppUsers.FirstOrDefaultAsync(x=>x.Id == user.Id);
                if(theUser.isSeller>0){
                    var dSeller = new EditSellerProfile();
                    dSeller.sellerId=theUser.isSeller;
                    await DeactivateSeller(dSeller);
                }//econ
                theUser.otp = -1;
                theUser.UserName = "thisisOldll"+theUser.UserName;
                theUser.Email = "thisisOldll"+theUser.Email;
                await _userManager.UpdateAsync(theUser);
                await _context.SaveChangesAsync();
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
    }//ec
    

    public class EditSellerProfile{
        public int sellerId {get;set;}
        public string farmName {get;set;}
        public string sellerProfilePic {get;set;}
        public string sellerProfileDescription {get;set;}
        public string sellerProfilePhoneNumber{get;set;}
        public DateTime editProfileDatetime {get;set;}
        public int sellerAddressId {get;set;}
        public string number {get;set;}
        public string soi {get;set;}
        public string moo {get;set;}
        public string tambon {get;set;}
        public string amphoe {get;set;}
        public string street {get;set;}
        public string province {get;set;}
        public string postNumber {get;set;}
    }//ec
}//en