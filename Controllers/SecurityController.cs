using System.Threading.Tasks;
using dog7.Data;
using dog7.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Linq;
using dog7.Models;
using System;

namespace dog7.Controllers
{


    public class SecurityController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly dog7DbContext _db;
        private readonly RoleManager<AppRole> _roleManager;

        public SecurityController(   SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,
                                    dog7DbContext db, RoleManager<AppRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;

        }//ef

        [HttpGet]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.error = false;
            return View();
        }

        public IActionResult Manage()
        {
            return View("manage");
        }
        public async Task<IActionResult> Login(SignInModel input, string ReturnUrl)
        {
            if(input.email==null || input.password==null){
                ViewBag.error = true;
                ViewBag.message = "ข้อมูลไม่ครบถ้วน กรุณากรอกตรวจสอบความสมบูรณ์ของข้อมูล";
                return View("login");
            }

            var result = await _signInManager.PasswordSignInAsync(input.email, input.password, input.rememberMe, lockoutOnFailure: true);
            var user = await _signInManager.UserManager.FindByEmailAsync(input.email);
            if (result.Succeeded)
            {
                if (ReturnUrl != null)
                {
                    return LocalRedirect(ReturnUrl);
                }

                if(user.otp==-1){
                    ViewBag.error = true;
                    ViewBag.message = "อีเมลหรือรหัสผ่านไม่ถูกต้อง";
                    return View("login");
                }
                var role = _userManager.GetRolesAsync(user).Result[0];
                if(role == "admin"){
                    return RedirectToAction("Index","Admin");
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.error = true;
            ViewBag.message = "อีเมลหรือรหัสผ่านไม่ถูกต้อง";
            return View("login");




        }//ef


        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewBag.error = false;
            ViewBag.msg = "";

            ViewData["Id"] = new SelectList(_db.AppUsers, "Id", "firstName");

            return View("changepassword");
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {

            if (model.password1 != model.password2)
            {
                ViewBag.error = true;
                ViewBag.msg = "New Password and Confirm Password do not match, please try again";

                ViewData["Id"] = new SelectList(_db.AppUsers, "Id", "FirstName");

                return View("ChangePassword", model);
            }
            else
            {
                var user = await _userManager.FindByIdAsync(model.userId);
                if (user == null)
                {
                    return Content("user not found");
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, token, model.password1);
                if (result.Succeeded)
                {

                    ViewBag.message = "Password for " + user.firstName + " " + user.lastName + "has been changed";
                    return View("PCSuccess");
                }
                else
                {
                    ViewBag.error = true;
                    ViewBag.msg = "SERVERY BUSY, please try again";
                    ViewData["Id"] = new SelectList(_db.AppUsers, "Id", "Name");

                    return View("ChangePassword", model);

                }
            }

        }//ef

        [HttpGet]
        public IActionResult EnableAccount()
        {
              ViewData["Id"] = new SelectList(_db.AppUsers, "Id", "firstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnableAccount(ChangePasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.userId);
            await _userManager.SetLockoutEndDateAsync(user, null);
            ViewBag.message = "login account for " + user.firstName + " " + user.lastName + " is enabled";
            return View("PCSuccess");

        }

        [HttpGet]
        public IActionResult Register(){
            return View();
        }//ef

        [HttpPost]
        public async Task<IActionResult> Register(TheUser theUser){
            theUser.userRegistrationDateTime = System.DateTime.Now;
            
            //step1
            //check whether it is duplicated or not       
            if(_userManager.Users.All(x=>x.UserName != theUser.Email)){
                
                //step2
                //create new AppUser object
                var newUser = new AppUser{
                    firstName = theUser.firstName,
                    lastName = theUser.lastName,
                    Email = theUser.Email,
                    userRegistrationDateTime = theUser.userRegistrationDateTime,
                    isSeller = 0,
                    otp = 12345,
                    UserName =theUser.Email,
                    PhoneNumber=theUser.PhoneNumber   
                };
                //step3 create AppUser, we have to supply newUser object and password 2 thins!!
                await _userManager.CreateAsync(newUser,theUser.password);

                //step4 after we created new AppUser we have to query it back
                //then we can add check and add role
                newUser = await _userManager.FindByEmailAsync(theUser.Email);
                
                if(!await _userManager.IsInRoleAsync(newUser,"user")){
                    await _userManager.AddToRoleAsync(newUser,"user");
                };
                
                return Ok("Okay");
            }
            else{
                return Ok("อีเมลซ้ำ กรุณาลองชื่ออื่นค่ะ");
            }//econ
        }//ef
        
        public async Task<IActionResult> Logout(){
            await _signInManager.SignOutAsync();
            return Redirect("/home");
        }
        public async Task<IActionResult> test(){
            // var theTest = await _userManager.FindByEmailAsync("root@localhost.com");
            // theTest.isSeller=0;
            // await _userManager.UpdateAsync(theTest);
            // return Ok("updated");

            var theTest = await _userManager.FindByEmailAsync("root@localhost.com");
            var role = await _userManager.GetRolesAsync(theTest);
            var test = role[0];
            
            
            return Ok(test);
        }



    }//ec
}//en