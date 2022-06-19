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

namespace dog7.Controllers
{
    public class SellerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly dog7DbContext _context;

        public SellerController(dog7DbContext context,UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }//end function

        // GET: Seller that is approved to be seller
        public async Task<IActionResult> Index()
        {
            //create new blank list of seller
            var sellers =new List<Seller>();

            //pull data of user that is approved to be seller yet
            var users =  await _context.AppUsers.Where(x=>x.isSeller>0).Select(x=>x).ToListAsync();

            //pull data of all seller
            var result = await _context.Seller
                              .Select(x=>x)
                              .ToListAsync();

            //if seller data is appear in Appuser that it is approved, then add to list
            foreach(var i in users){
                foreach(var j in result){
                    if(i.Id == j.userId){
                        sellers.Add(j);
                    }
                }//eloop
            }//eloop

            //manage data into new format
            var sellers2 = sellers.Select(x=>new {
									sellerId = x.sellerId,
									user = x.user.firstName+" "+x.user.lastName,
									sellerIdCard = x.sellerIdCard,
									sellerIdCardFront = x.sellerIdCardFront,
									sellerIdCardBack = x.sellerIdCardBack,
									selllerBookBankAccountPic = x.selllerBookBankAccountPic,
									sellerFarmRegisterPic = x.sellerFarmRegisterPic,
									// totalPostAvailable = x.totalPostAvailable,
									sellerRegistrationDateTime = x.sellerRegistrationDateTime,
                                    sellerApproveDateTime = x.sellerApproveDateTime
                              }).ToList();
            
            //return into view
            ViewBag.sellers = sellers2;                                              
            return View();
        }//end function

        
 
        // GET: Seller/Create
        public IActionResult Add()
        {
        	//custom queries from FK data table
            ViewBag.users = _context.AppUsers.Select(x=> new {x.Id,value=x.firstName+" "+x.lastName});
            //ViewBag.select_user = ViewBag.users[0];

            return View();
        }//end function

