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
    public class SellerFeedPostController : Controller
    {
        private readonly dog7DbContext _context;

        public SellerFeedPostController(dog7DbContext context)
        {
            _context = context;
        }//end function

        // GET: SellerFeedPost
        public async Task<IActionResult> Index()
        {
            var result = await _context.SellerFeedPost
                              .Select(x=>new {
									sellerFeedPostId = x.sellerFeedPostId,
									seller = x.seller.sellerId,
									feedPostPic1 = x.feedPostPic1,
									feedPostPic2 = x.feedPostPic2,
									feedPostPic3 = x.feedPostPic3,
									feedPostPic4 = x.feedPostPic4,
									feedPostPic5 = x.feedPostPic5,
									postingDateTime = x.postingDateTime,
									description = x.description,
                              })
                              .ToListAsync();
            ViewBag.sellerFeedPosts = result;                                              
            return View();
        }//end function
 
        // GET: SellerFeedPost/Create
        public IActionResult Add()
        {
        	//custom queries from FK data table
            ViewBag.sellers = _context.Seller.Select(x=> new {x.sellerId,value=x.sellerId});
            //ViewBag.select_seller = ViewBag.sellers[0];

            return View();
        }//end function

        // POST: SellerFeedPost/Add
        [HttpPost]
        public async Task<IActionResult> Add(SellerFeedPost sellerFeedPost)
        {
               try{
                
                //=== file for feedPostPic1 ===
                var feedPostPic1_data = sellerFeedPost.feedPostPic1;
                sellerFeedPost.feedPostPic1 = "";
                

                //=== file for feedPostPic2 ===
                var feedPostPic2_data = sellerFeedPost.feedPostPic2;
                sellerFeedPost.feedPostPic2 = "";
                

                //=== file for feedPostPic3 ===
                var feedPostPic3_data = sellerFeedPost.feedPostPic3;
                sellerFeedPost.feedPostPic3 = "";
                

                //=== file for feedPostPic4 ===
                var feedPostPic4_data = sellerFeedPost.feedPostPic4;
                sellerFeedPost.feedPostPic4 = "";
                

                //=== file for feedPostPic5 ===
                var feedPostPic5_data = sellerFeedPost.feedPostPic5;
                sellerFeedPost.feedPostPic5 = "";
                
                             
                _context.Add(sellerFeedPost);
                await _context.SaveChangesAsync();
                
                //=== file handling for feedPostPic1 ===
                if(feedPostPic1_data !=null &&feedPostPic1_data.Contains("base64"))
                {
                  feedPostPic1_data = feedPostPic1_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic1.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic1_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for feedPostPic2 ===
                if(feedPostPic2_data !=null &&feedPostPic2_data.Contains("base64"))
                {
                  feedPostPic2_data = feedPostPic2_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic2.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic2_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for feedPostPic3 ===
                if(feedPostPic3_data !=null &&feedPostPic3_data.Contains("base64"))
                {
                  feedPostPic3_data = feedPostPic3_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic3.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic3_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for feedPostPic4 ===
                if(feedPostPic4_data !=null &&feedPostPic4_data.Contains("base64"))
                {
                  feedPostPic4_data = feedPostPic4_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic4.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic4_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for feedPostPic5 ===
                if(feedPostPic5_data !=null &&feedPostPic5_data.Contains("base64"))
                {
                  feedPostPic5_data = feedPostPic5_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic5.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic5_data);
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

        // GET: SellerFeedPost/Edit/1
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

            var sellerFeedPost = await _context.SellerFeedPost.FindAsync(id);
            if (sellerFeedPost == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }
            var sellers = _context.Seller.Select(x=> new {x.sellerId,value=x.sellerId});
            ViewBag.sellers = sellers;
            ViewBag.select_seller = await sellers.FirstOrDefaultAsync(x=>x.sellerId == sellerFeedPost.sellerId);
            
           

             ViewBag.sellerFeedPost = sellerFeedPost;
           
            return View();
        }//end function

        // POST: SellerFeedPost/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(SellerFeedPost sellerFeedPost)
        {
             try{
                
                //=== file for feedPostPic1 ===
                var feedPostPic1_data = sellerFeedPost.feedPostPic1;
                sellerFeedPost.feedPostPic1 = "";
                

                //=== file for feedPostPic2 ===
                var feedPostPic2_data = sellerFeedPost.feedPostPic2;
                sellerFeedPost.feedPostPic2 = "";
                

                //=== file for feedPostPic3 ===
                var feedPostPic3_data = sellerFeedPost.feedPostPic3;
                sellerFeedPost.feedPostPic3 = "";
                

                //=== file for feedPostPic4 ===
                var feedPostPic4_data = sellerFeedPost.feedPostPic4;
                sellerFeedPost.feedPostPic4 = "";
                

                //=== file for feedPostPic5 ===
                var feedPostPic5_data = sellerFeedPost.feedPostPic5;
                sellerFeedPost.feedPostPic5 = "";
                
                               
                _context.SellerFeedPost.Update(sellerFeedPost);
                await _context.SaveChangesAsync();
                
                //=== file handling for feedPostPic1 ===
                if(feedPostPic1_data !=null &&feedPostPic1_data.Contains("base64"))
                {
                  feedPostPic1_data = feedPostPic1_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic1.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic1_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for feedPostPic2 ===
                if(feedPostPic2_data !=null &&feedPostPic2_data.Contains("base64"))
                {
                  feedPostPic2_data = feedPostPic2_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic2.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic2_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for feedPostPic3 ===
                if(feedPostPic3_data !=null &&feedPostPic3_data.Contains("base64"))
                {
                  feedPostPic3_data = feedPostPic3_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic3.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic3_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for feedPostPic4 ===
                if(feedPostPic4_data !=null &&feedPostPic4_data.Contains("base64"))
                {
                  feedPostPic4_data = feedPostPic4_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic4.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic4_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for feedPostPic5 ===
                if(feedPostPic5_data !=null &&feedPostPic5_data.Contains("base64"))
                {
                  feedPostPic5_data = feedPostPic5_data.Split(',')[1];
                  string fileName = sellerFeedPost.sellerFeedPostId.ToString() + "feedPostPic5.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/feedPostPic/{fileName}");
                  var bytess = Convert.FromBase64String(feedPostPic5_data);
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

        // GET: SellerFeedPost/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerFeedPost = await _context.SellerFeedPost
                .FirstOrDefaultAsync(m => m.sellerFeedPostId == id);
            if (sellerFeedPost == null)
            {
                return NotFound();
            }

            return View(sellerFeedPost);
        }//end function

        // POST: SellerFeedPost/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var sellerFeedPost = await _context.SellerFeedPost.FindAsync(id);
              if(sellerFeedPost == null){
                  return Ok(new {
                  error =1,
                  msg= "the record was not found"
              });
              }
              _context.SellerFeedPost.Remove(sellerFeedPost);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "the record is deleted"
              });
        }//end function

        private bool SellerFeedPostExists(int id)
        {
            return _context.SellerFeedPost.Any(e => e.sellerFeedPostId == id);
        }//end function
    }//end class
}//end namespace
