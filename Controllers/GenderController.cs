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
    [Authorize(Roles ="admin")]
    public class GenderController : Controller
    {
        private readonly dog7DbContext _context;

        public GenderController(dog7DbContext context)
        {
            _context = context;
        }//end function

        // GET: Gender
        public async Task<IActionResult> Index()
        {
            var result = await _context.Gender
                              .Select(x=>new {
									genderId = x.genderId,
									genderName = x.genderName,
                              })
                              .ToListAsync();
            ViewBag.genders = result;                                              
            return View();
        }//end function
 
        // GET: Gender/Create
        public IActionResult Add()
        {
        	//custom queries from FK data table

            return View();
        }//end function

        // POST: Gender/Add
        [HttpPost]
        public async Task<IActionResult> Add(Gender gender)
        {
               try{
                                             
                _context.Add(gender);
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

        // GET: Gender/Edit/1
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

            var gender = await _context.Gender.FindAsync(id);
            if (gender == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }

             ViewBag.gender = gender;
           
            return View();
        }//end function

        // POST: Gender/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(Gender gender)
        {
             try{
                                               
                _context.Gender.Update(gender);
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

        // GET: Gender/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await _context.Gender
                .FirstOrDefaultAsync(m => m.genderId == id);
            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }//end function

        // POST: Gender/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var gender = await _context.Gender.FindAsync(id);
              if(gender == null){
                  return Ok(new {
                  error =1,
                  msg= "the record was not found"
              });
              }
              _context.Gender.Remove(gender);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "the record is deleted"
              });
        }//end function

        private bool GenderExists(int id)
        {
            return _context.Gender.Any(e => e.genderId == id);
        }//end function
    }//end class
}//end namespace
