using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebUI.Entity;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var urunler = context.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
Id = i.Id,
Name = i.Name,
Description = i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
Price = i.Price,
Stock = i.Stock,
Image = i.Image==null? "default-image.jpg":i.Image,
CategoryId = i.CategoryId
            }).ToList();

            return View(urunler);
        }

        public ActionResult Details(int id)
        {
           

            return View(context.Products.Where(i => i.Id==id).FirstOrDefault());
        }

        public ActionResult List()
        {
            var urunler = context.Products.Where(i =>  i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length > 30 ? i.Name.Substring(0, 27) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image==null? "default-image.jpg":i.Image,
                CategoryId = i.CategoryId
            }).ToList();

            return View (urunler);
        }
    }
}