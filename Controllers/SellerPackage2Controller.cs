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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace dog7.Controllers{
    public class SellerPackage2Controller:Controller{
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private dog7DbContext _context;
        private RoleManager<AppRole> _roleManager;
        public SellerPackage2Controller(SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,
                                    dog7DbContext db, RoleManager<AppRole> roleManager){
            _signInManager = signInManager;
            _userManager = userManager;
            _context = db;
            _roleManager = roleManager;
        }

        
        public async Task<IActionResult> Initiate(int id){
            
            try{
              SellerPackage sellerPackage = new SellerPackage();
                sellerPackage.packageDetailId =1;
                sellerPackage.packageBuyingDateTime = DateTime.Now;
                sellerPackage.packageStartingDateTime = DateTime.Now;
                sellerPackage.totalPostAvailable = 5;
                sellerPackage.packageStatus=1;
                sellerPackage.sellerId=id;
                await _context.AddAsync(sellerPackage);
                await _context.SaveChangesAsync();
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
    
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index (int? id){
          if (id == null)
            {
                return NotFound();
            }
          //get seller sellerPackage and packageDetail
          var seller2 = await _context.Seller.Where(x=>x.sellerId == id).ToListAsync();
          var seller = seller2[0];

          var sellerPackage2 = await _context.SellerPackage.Where(x=>x.sellerId ==id && x.packageStatus==1).Include(x=>x.packageDetail).ToListAsync();
          var sellerPackage = sellerPackage2[0];
          
          var packageDetails = await _context.PackageDetail.Select(x=>x).ToListAsync();

          //history purchase
          var history = await _context.SellerPackage.Where(x=>x.sellerId ==id && x.packageDetailId!=1).ToListAsync();
          ViewBag.history = history;

          
          if(seller == null || sellerPackage ==null){
            return NotFound();
          }
          
          ViewBag.seller = seller;
          ViewBag.sellerPackage = sellerPackage;
          ViewBag.packageDetails = packageDetails;
          

          var user = _userManager.GetUserAsync(User).Result;
          if(user.isSeller != seller.sellerId){
            return NotFound();
          }
          return View();
        }//ef
        
        [HttpPost]
        public async Task<IActionResult> Add(SellerPackage sellerPackage)
        {
          
               try{
                 sellerPackage.packageBuyingDateTime = DateTime.Now;
                 
                
                //=== file for paymentEvidence ===
                var paymentEvidence_data = sellerPackage.paymentEvidence;
                sellerPackage.paymentEvidence = "";
                
                             
                _context.Add(sellerPackage);
                await _context.SaveChangesAsync();
                
                //=== file handling for paymentEvidence ===
                if(paymentEvidence_data !=null &&paymentEvidence_data.Contains("base64"))
                {
                  paymentEvidence_data = paymentEvidence_data.Split(',')[1];
                  string fileName = sellerPackage.sellerPackageId.ToString() + "paymentEvidence.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/evidencePic/{fileName}");
                  var bytess = Convert.FromBase64String(paymentEvidence_data);
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
               }//end try
               catch(Exception ex){
                    return Json( new {
                              error=1,
                              message = "No",
                              exception = ex.Message
                    });
               }  //end Exception
             
        }//end function
    }//ec
}//en