        // POST: Seller/Add
        [HttpPost]
        public async Task<IActionResult> Add(Seller seller)
        {
               try{
                
                //=== file for sellerIdCardFront ===
                var sellerIdCardFront_data = seller.sellerIdCardFront;
                seller.sellerIdCardFront = "";
                

                //=== file for sellerIdCardBack ===
                var sellerIdCardBack_data = seller.sellerIdCardBack;
                seller.sellerIdCardBack = "";
                

                //=== file for selllerBookBankAccountPic ===
                var selllerBookBankAccountPic_data = seller.selllerBookBankAccountPic;
                seller.selllerBookBankAccountPic = "";
                

                //=== file for sellerFarmRegisterPic ===
                var sellerFarmRegisterPic_data = seller.sellerFarmRegisterPic;
                seller.sellerFarmRegisterPic = "";
                
                             
                _context.Add(seller);
                await _context.SaveChangesAsync();
                
                //=== file handling for sellerIdCardFront ===
                if(sellerIdCardFront_data !=null &&sellerIdCardFront_data.Contains("base64"))
                {
                  sellerIdCardFront_data = sellerIdCardFront_data.Split(',')[1];
                  string fileName = seller.sellerId.ToString() + "sellerIdCardFront.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellerIdCardFront_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellerIdCardBack ===
                if(sellerIdCardBack_data !=null &&sellerIdCardBack_data.Contains("base64"))
                {
                  sellerIdCardBack_data = sellerIdCardBack_data.Split(',')[1];
                  string fileName = seller.sellerId.ToString() + "sellerIdCardBack.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellerIdCardBack_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for selllerBookBankAccountPic ===
                if(selllerBookBankAccountPic_data !=null &&selllerBookBankAccountPic_data.Contains("base64"))
                {
                  selllerBookBankAccountPic_data = selllerBookBankAccountPic_data.Split(',')[1];
                  string fileName = seller.sellerId.ToString() + "selllerBookBankAccountPic.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                  var bytess = Convert.FromBase64String(selllerBookBankAccountPic_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellerFarmRegisterPic ===
                if(sellerFarmRegisterPic_data !=null &&sellerFarmRegisterPic_data.Contains("base64"))
                {
                  sellerFarmRegisterPic_data = sellerFarmRegisterPic_data.Split(',')[1];
                  string fileName = seller.sellerId.ToString() + "sellerFarmRegisterPic.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellerFarmRegisterPic_data);
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

        // GET: Seller/Edit/1
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

            var seller = await _context.Seller.FindAsync(id);
            if (seller == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }
            var users = _context.AppUsers.Select(x=> new {x.Id,value=x.firstName+" "+x.lastName});
            ViewBag.users = users;
            ViewBag.select_user = await users.FirstOrDefaultAsync(x=>x.Id == seller.userId);
            
           

             ViewBag.seller = seller;
           
            return View();
        }//end function

        // POST: Seller/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(Seller seller)
        {
             try{
                
                //=== file for sellerIdCardFront ===
                var sellerIdCardFront_data = seller.sellerIdCardFront;
                seller.sellerIdCardFront = "";
                

                //=== file for sellerIdCardBack ===
                var sellerIdCardBack_data = seller.sellerIdCardBack;
                seller.sellerIdCardBack = "";
                

                //=== file for selllerBookBankAccountPic ===
                var selllerBookBankAccountPic_data = seller.selllerBookBankAccountPic;
                seller.selllerBookBankAccountPic = "";
                

                //=== file for sellerFarmRegisterPic ===
                var sellerFarmRegisterPic_data = seller.sellerFarmRegisterPic;
                seller.sellerFarmRegisterPic = "";
                
                               
                _context.Seller.Update(seller);
                await _context.SaveChangesAsync();
                
                //=== file handling for sellerIdCardFront ===
                if(sellerIdCardFront_data !=null &&sellerIdCardFront_data.Contains("base64"))
                {
                  sellerIdCardFront_data = sellerIdCardFront_data.Split(',')[1];
                  string fileName = seller.sellerId.ToString() + "sellerIdCardFront.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellerIdCardFront_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellerIdCardBack ===
                if(sellerIdCardBack_data !=null &&sellerIdCardBack_data.Contains("base64"))
                {
                  sellerIdCardBack_data = sellerIdCardBack_data.Split(',')[1];
                  string fileName = seller.sellerId.ToString() + "sellerIdCardBack.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellerIdCardBack_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for selllerBookBankAccountPic ===
                if(selllerBookBankAccountPic_data !=null &&selllerBookBankAccountPic_data.Contains("base64"))
                {
                  selllerBookBankAccountPic_data = selllerBookBankAccountPic_data.Split(',')[1];
                  string fileName = seller.sellerId.ToString() + "selllerBookBankAccountPic.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                  var bytess = Convert.FromBase64String(selllerBookBankAccountPic_data);
                  using (var imageFile = new FileStream(filePath, FileMode.Create))
                  {
                      imageFile.Write(bytess, 0, bytess.Length);
                      imageFile.Flush();
                  }//end using         
                }//end if

                //=== file handling for sellerFarmRegisterPic ===
                if(sellerFarmRegisterPic_data !=null &&sellerFarmRegisterPic_data.Contains("base64"))
                {
                  sellerFarmRegisterPic_data = sellerFarmRegisterPic_data.Split(',')[1];
                  string fileName = seller.sellerId.ToString() + "sellerFarmRegisterPic.png";
                  string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/sellerRegisterPic/{fileName}");
                  var bytess = Convert.FromBase64String(sellerFarmRegisterPic_data);
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

        // GET: Seller/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _context.Seller
                .FirstOrDefaultAsync(m => m.sellerId == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }//end function

        // POST: Seller/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var seller = await _context.Seller.FindAsync(id);
              if(seller == null){
                  return Ok(new {
                  error =1,
                  msg= "the record was not found"
              });
              }
              _context.Seller.Remove(seller);
              await _context.SaveChangesAsync();
              return Ok(new {
                  error =-1,
                  msg= "the record is deleted"
              });
        }//end function

        private bool SellerExists(int id)
        {
            return _context.Seller.Any(e => e.sellerId == id);
        }//end function
    }//end class
}//end namespace
