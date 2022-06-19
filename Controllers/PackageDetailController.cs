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
    public class PackageDetailController : Controller
    {
        private readonly dog7DbContext _context;

        public PackageDetailController(dog7DbContext context)
        {
            _context = context;
        }//end function

        // GET: PackageDetail
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var result = await _context.PackageDetail
                              .Select(x=>new {
									packageDetailId = x.packageDetailId,
									packageDetailName = x.packageDetailName,
									totalPostOfPackage = x.totalPostOfPackage,
									periodOfEachSellingPost = x.periodOfEachSellingPost,
									totalPeriodOfPackage = x.totalPeriodOfPackage,
									price = x.price,
                              })
                              .ToListAsync();
            ViewBag.packageDetails = result;                                              
            return View();
        }//end function
 
        // GET: PackageDetail/Create
        public IActionResult Add()
        {
        	//custom queries from FK data table

            return View();
        }//end function

        // POST: PackageDetail/Add
        [HttpPost]
        public async Task<IActionResult> Add(PackageDetail packageDetail)
        {
               try{
                                             
                _context.Add(packageDetail);
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

        // GET: PackageDetail/Edit/1
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

            var packageDetail = await _context.PackageDetail.FindAsync(id);
            if (packageDetail == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }

             ViewBag.packageDetail = packageDetail;
           
            return View();
        }//end function

        // POST: PackageDetail/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(PackageDetail packageDetail)
        {
             try{
                                               
                _context.PackageDetail.Update(packageDetail);
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

        // GET: PackageDetail/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageDetail = await _context.PackageDetail
                .FirstOrDefaultAsync(m => m.packageDetailId == id);
            if (packageDetail == null)
            {
                return NotFound();
            }

            return View(packageDetail);
        }//end function

        // POST: PackageDetail/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var packageDetail = await _context.PackageDetail.FindAsync(id);
              if(packageDetail == null){
                  return Ok(new {
                  error =1,
                  msg= "the record was not found"
              });
              }
              _context.PackageDetail.Remove(packageDetail);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "the record is deleted"
              });
        }//end function

        private bool PackageDetailExists(int id)
        {
            return _context.PackageDetail.Any(e => e.packageDetailId == id);
        }//end function
    }//end class
}//end namespace
