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
using Microsoft.AspNetCore.Authorization;

namespace dog7.Controllers
{
    [Authorize(Roles = "admin")]
    public class TheUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly dog7DbContext _context;

        public TheUserController(dog7DbContext context,UserManager<AppUser> userManager)
        {   
            _userManager = userManager;
            _context = context;
        }//end function

        // GET: TheUser
        public async Task<IActionResult> Index()
        {
            var result = await _context.AppUsers
                              .Select(x=>new {
									userId = x.Id,
									firstName = x.firstName,
									lastName = x.lastName,
									PhoneNumber = x.PhoneNumber,
									Email = x.Email,
									userRegistrationDateTime = x.userRegistrationDateTime,
									otp = x.otp,
									isSeller = x.isSeller,
                              })
                              .ToListAsync();
            ViewBag.theUsers = result;
            return View();
        }//end function
 
        // GET: TheUser/Create
        public IActionResult Add()
        {
        	//custom queries from FK data table

            return View();
        }//end function

        // POST: TheUser/Add
        [HttpPost]
        public async Task<IActionResult> Add(TheUser theUser)
        {
               try{
                                             
                _context.Add(theUser);
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

        // GET: TheUser/Edit/1
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

            var theUser = await _context.AppUsers.FindAsync(id);
            if (theUser == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }

             ViewBag.theUser = theUser;
           
            return View();
        }//end function

        // POST: TheUser/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(TheUser theUser)
        {
             try{
                                               
                _context.TheUser.Update(theUser);
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

        // GET: TheUser/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theUser = await _context.TheUser
                .FirstOrDefaultAsync(m => m.userId == id);
            if (theUser == null)
            {
                return NotFound();
            }

            return View(theUser);
        }//end function

        // POST: TheUser/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var theUser = await _context.TheUser.FindAsync(id);
              if(theUser == null){
                  return Ok(new {
                  error =1,
                  msg= "the record was not found"
              });
              }
              _context.TheUser.Remove(theUser);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "the record is deleted"
              });
        }//end function

        private bool TheUserExists(int id)
        {
            return _context.TheUser.Any(e => e.userId == id);
        }//end function
    }//end class
}//end namespace
