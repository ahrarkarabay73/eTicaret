using b161200020.Entity;
using b161200020.Identity;
using b161200020.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace b161200020.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var UserStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(UserStore);

            var RoleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(RoleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register Model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt İşlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name = Model.Name;
                user.UserSurname = Model.UserSurname;
                user.UserName = Model.UserName;
                user.Email = Model.Email;

                IdentityResult result = UserManager.Create(user, Model.Password);

                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                        
                    }
                    if (RoleManager.RoleExists("admin"))
                    {
                        UserManager.AddToRole(user.Id, "admin");

                    }
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "User Creation Error.");
                }
            }
            return View();
        }


        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login Model)
        {
            if (ModelState.IsValid)
            {
                //Login İşlemleri

                var user = UserManager.Find(Model.UserName, Model.Password);
                if (user != null)
                {
                    //varolan kullanıcıyı sisteme dahil et
                    // applicationCookie oluştur sisteme Bırak
                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var AuthProperties = new AuthenticationProperties();
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    AuthProperties.IsPersistent = Model.UserRemember;
                    authManager.SignIn(AuthProperties, identityclaims);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "There is No Such User.");
                }

            }



            return View();
        }
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }
    }
}