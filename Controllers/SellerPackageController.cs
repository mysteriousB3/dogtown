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

 

namespace dog7.Controllers
{
    public class SellerPackageController : Controller
    {
        private readonly dog7DbContext _context;

        public SellerPackageController(dog7DbContext context)
        {
            _context = context;
        }//end function

        // GET: SellerPackage
        public async Task<IActionResult> Index()
        {
            var result = await _context.SellerPackage
                              .Select(x=>new {
									sellerPackageId = x.sellerPackageId,
									packageDetail = x.packageDetail.packageDetailName,
									packageBuyingDateTime = x.packageBuyingDateTime,
									packageStartingDateTime = x.packageStartingDateTime,
									packageEndingDateTime = x.packageEndingDateTime,
									totalPackagePurchase = x.totalPackagePurchase,
									paymentEvidence = x.paymentEvidence,
									packageStatus = x.packageStatus,
									totalPostAvailable = x.totalPostAvailable,
									sellerId = x.sellerId,
									seller = x.seller,
                              })
                              .ToListAsync();
            ViewBag.sellerPackages = result;                                              
            return View();
        }//end function
 
        // GET: SellerPackage/Create
        public IActionResult Add()
        {
        	//custom queries from FK data table
            ViewBag.packageDetails = _context.PackageDetail.Select(x=> new {x.packageDetailId,value=x.packageDetailName});
            //ViewBag.select_packageDetail = ViewBag.packageDetails[0];

            return View();
        }//end function

        // POST: SellerPackage/Add
        [HttpPost]
        public async Task<IActionResult> Add(SellerPackage sellerPackage)
        {
               try{
                
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
                              message = "yes",
                              exception = ex.Message
                    });
               }  //end Exception
             
        }//end function

        // GET: SellerPackage/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Json( new {
                              error=1,
                              message = "no",
                              exception= " please define id"
                    });
            }

            var sellerPackage = await _context.SellerPackage.FindAsync(id);
            if (sellerPackage == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }
            var packageDetails = _context.PackageDetail.Select(x=> new {x.packageDetailId,value=x.packageDetailName});
            ViewBag.packageDetails = packageDetails;
            ViewBag.select_packageDetail = await packageDetails.FirstOrDefaultAsync(x=>x.packageDetailId == sellerPackage.packageDetailId);
            
           

             ViewBag.sellerPackage = sellerPackage;
           
            return View();
        }//end function

        // POST: SellerPackage/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(SellerPackage sellerPackage)
        {
             try{
                
                //=== file for paymentEvidence ===
                var paymentEvidence_data = sellerPackage.paymentEvidence;
                sellerPackage.paymentEvidence = "";
                
                               
                _context.SellerPackage.Update(sellerPackage);
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
                              message = "yes",
                              exception = ex.Message
                    });
               }  //end Exception
        }//end function

        // GET: SellerPackage/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerPackage = await _context.SellerPackage
                .FirstOrDefaultAsync(m => m.sellerPackageId == id);
            if (sellerPackage == null)
            {
                return NotFound();
            }

            return View(sellerPackage);
        }//end function

        // POST: SellerPackage/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var sellerPackage = await _context.SellerPackage.FindAsync(id);
              if(sellerPackage == null){
                  return Ok(new {
                  error =1,
                  msg= "the record was not found"
              });
              }
              _context.SellerPackage.Remove(sellerPackage);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "the record is deleted"
              });
        }//end function

        private bool SellerPackageExists(int id)
        {
            return _context.SellerPackage.Any(e => e.sellerPackageId == id);
        }//end function
    }//end class
}//end namespace
