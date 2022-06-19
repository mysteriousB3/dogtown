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
    public class SellingPostController : Controller
    {
        private readonly dog7DbContext _context;

        public SellingPostController(dog7DbContext context)
        {
            _context = context;
        }//end function

        // GET: SellingPost
        public async Task<IActionResult> Index()
        {
            var result = await _context.SellingPost
                              .Select(x=>new {
									sellingPostId = x.sellingPostId,
									gender = x.gender.genderName,
									breed = x.breed.breedNameEng+" "+x.breed.breedNameThai,
									seller = x.seller.farmName,
									price = x.price,
									sellingPostName = x.sellingPostName,
									sellingPostDescription = x.sellingPostDescription,
									dateOfBirth = x.dateOfBirth,
									pedegree = x.pedegree,
									sellingPostPostingDateTime = x.sellingPostPostingDateTime,
									sellingPostPostExpiredDate = x.sellingPostPostExpiredDate,
									postLike = x.postLike,
									view = x.view,
									sellingPostPic1 = x.sellingPostPic1,
									sellingPostPic2 = x.sellingPostPic2,
									sellingPostPic3 = x.sellingPostPic3,
									sellingPostPic4 = x.sellingPostPic4,
									sellingPostPic5 = x.sellingPostPic5,
									sellingPostPicUpdateDateTime = x.sellingPostPicUpdateDateTime,
                              })
                              .ToListAsync();
            ViewBag.sellingPosts = result;                                              
            return View();
        }//end function
 
        // GET: SellingPost/Create
        public IActionResult Add()
        {
        	//custom queries from FK data table
            ViewBag.genders = _context.Gender.Select(x=> new {x.genderId,value=x.genderName});
            //ViewBag.select_gender = ViewBag.genders[0];
            ViewBag.breeds = _context.Breed.Select(x=> new {x.breedId,value=x.breedNameEng+" "+x.breedNameThai});
            //ViewBag.select_breed = ViewBag.breeds[0];
            ViewBag.sellers = _context.Seller.Select(x=> new {x.sellerId,value=x.farmName});
            //ViewBag.select_seller = ViewBag.sellers[0];

            return View();
        }//end function

        // POST: SellingPost/Add
        [HttpPost]
        public async Task<IActionResult> Add(SellingPost sellingPost)
        {
               try{
                
                //=== file for sellingPostPic1 ===
                var sellingPostPic1_data = sellingPost.sellingPostPic1;
                sellingPost.sellingPostPic1 = "";
                

                //=== file for sellingPostPic2 ===
                var sellingPostPic2_data = sellingPost.sellingPostPic2;
                sellingPost.sellingPostPic2 = "";
                

                //=== file for sellingPostPic3 ===
                var sellingPostPic3_data = sellingPost.sellingPostPic3;
                sellingPost.sellingPostPic3 = "";
                

                //=== file for sellingPostPic4 ===
                var sellingPostPic4_data = sellingPost.sellingPostPic4;
                sellingPost.sellingPostPic4 = "";
                

                //=== file for sellingPostPic5 ===
                var sellingPostPic5_data = sellingPost.sellingPostPic5;
                sellingPost.sellingPostPic5 = "";
                
                             
                _context.Add(sellingPost);
                await _context.SaveChangesAsync();
                
                //=== file handling for sellingPostPic1 ===
                if(sellingPostPic1_data !=null &&sellingPostPic1_data.Contains("base64"))
                {
                  sellingPostPic1_data = sellingPostPic1_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic1.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic1_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellingPostPic2 ===
                if(sellingPostPic2_data !=null &&sellingPostPic2_data.Contains("base64"))
                {
                  sellingPostPic2_data = sellingPostPic2_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic2.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic2_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellingPostPic3 ===
                if(sellingPostPic3_data !=null &&sellingPostPic3_data.Contains("base64"))
                {
                  sellingPostPic3_data = sellingPostPic3_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic3.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic3_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellingPostPic4 ===
                if(sellingPostPic4_data !=null &&sellingPostPic4_data.Contains("base64"))
                {
                  sellingPostPic4_data = sellingPostPic4_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic4.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic4_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellingPostPic5 ===
                if(sellingPostPic5_data !=null &&sellingPostPic5_data.Contains("base64"))
                {
                  sellingPostPic5_data = sellingPostPic5_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic5.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic5_data);
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

        // GET: SellingPost/Edit/1
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

            var sellingPost = await _context.SellingPost.FindAsync(id);
            if (sellingPost == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }
            var genders = _context.Gender.Select(x=> new {x.genderId,value=x.genderName});
            ViewBag.genders = genders;
            ViewBag.select_gender = await genders.FirstOrDefaultAsync(x=>x.genderId == sellingPost.genderId);
            
           
            var breeds = _context.Breed.Select(x=> new {x.breedId,value=x.breedNameEng+" "+x.breedNameThai});
            ViewBag.breeds = breeds;
            ViewBag.select_breed = await breeds.FirstOrDefaultAsync(x=>x.breedId == sellingPost.breedId);
            
           
            var sellers = _context.Seller.Select(x=> new {x.sellerId,value=x.farmName});
            ViewBag.sellers = sellers;
            ViewBag.select_seller = await sellers.FirstOrDefaultAsync(x=>x.sellerId == sellingPost.sellerId);
            
           

             ViewBag.sellingPost = sellingPost;
           
            return View();
        }//end function

        // POST: SellingPost/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(SellingPost sellingPost)
        {
             try{
                
                //=== file for sellingPostPic1 ===
                var sellingPostPic1_data = sellingPost.sellingPostPic1;
                sellingPost.sellingPostPic1 = "";
                

                //=== file for sellingPostPic2 ===
                var sellingPostPic2_data = sellingPost.sellingPostPic2;
                sellingPost.sellingPostPic2 = "";
                

                //=== file for sellingPostPic3 ===
                var sellingPostPic3_data = sellingPost.sellingPostPic3;
                sellingPost.sellingPostPic3 = "";
                

                //=== file for sellingPostPic4 ===
                var sellingPostPic4_data = sellingPost.sellingPostPic4;
                sellingPost.sellingPostPic4 = "";
                

                //=== file for sellingPostPic5 ===
                var sellingPostPic5_data = sellingPost.sellingPostPic5;
                sellingPost.sellingPostPic5 = "";
                
                               
                _context.SellingPost.Update(sellingPost);
                await _context.SaveChangesAsync();
                
                //=== file handling for sellingPostPic1 ===
                if(sellingPostPic1_data !=null &&sellingPostPic1_data.Contains("base64"))
                {
                  sellingPostPic1_data = sellingPostPic1_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic1.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic1_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellingPostPic2 ===
                if(sellingPostPic2_data !=null &&sellingPostPic2_data.Contains("base64"))
                {
                  sellingPostPic2_data = sellingPostPic2_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic2.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic2_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellingPostPic3 ===
                if(sellingPostPic3_data !=null &&sellingPostPic3_data.Contains("base64"))
                {
                  sellingPostPic3_data = sellingPostPic3_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic3.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic3_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellingPostPic4 ===
                if(sellingPostPic4_data !=null &&sellingPostPic4_data.Contains("base64"))
                {
                  sellingPostPic4_data = sellingPostPic4_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic4.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic4_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellingPostPic5 ===
                if(sellingPostPic5_data !=null &&sellingPostPic5_data.Contains("base64"))
                {
                  sellingPostPic5_data = sellingPostPic5_data.Split(',')[1];
                  string fileName = sellingPost.sellingPostId.ToString() + "sellingPostPic5.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellingPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellingPostPic5_data);
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

        // GET: SellingPost/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingPost = await _context.SellingPost
                .FirstOrDefaultAsync(m => m.sellingPostId == id);
            if (sellingPost == null)
            {
                return NotFound();
            }

            return View(sellingPost);
        }//end function

        // POST: SellingPost/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var sellingPost = await _context.SellingPost.FindAsync(id);
              if(sellingPost == null){
                  return Ok(new {
                  error =1,
                  msg= "the record was not found"
              });
              }
              _context.SellingPost.Remove(sellingPost);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "the record is deleted"
              });
        }//end function

        private bool SellingPostExists(int id)
        {
            return _context.SellingPost.Any(e => e.sellingPostId == id);
        }//end function
    }//end class
}//end namespace
