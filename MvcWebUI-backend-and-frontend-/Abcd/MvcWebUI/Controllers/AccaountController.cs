using Microsoft.AspNet.Identity;
using MvcWebUI.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcWebUI.Models;
using Microsoft.Owin.Security;
using MvcWebUI.Entity;

namespace MvcWebUI.Controllers
{
    public class AccaountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccaountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        [Authorize]
        public ActionResult index()
        { var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.Username == username)
                .Select(i => new UserOrderModel()
                {
                    Id= i.Id,
                    OrderNumber=i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total
                }).OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                AdressTitle = i.AdressTitle,
                Adress = i.Adress,
                City = i.City,
                District = i.District,
                ZipCode = i.ZipCode,
                OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                {
                    ProductId = a.ProductId,
                    ProductName = a.Product.Name,
                    Image = a.Product.Image,
                    Quantity = a.Quantity,
                    Price = a.Price
                }).ToList()
            }).FirstOrDefault();
            return View(entity);
        }
        // GET: Accaount
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("User"))
                    {
                        UserManager.AddToRole(user.Id, "User");

                    }
                    return RedirectToAction("Login", "Accaount");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Register Error.");
                }
            }
            return View(model);
        }





        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);

                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememderMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                       return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserEror", "No such user");
                }
            }
            return View(model);
        }



        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}