using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcWebUI.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category> {
new Category(){Name= "Camera", Description="Camera Products"},
new Category(){Name= "Computer", Description="Computer Products"},
new Category(){Name= "Electronic", Description="Electronic Products"},
new Category(){Name= "Phone", Description="Phone Products"},
new Category(){Name= "Furniture", Description="Furniture Products"}
};

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();



            var urunler = new List<Product> {
new Product(){Name= "Xiaomi Redmi Note 8 64 GB ", Description="Guaranteed", Price= 350, Stock= 89, IsApproved= true, CategoryId=4, IsHome=true, Image="Xiaomi Redmi Note 8 64 GB.jpg"},
new Product(){Name= "Samsung Galaxy A51 2020 128 GB ", Description="Guaranteed", Price= 200, Stock= 40, IsApproved= true, CategoryId=4, IsHome=true, Image="Samsung Galaxy A51 2020 128 GB.jpg"},
new Product(){Name= "Xiaomi Redmi Note 8 Pro 128 GB ", Description="Guaranteed", Price= 380, Stock= 120, IsApproved= true, CategoryId=4, IsHome=true, Image="Xiaomi Redmi Note 8 64 GB.jpg"},
new Product(){Name= " Samsung Galaxy A51 DS (SM-A515) 128GB White ", Description="Guaranteed", Price= 299, Stock= 35, IsApproved= true, CategoryId=4, IsHome=true, Image="Samsung Galaxy A51 2020 128 GB.jpg"},
new Product(){Name= " Samsung Galaxy Fold SM-F900F black ", Description="Guaranteed", Price= 750, Stock= 10, IsApproved= true, CategoryId=4, IsHome=true, Image="Samsung Galaxy Fold SM-F900F black.jpg"},


new Product(){Name= "Canon EOS 2000D Kit 18-55 ", Description="Guaranteed", Price= 400, Stock= 52, IsApproved= true, CategoryId= 1, IsHome=true, Image="Canon EOS 2000D Kit 18-55.jpg"},
new Product(){Name= "CANON EOS 800D EF-S 18-55 IS STM Kit" , Description="Guaranteed", Price= 649, Stock= 80, IsApproved= true, CategoryId= 1, IsHome=true, Image="800D.jpg"},
new Product(){Name= "Canon EOS 4000D Kit 18-55 ", Description="Guaranteed", Price= 500, Stock= 78, IsApproved= true, CategoryId=1, IsHome=true, Image="4000D.jpg" },
new Product(){Name= "Canon EOS 800D EF-S 18-135 IS STM Kit ", Description="Guaranteed", Price= 700, Stock= 35, IsApproved= true, CategoryId=1, IsHome=true, Image="800D.jpg" },
new Product(){Name= "Nikon D5600 18-55 ", Description="Guaranteed", Price= 300, Stock= 46, IsApproved= true, CategoryId= 1, IsHome=true, Image="5600d.jpg"}

};

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();




            base.Seed(context);
        }
    }
}