using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dog7.Controllers;
using dog7.Data;
using dog7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dog7.Controllers{
    public class SellerFeedback2Controller:Controller{
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private dog7DbContext _context;
        private RoleManager<AppRole> _roleManager;
        public SellerFeedback2Controller(SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,
                                    dog7DbContext db, RoleManager<AppRole> roleManager){
            _signInManager = signInManager;
            _userManager = userManager;
            _context = db;
            _roleManager = roleManager;

        }//econstructor
        [HttpGet]
        public async Task<IActionResult> ReviewSeller(int? id){
            if (id == null)
            {
                return Json( new {
                              error=1,
                              message = "no",
                              exception= " please define id"
                    });
            }//econ
            ViewBag.sellerId = id;
            var seller = await _context.Seller.Where(x=>x.sellerId == id).ToListAsync();
            ViewBag.farmName = seller[0].farmName;

            ViewBag.theSellerFeedbacks = await _context.SellerFeedback.Where(x=>x.sellerId == id).Select( x => new{
									sellerFeedbackId = x.sellerFeedbackId,
                                    userId = x.userId,
									user = x.user.firstName+" "+x.user.lastName,
									feedbackDateTime = x.feedbackDateTime,
									feedbackStar = x.feedbackStar,
									feedbackDescription = x.feedbackDescription,
                                    sellerId = x.sellerId,
									seller = x.seller.sellerId+" "+x.seller.farmName,
                              }).ToListAsync();


            if(_signInManager.IsSignedIn(User)){
                       var user = _userManager.GetUserAsync(User).Result;
                       var role = _userManager.GetRolesAsync(user).Result[0];
                            if(role=="admin"){
                                ViewBag.adm = "1";
                            }
                            else{
                                ViewBag.adm = "0";
                            }
            }
            if(!_signInManager.IsSignedIn(User)){
                ViewBag.adm = "0";
            }
            return View();
            
        }//ef
        [HttpPost]
        public async Task<IActionResult> Add(SellerFeedback sellerFeedback)
        {
            // return Ok(sellerFeedback);
               try{
                   sellerFeedback.feedbackDateTime=DateTime.Now;
                                             
                _context.Add(sellerFeedback);
                await _context.SaveChangesAsync();
                  
                return Json( new {
                              error=-1,
                              message = "yes"
                });
               }//end try
               catch(Exception ex){
                    return Json( new {
                              error=1,
                              message = "yes",
                              exception = ex.Message
                    });
               }  //end Exception
             
        }//end function

    }//en
}//en