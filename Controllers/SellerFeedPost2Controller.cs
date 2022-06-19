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

namespace dog7.Controllers
{
    public class SellerFeedPost2Controller : Controller
    {
        private readonly dog7DbContext _context;

        public SellerFeedPost2Controller(dog7DbContext context)
        {
            _context = context;
        }//end function      
 
        

        // POST: SellerFeedPost/Add
        [HttpPost]
        public async Task<IActionResult> Add(SellerFeedPost sellerFeedPost)
        {
            sellerFeedPost.postingDateTime = DateTime.Now;
            
               try{
                sellerFeedPost.postingDateTime = DateTime.Now;
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
        [HttpPost]
        public async Task<IActionResult> Delete(SellerFeedPost sellerFeedPost2)
        {          
            var sellerFeedPost = await _context.SellerFeedPost.FindAsync(sellerFeedPost2.sellerFeedPostId);
              if(sellerFeedPost == null){
                  return Ok(new {
                  error =1,
                  msg= "ไม่พบไอดี"
              });
              }
              _context.SellerFeedPost.Remove(sellerFeedPost);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "ลบแล้ว"
              });
        }//end function
        
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

        
    }//end class
}//end namespace
