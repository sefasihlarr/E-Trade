using E_Trade.MvsWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Trade.MvsWebUI.Controllers
{
    public class AccountController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var users = _context.Users.FirstOrDefault(i=> i.Email == user.Email && i.Password == user.Password);
            if (user !=null)
            {
                FormsAuthentication.SetAuthCookie(users.Email, false);
                Session["Mail"] = users.Email.ToString();
                Session["Name"] = users.Name.ToString();
                Session["Password"] = users.Password.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Email or Password Error";

            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User CreateUser)
        {
            var test = _context.Users.Where(i => i.RoleId == CreateUser.Role.Id);
            
            if (test != null)
            {
                CreateUser.RoleId = Convert.ToInt32("1");
                _context.Users.Add(CreateUser);
                _context.SaveChanges();
                TempData["LoginSucces"] = "Succes Created";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                TempData["LoginError"] = "Dont Created";

            }

            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login" , "Account");
        }
    }
}