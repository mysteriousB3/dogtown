using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dog7.Data;
using dog7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dog7.Controllers{
    [Authorize(Roles = "admin")]
    public class AdminController:Controller{
        private dog7DbContext _context;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public AdminController(SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,
                                    dog7DbContext context, RoleManager<AppRole> roleManager){
            _context= context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }//econstructor

        public async Task<IActionResult> Index(){
            
            //========== daily register ==========
            // .Where(x=>x.userRegistrationDateTime > DateTime.Today)
            var user = await _context.AppUsers.Where(x=>x.Id !=1 && x.Id !=2).Select(x=>new {
									userId = x.Id,
									firstName = x.firstName,
									lastName = x.lastName,
									PhoneNumber = x.PhoneNumber,
									Email = x.Email,
									userRegistrationDateTime = x.userRegistrationDateTime
                              })
                              .OrderByDescending(x=>x.userRegistrationDateTime)
                              .ToListAsync();
            ViewBag.user = user;

            //========== daily seller ==========
            //create new blank list of seller
            var sellers =new List<Seller>();

            //pull data of user that is approved to be seller yet
            var users =  await _context.AppUsers.Where(x=>x.isSeller>=0).Select(x=>x).ToListAsync();

            //pull data of all seller
            var result = await _context.Seller
                            //   .Where(x=>x.sellerRegistrationDateTime>DateTime.Today)
                              .Select(x=>x)
                              .ToListAsync();

            foreach(var i in result){
                i.sellerIdCardFront = "/sellerRegisterPic/"+i.sellerId+"sellerIdCardFront.png";
                i.sellerIdCardBack = "/sellerRegisterPic/"+i.sellerId+"sellerIdCardBack.png";
                i.selllerBookBankAccountPic = "/sellerRegisterPic/"+i.sellerId+"selllerBookBankAccountPic.png";
                if(System.IO.File.Exists("sellerRegisterPic/" + i.sellerId + "sellerFarmRegisterPic.png")){
                    i.sellerFarmRegisterPic = "/sellerRegisterPic/" + i.sellerId + "sellerFarmRegisterPic.png";
                }//econ
                else if(!System.IO.File.Exists("sellerRegisterPic/" + i.sellerId + "sellerFarmRegisterPic.png")){
                        i.sellerFarmRegisterPic = "/sellerRegisterPic/default.png";
                }//econ
            }//eloop

            //if seller data is appear in Appuser that it is approved, then add to list
            foreach(var i in users){
                foreach(var j in result){
                    if(i.Id == j.userId){
                        sellers.Add(j);
                    }
                }//eloop
            }//eloop

            //manage data into new format
            var sellers2 = sellers.Select(x=>new {
									sellerId = x.sellerId,
									user = x.user.firstName+" "+x.user.lastName,
									sellerIdCard = x.sellerIdCard,
									sellerIdCardFront = x.sellerIdCardFront,
									sellerIdCardBack = x.sellerIdCardBack,
									selllerBookBankAccountPic = x.selllerBookBankAccountPic,
									sellerFarmRegisterPic = x.sellerFarmRegisterPic,
									// totalPostAvailable = x.totalPostAvailable,
									sellerRegistrationDateTime = x.sellerRegistrationDateTime,
                                    sellerApproveDateTime = x.sellerApproveDateTime
                              })
                              .OrderByDescending(x=>x.sellerRegistrationDateTime)
                              .ToList();
            
            ViewBag.sellers = sellers2;

            //========== daily seller feedback ==========
            var sellerFeedbacks = await _context.SellerFeedback
                              .Where(x=>x.feedbackDateTime > DateTime.Today)
                              .Select(x=>new {
									sellerFeedbackId = x.sellerFeedbackId,
									user = x.user.firstName+" "+x.user.lastName,
									feedbackDateTime = x.feedbackDateTime,
									feedbackStar = x.feedbackStar,
									feedbackDescription = x.feedbackDescription,
									seller = x.seller.sellerId+" "+x.seller.farmName,
                              })
                              .OrderByDescending(x=>x.feedbackDateTime)
                              .ToListAsync();
            ViewBag.sellerFeedbacks = sellerFeedbacks;

            //========== current top 10 selling post ==========
            var sellingPost = await _context.SellingPost.Where(x=>x.sellingPostPostingDateTime > DateTime.Today).Select(x=> new{
                sellingPostId = x.sellingPostId,
                sellingPostName = x.sellingPostName,
                breedNameThai = x.breed.breedNameThai,
                genderName = x.gender.genderName,
                price = x.price,
                sellingPostPostingDateTime = x.sellingPostPostingDateTime,
                postLike = x.postLike,
                view = x.view,
                sellingPostPic1 =""

            }).OrderByDescending(x=>x.postLike).ToListAsync();
            ViewBag.sellingPosts = sellingPost;


            //========== Revenue Report ==========
            var sellerPackages = await _context.SellerPackage
                              .Where(x=>(x.packageStatus==1 || x.packageStatus==-1 ) && x.packageDetailId!=1)
                              .Select(x=>new {
									sellerPackageId = x.sellerPackageId,
									packageDetail = x.packageDetail.packageDetailName,
									packageBuyingDateTime = x.packageBuyingDateTime,
									packageStartingDateTime = x.packageStartingDateTime,
									packageEndingDateTime = x.packageEndingDateTime,
									totalPackagePurchase = x.totalPackagePurchase,
									// paymentEvidence = "/evidencePic/"+x.sellerPackageId+"paymentEvidence.png",
									packageStatus = x.packageStatus,
									totalPostAvailable = x.totalPostAvailable,
									sellerId = x.sellerId,
                                    farmName = x.seller.farmName,
                                    name = x.seller.user.firstName +" "+ x.seller.user.lastName,
                                    phoneNumber = x.seller.user.PhoneNumber,
                                    farmPhoneNumber=x.seller.sellerProfilePhoneNumber
                              })
                              .OrderByDescending(x=>x.packageBuyingDateTime)
                              .ToListAsync();
            var sellerPackages3 = sellerPackages.GroupBy(x=>x.packageDetail).Select(x=>new{
                name = x.Key,
                total = x.Sum(j=>j.totalPackagePurchase),
                count = x.Count()
            }).ToList();
            ViewBag.sellerPackages3 = sellerPackages3;
            
            var totalToday = 0;
            var total = 0;            
            foreach(var i in sellerPackages){
                if(i.packageBuyingDateTime> DateTime.Today){
                    totalToday += i.totalPackagePurchase;
                }
                total += i.totalPackagePurchase;
            }//eloop
            ViewBag.totalPackageToday =totalToday;
            ViewBag.totalPackage = total; 
            ViewBag.sellerPackages = sellerPackages;
             

            

            
            return View();
        }//ef

        //it is the index of seller that is waiting to be investigated and approved
        [HttpGet]
        public async Task<IActionResult> ApproveSeller(){
            var users =  await _context.AppUsers.Where(x=>x.isSeller==-1).Select(x=>x).ToListAsync();
            var getSellers = await _context.Seller.Select(x=>x).ToListAsync();
            var sellers =new List<Seller>();
            foreach(var i in users){
                foreach(var j in getSellers){
                    if(i.Id == j.userId){
                        sellers.Add(j);
                    }
                }//eloop
            }//eloop
            var realSeller = sellers.Select(x=>new {
									sellerId = x.sellerId,
									user = x.user.firstName+" "+x.user.lastName,
									sellerIdCard = x.sellerIdCard,
									sellerIdCardFront = x.sellerIdCardFront,
									sellerIdCardBack = x.sellerIdCardBack,
									selllerBookBankAccountPic = x.selllerBookBankAccountPic,
									sellerFarmRegisterPic = x.sellerFarmRegisterPic,
									sellerRegistrationDateTime = x.sellerRegistrationDateTime,
                              }).ToList();
            ViewBag.sellers = realSeller;            
            return View();
        }//ef


        //this page is the page for admin to investigate each list of seller that is waiting to be approved
        //GET
        [HttpGet]
        public async Task<IActionResult> approveSeller2(int? id)
        {
            if (id == null)
            {
                return Json( new {
                              error=1,
                              message = "no",
                              exception= " please define id"
                    });
            }
            var seller = await _context.Seller.FindAsync(id);
            if (seller == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }
            var user = _context.AppUsers.Where(x=>x.Id == seller.userId).Select(x=> new {x.Id,value=x.firstName+" "+x.lastName,x.PhoneNumber});
            ViewBag.user = user;
            if(System.IO.File.Exists("sellerRegisterPic/" + seller.sellerId + "sellerFarmRegisterPic.png")){
                    seller.sellerFarmRegisterPic = "/sellerRegisterPic/" + seller.sellerId + "sellerFarmRegisterPic.png";
            }//econ
            else if(!System.IO.File.Exists("sellerRegisterPic/" + seller.sellerId + "sellerFarmRegisterPic.png")){
                    seller.sellerFarmRegisterPic = "/sellerRegisterPic/default.png";
            }//econ
            ViewBag.seller = seller;
            return View();
        }//ef

        [HttpPost]
        public async Task<IActionResult> approveSeller2(approveSeller2C ids){
            
            if (ids.uId == null || ids.sellerId == null || ids.status ==null)
            {
                return Json( new {
                              error=-1,
                              message = "no",
                              exception= "กรุณาเลือกรหัสประจำตัวผู้ใช้หรือการกระทำ"
                    });
            }//econ            
            //1.get user from AppUser first
            var user = await _userManager.FindByIdAsync(ids.uId.ToString());
            //2.check whether status is approve or reject
            if(ids.status == -1){
                
                //if reject, update isSeller in AppUSer to be -2, then it can be show reject on sidebar
                //and the reason in memo
                // var countReject = user.isSeller-=1;             
                user.isSeller = -2;
                user.memo = ids.memo;
                await _userManager.UpdateAsync(user);

                //delete seller package first
                var sellerPackage = await _context.SellerPackage.FirstOrDefaultAsync(x=>x.sellerId == ids.sellerId);
                _context.SellerPackage.Remove(sellerPackage);
                await _context.SaveChangesAsync();

                //then delete the seller information that user have regist to open the shop
                //1.get seller object
                var seller2 = await _context.Seller.FirstOrDefaultAsync(x=>x.sellerId == ids.sellerId);

                //2.delete and save change
                _context.Seller.Remove(seller2);
                await _context.SaveChangesAsync();
                return Json( new {
                              error=-1,
                              message = "ปฏิเสธการสมัครเป็นผู้ขายเรียบร้อย"
                    });
            }//econ reject

            //if accecpt 
            string sellerId2 = ids.sellerId.ToString();
            int sellerId = int.Parse(sellerId2);

            //update isSeller to be sellerId and tell the reason in memo
            user.isSeller = sellerId;
            user.memo = ids.memo;
            await _userManager.UpdateAsync(user);

            var seller = await _context.Seller.FindAsync(ids.sellerId);
            seller.sellerApproveDateTime = DateTime.Now;
            _context.Seller.Update(seller);
            await _context.SaveChangesAsync();
            return Json( new {
                            error=-1,
                            message = "อนุมัตให้ผู้ใช้เป็นผู้ขายเรียบร้อย"
                });    
            
            
            
            
            
            

            



        }//ef

        [HttpGet]
        public async Task<IActionResult> ApprovePackage()
        {
            var result = await _context.SellerPackage
                              .Where(x=>x.packageStatus==0 && x.packageDetailId!=1)
                              .Select(x=>new {
									sellerPackageId = x.sellerPackageId,
									packageDetail = x.packageDetail.packageDetailName,
									packageBuyingDateTime = x.packageBuyingDateTime,
									packageStartingDateTime = x.packageStartingDateTime,
									packageEndingDateTime = x.packageEndingDateTime,
									totalPackagePurchase = x.totalPackagePurchase,
									paymentEvidence = "/evidencePic/"+x.sellerPackageId+"paymentEvidence.png",
									packageStatus = x.packageStatus,
									totalPostAvailable = x.totalPostAvailable,
									sellerId = x.sellerId,
                                    farmName = x.seller.farmName,
                                    name = x.seller.user.firstName +" "+ x.seller.user.lastName,
                                    phoneNumber = x.seller.user.PhoneNumber,
                                    farmPhoneNumber=x.seller.sellerProfilePhoneNumber
                              })
                              .ToListAsync();
            ViewBag.sellerPackages = result;                                              
            return View();
        }//end function
        
        
        public async Task<IActionResult> notApprovePackage(approvePackageC idC){
            if(idC == null){
                return NotFound();
            }//econ
            try{
                var sellerPackage = await _context.SellerPackage.FirstOrDefaultAsync(x=>x.sellerPackageId == idC.sellerPackageId);
                sellerPackage.packageStatus = -2;
                _context.Update(sellerPackage);
                await _context.SaveChangesAsync();
                
                return Json(new{
                    error=-1
                });
            }
            catch(Exception ex){
                    return Json( new {
                              error=1,
                              message = "error",
                              exception = ex.Message
                    });
               }  //end Exception
            
            
        }//ef
    

        [HttpPost]
        public async Task<IActionResult> ApprovePackage(approvePackageC idC){
           if(idC == null){
                return NotFound();
            }//econ

            try{
                //unuse starter package first
                var sellerPackage = await _context.SellerPackage.FirstOrDefaultAsync(x=>x.sellerId == idC.sellerId && x.packageStatus==1);
                sellerPackage.packageStatus = -1;
                _context.Update(sellerPackage);
                await _context.SaveChangesAsync();

                //use the approved new one
                var sellerPackage2 = await _context.SellerPackage.Where(x=>x.sellerPackageId == idC.sellerPackageId).Include(x=>x.packageDetail).ToListAsync();
                sellerPackage = sellerPackage2[0];
                sellerPackage.packageStatus = 1;
                sellerPackage.packageStartingDateTime = DateTime.Now;
                var day = sellerPackage.packageDetail.totalPeriodOfPackage;
                sellerPackage.packageEndingDateTime = sellerPackage.packageStartingDateTime.AddDays(day);

                //count the post that already post and update with the new package
                var sellingPostCount = await _context.SellingPost.Where(x=>x.sellerId == idC.sellerId).CountAsync();
                
                //if sellingpost have more than total post available delete some
                if(sellingPostCount > sellerPackage.totalPostAvailable){
                    var dif = sellingPostCount - sellerPackage.totalPostAvailable;
                    var sellingPost = await _context.SellingPost.Where(x=>x.sellerId== idC.sellerId).Include(x=>x.gender)
                    .Include(x=>x.breed)
                    .Include(x=>x.seller)
                    .OrderBy(x=>x.postLike)
                    .Take(dif)
                    .ToListAsync();
                    
                    //delete
                    _context.RemoveRange(sellingPost);
                    await _context.SaveChangesAsync();

                    //decrese the number of breed
                    foreach(var i in sellingPost){
                        var breed = await _context.Breed.FirstOrDefaultAsync(x=>x.breedId == i.breedId);
                        breed.total =breed.total-1;
                        _context.Update(breed);
                        await _context.SaveChangesAsync();

                    }

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

                    //= 0 because it is already excedd and after delete the exceed, the available will = 0
                    sellerPackage.totalPostAvailable=0;
                    _context.Update(sellerPackage);
                    await _context.SaveChangesAsync();
                }//econ
                if(sellingPostCount <= sellerPackage.totalPostAvailable){
                    sellerPackage.totalPostAvailable = sellerPackage.totalPostAvailable - sellingPostCount;
                    _context.Update(sellerPackage);
                    await _context.SaveChangesAsync();
                }

                

                //update each selling post to have the new ending period
                var sellingPosts = await _context.SellingPost.Where(x=>x.sellerId == idC.sellerId).ToListAsync();
                
                var today = DateTime.Now;
                var daysToAdd = sellerPackage.packageDetail.periodOfEachSellingPost;
                foreach(var i in sellingPosts){
                    i.sellingPostPostExpiredDate = today.AddDays(daysToAdd);
                }//eloop

                _context.UpdateRange(sellingPosts);
                await _context.SaveChangesAsync();

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
    }//ec

    public class approveSeller2C{
        public int? uId {get;set;}
        public int? sellerId {get;set;}
        public int? status {get;set;}
        public string memo {get;set;}
    }//ec
    public class approvePackageC{
        public int? sellerPackageId{get;set;}
        public int? sellerId {get;set;}
    }

}//en