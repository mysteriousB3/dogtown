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
using Microsoft.AspNetCore.Authorization;

namespace dog7.Controllers
{
    public class SellerFeedbackController : Controller
    {
        private readonly dog7DbContext _context;

        public SellerFeedbackController(dog7DbContext context)
        {
            _context = context;
        }//end function

        // GET: SellerFeedback
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Index()
        {
            var result = await _context.SellerFeedback
                              .Select(x=>new {
									sellerFeedbackId = x.sellerFeedbackId,
									user = x.user.firstName+" "+x.user.lastName,
									feedbackDateTime = x.feedbackDateTime,
									feedbackStar = x.feedbackStar,
									feedbackDescription = x.feedbackDescription,
									seller = x.seller.sellerId+" "+x.seller.farmName,
                              })
                              .ToListAsync();
            ViewBag.sellerFeedbacks = result;                                              
            return View();
        }//end function
 
        // GET: SellerFeedback/Create
        public IActionResult Add()
        {
        	//custom queries from FK data table
            ViewBag.users = _context.AppUsers.Select(x=> new {x.Id,value=x.firstName+" "+x.lastName});
            //ViewBag.select_user = ViewBag.users[0];
            ViewBag.sellers = _context.Seller.Select(x=> new {x.sellerId,value=x.sellerId+" "+x.farmName});
            //ViewBag.select_seller = ViewBag.sellers[0];

            return View();
        }//end function

        // POST: SellerFeedback/Add
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

        // GET: SellerFeedback/Edit/1
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

            var sellerFeedback = await _context.SellerFeedback.FindAsync(id);
            if (sellerFeedback == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }
            var users = _context.AppUsers.Select(x=> new {x.Id,value=x.firstName+" "+x.lastName});
            ViewBag.users = users;
            ViewBag.select_user = await users.FirstOrDefaultAsync(x=>x.Id == sellerFeedback.userId);
            
           
            var sellers = _context.Seller.Select(x=> new {x.sellerId,value=x.sellerId+" "+x.farmName});
            ViewBag.sellers = sellers;
            ViewBag.select_seller = await sellers.FirstOrDefaultAsync(x=>x.sellerId == sellerFeedback.sellerId);
            
           

             ViewBag.sellerFeedback = sellerFeedback;
           
            return View();
        }//end function

        // POST: SellerFeedback/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(SellerFeedback sellerFeedback)
        {
             try{
                                               
                _context.SellerFeedback.Update(sellerFeedback);
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

        // GET: SellerFeedback/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerFeedback = await _context.SellerFeedback
                .FirstOrDefaultAsync(m => m.sellerFeedbackId == id);
            if (sellerFeedback == null)
            {
                return NotFound();
            }

            return View(sellerFeedback);
        }//end function

        // POST: SellerFeedback/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var sellerFeedback = await _context.SellerFeedback.FindAsync(id);
              if(sellerFeedback == null){
                  return Ok(new {
                  error =1,
                  msg= "the record was not found"
              });
              }
              _context.SellerFeedback.Remove(sellerFeedback);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "the record is deleted"
              });
        }//end function

        private bool SellerFeedbackExists(int id)
        {
            return _context.SellerFeedback.Any(e => e.sellerFeedbackId == id);
        }//end function
    }//end class
}//end namespace
