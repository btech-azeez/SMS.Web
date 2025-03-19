using System;
using System.Linq;
using System.Web.Mvc;
using SMS.Web.Models;
using SMS.Web.Repository;
using System.Web;
using System.Net;
using Nest;
using SMS.Web.Services;
using Authentication = SMS.Web.Services.Authentication;

namespace SMS.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly SMSEntity _context;

        public UserController()
        {
            _context = new SMSEntity();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SignUp()
        {
            UserModel userModel = new UserModel();
            return View(userModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp(UserModel userModel)
        {
            TblUser  tblUser = new TblUser
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = userModel.Password,
                Gender = userModel.Gender
            };
            _context.TblUsers.Add(tblUser);
            _context.SaveChanges();
            ViewBag.Message = "Successfully Data Saved";
            ModelState.Clear();
            return View(new UserModel());
        }

        [JwtAuthentication]
        public ActionResult Index()
        {
            return View();
        }

        [JwtAuthentication]
        [HttpGet]
        public ActionResult GetUsers(int page = 1, string searchTerm = "")
        {
            const int pageSize = 5; // Number of users per page

            var usersQuery = _context.TblUsers.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                usersQuery = usersQuery.Where(u => u.FirstName.Contains(searchTerm) || u.LastName.Contains(searchTerm) || u.Email.Contains(searchTerm));
            }

            int totalUsers = usersQuery.Count();
            int totalPages = (int)Math.Ceiling(totalUsers / (double)pageSize);

            var users = usersQuery
                .OrderBy(u => u.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var userModels = users.Select(u => new UserModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                Gender = u.Gender,
                CreatedOn = u.CreatedOn,
                IsDeleted = u.IsDeleted
            }).ToList();

            var model = new PaginationModel
            {
                CurrentPage = page,
                PerPage = pageSize,
                Result = userModels,
                TotalPages = totalPages
            };

            ViewBag.CurrentFilter = searchTerm;

            return View(model);
        }

        [JwtAuthentication]
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var user = _context.TblUsers.FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                return HttpNotFound();
            }

            UserModel userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Gender = user.Gender,
                IsDeleted = user.IsDeleted,
                CreatedOn = user.CreatedOn
            };

            return View(userModel);
        }

        [JwtAuthentication]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var user = _context.TblUsers.FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                return HttpNotFound();
            }

            UserModel userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Gender = user.Gender,
                UpdatedOn = DateTime.Now
            };

            return View(userModel);
        }

        [JwtAuthentication]
        [HttpPost]
        public ActionResult Edit(UserModel userModel)
        {
            var user = _context.TblUsers.FirstOrDefault(x => x.Id == userModel.Id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
            user.Gender = userModel.Gender;
            user.UpdatedOn = DateTime.Now;

            _context.SaveChanges();

            ViewBag.Message = "Data Updated Successfully";
            return View(new UserModel());
        }

        [JwtAuthentication]
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var user = _context.TblUsers.FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                return HttpNotFound();
            }

            UserModel userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Gender = user.Gender,
                IsDeleted = user.IsDeleted,
                CreatedOn = user.CreatedOn
            };

            return View(userModel);
        }

        [JwtAuthentication]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var user = _context.TblUsers.FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                return HttpNotFound();
            }

            _context.TblUsers.Remove(user);
            _context.SaveChanges();

            ViewBag.Message = "Deleted Successfully";
            return RedirectToAction("GetUsers");
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["jwt"] != null)
            {
                var cookie = new HttpCookie("jwt")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }

            Session.Clear();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
