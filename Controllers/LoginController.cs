using System.Linq;
using System.Web.Mvc;
using SMS.Web.Models;
using SMS.Web.Repository;
using System.Web;
using SMS.Web.Services;
using System;

namespace SMS.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly SMSEntity _context;

        public LoginController()
        {
            _context = new SMSEntity();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            var user = _context.TblUsers.FirstOrDefault(u => u.UserName == userModel.UserName && u.Password == userModel.Password);
            if (user != null)
            {
                var role = "User"; 
                var jwtToken = Authentication.GenerateJWTAuthetication(user.UserName, role);

                var cookie = new HttpCookie("jwt", jwtToken)
                {
                    HttpOnly = true,
                };
                Response.Cookies.Add(cookie);

                Session["UserId"] = user.Id;
                Session["UserName"] = user.UserName;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid username or password.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            if (Request.Cookies["jwt"] != null)
            {
                var cookie = new HttpCookie("jwt")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Login");
        }
    }
}
