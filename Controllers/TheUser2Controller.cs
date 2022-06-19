using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dog7.Data;
using dog7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dog7.Controllers{
    public class TheUser2Controller:Controller{
        private dog7DbContext _context;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public TheUser2Controller(SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,
                                    dog7DbContext context, RoleManager<AppRole> roleManager){
            _context= context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }//econstructor

        [Authorize]
        public async Task<IActionResult> Index(int? id){
            var user = await _userManager.GetUserAsync(User);
            var user2 = await _context.AppUsers.Where(x=>x.Id == user.Id).Select(x=> new{
                id = x.Id,
                firstName = x.firstName,
                lastName  = x.lastName,
                email = x.Email,
                phoneNumber = x.PhoneNumber,
                editInfoDateTime = x.editInfoDateTime,
                editInfoMemo = x.editInfoMemo,
                editPasswordDateTime = x.editPasswordDateTime

            }).ToListAsync();
            ViewBag.today = DateTime.Now;
            
            ViewBag.user = user2[0];
            return View();
        }//ef
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmInfo(ChangeInfo info){
            
            var user = await _userManager.FindByIdAsync(info.id.ToString());
            user.Email = info.email;
            user.editInfoMemo = info.editInfoMemo;
            user.editInfoDateTime = DateTime.Now;
            user.PhoneNumber = info.phoneNumber;
            user.firstName = info.firstName;
            user.lastName = info.lastName;
            await _userManager.UpdateAsync(user);
            return Json(new{
                error=-1,
                message="แก้ไข้ข้อมูลเรียบร้อย"
            });
        }//ef
        
        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword(int? id){
            if(id == null){
                Redirect("/home");
            }//econ
            var editPasswordDateTime  = _context.AppUsers.Where(x=> x.Id == id).Select(x=>new{
                editPasswordDateTime = x.editPasswordDateTime,
                today = DateTime.Now
            });
            ViewBag.editPasswordDateTime = editPasswordDateTime;
            ViewBag.id = id;
            return View();
        }//ef
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword info){
            if(info == null){
                return Json(new{
                    error=1,
                    message="ข้อมูลไม่มา"
                });
            }//econ
            var user = await _userManager.FindByIdAsync(info.id.ToString());
            var result = await _userManager.ChangePasswordAsync(user,info.currentPassword,info.newPassword);
            if(!result.Succeeded){
                return Json(new{
                    error=1,
                    message="รหัสผ่านเก่าไม่ถูกต้อง"
                });
            }//econ
            //update date time of changing password of user
            user.editPasswordDateTime=DateTime.Now;
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            return Json(new{
                    error=-1,
                    message="YES"
                });
            

        }//ef



    }//ec

    public class ChangeInfo{
        public int id {get;set;}
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string phoneNumber {get;set;}
        public string email {get;set;}
        public string editInfoMemo{get;set;}

    }//ec
    public class ChangePassword{
        public int id {get;set;}
        public string currentPassword{get;set;}
        public string newPassword{get;set;}
    }//ec
}//en