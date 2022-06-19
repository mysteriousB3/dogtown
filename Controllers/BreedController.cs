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
    public class BreedController : Controller
    {
        private readonly dog7DbContext _context;

        public BreedController(dog7DbContext context)
        {
            _context = context;
        }//end function

        // GET: Breed
        public async Task<IActionResult> Index()
        {
            var result = await _context.Breed
                              .Select(x=>new {
									breedId = x.breedId,
									breedNameThai = x.breedNameThai,
									breedNameEng = x.breedNameEng,
									breedPic = x.breedPic,
									breedDescription = x.breedDescription,
									total = x.total,
                              })
                              .ToListAsync();
            ViewBag.breeds = result;                                              
            return View();
        }//end function
 
        // GET: Breed/Create
        public IActionResult Add()
        {
        	//custom queries from FK data table

            return View();
        }//end function

        // POST: Breed/Add
        [HttpPost]
        public async Task<IActionResult> Add(Breed breed)
        {
               try{
                
                //=== file for breedPic ===
                var breedPic_data = breed.breedPic;
                breed.breedPic = "";
                
                             
                _context.Add(breed);
                await _context.SaveChangesAsync();
                
                //=== file handling for breedPic ===
                if(breedPic_data !=null &&breedPic_data.Contains("base64"))
                {
                  breedPic_data = breedPic_data.Split(',')[1];
                  string fileName = breed.breedId.ToString() + "breedPic.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/dogPic/{fileName}");
                  var bytess = Convert.FromBase64String(breedPic_data);
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

        // GET: Breed/Edit/1
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

            var breed = await _context.Breed.FindAsync(id);
            if (breed == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }

             ViewBag.breed = breed;
           
            return View();
        }//end function

        // POST: Breed/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(Breed breed)
        {
             try{
                
                //=== file for breedPic ===
                var breedPic_data = breed.breedPic;
                breed.breedPic = "";
                
                               
                _context.Breed.Update(breed);
                await _context.SaveChangesAsync();
                
                //=== file handling for breedPic ===
                if(breedPic_data !=null &&breedPic_data.Contains("base64"))
                {
                  breedPic_data = breedPic_data.Split(',')[1];
                  string fileName = breed.breedId.ToString() + "breedPic.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/dogPic/{fileName}");
                  var bytess = Convert.FromBase64String(breedPic_data);
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

        // GET: Breed/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed
                .FirstOrDefaultAsync(m => m.breedId == id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }//end function

        // POST: Breed/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var breed = await _context.Breed.FindAsync(id);
              if(breed == null){
                  return Ok(new {
                  error =1,
                  msg= "the record was not found"
              });
              }
              _context.Breed.Remove(breed);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "the record is deleted"
              });
        }//end function

        private bool BreedExists(int id)
        {
            return _context.Breed.Any(e => e.breedId == id);
        }//end function
    }//end class
}//end namespace
