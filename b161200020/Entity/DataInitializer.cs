using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace b161200020.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> kategoriler = new List<Category>() 
            {
                new Category(){Name = "Kask", Description= "Kasklar"},
                new Category(){Name = "Dişlik", Description= "Dişlikler"},
                new Category(){Name = "Pant", Description= "Pantlar"},
                new Category(){Name = "Jersey", Description= "Jerseyler"},
                new Category(){Name = "Jaw Pad", Description= "Jaw Padler"},
                new Category(){Name = "Pro Combat", Description= "Pro Combatlar"},
                new Category(){Name = "Eldiven", Description= "Edivenler"},
                new Category(){Name = "Top", Description= "Toplar"}

            };
            foreach (var kategori in kategoriler) 
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            List<Product> urunler = new List<Product>()
            {
                new Product(){ProductName = "Riddell Speed Flex", Description = "M,L" , Path="theme/img/speed-flex.png", Price = 3500, StockQuantity = 5 , IsApproved = true , CategoryId=1 , IsHome = true},
                new Product(){ProductName = "Schutt Air", Description = "M,L" , Path="theme/img/schutt.png", Price = 2200, StockQuantity = 5 , IsApproved = true , CategoryId=1 , IsHome = true},
                new Product(){ProductName = "Rawlings", Description = "M,L" , Path="theme/img/rawlings.jpg", Price = 1200, StockQuantity = 5 , IsApproved = true , CategoryId=1 , IsHome = true},

                new Product(){ProductName = "X Company Mouth Guard", Description = "One Size" , Path = "theme/img/x.png", Price =1200, StockQuantity = 5 , IsApproved = true , CategoryId=2 , IsHome = true},
                new Product(){ProductName = "Y Company Mouth Guard", Description = "One Size" , Path = "theme/img/y.png", Price =1200, StockQuantity = 5 , IsApproved = true , CategoryId=2 , IsHome = true},
                new Product(){ProductName = "Z Company Mouth Guard", Description = "One Size" , Path = "theme/img/z.png", Price =1200, StockQuantity = 5 , IsApproved = true , CategoryId=2},

                new Product(){ProductName = "Football Jersey", Description = "XXL" , Path = "theme/img/jersey.png", Price =1200, StockQuantity = 5 , IsApproved = true , CategoryId=3 , IsHome = true},

                new Product(){ProductName = "Schutt Jaw Pad", Description = "One Size" , Path = "theme/img/jaw-pad.png", Price =40, StockQuantity = 5 , IsApproved = true , CategoryId=4 , IsHome = true},

                new Product(){ProductName = "Pro Combad 5 Pads", Description = "L" , Path = "theme/img/procombat.jpg", Price =100, StockQuantity = 5 , IsApproved = true , CategoryId=5 , IsHome = true},

                new Product(){ProductName = "Line Man Gloves", Description = "XL" , Path = "theme/img/gloves-l.png", Price =120, StockQuantity = 5 , IsApproved = true , CategoryId=6 , IsHome = true},
                new Product(){ProductName = "Line Man Gloves", Description = "XL" , Path = "theme/img/gloves-r.png", Price =120, StockQuantity = 5 , IsApproved = true , CategoryId=6 , IsHome = true},

                new Product(){ProductName = "Wilson 1005 Game Ball", Description = "One Size" , Path = "theme/img/ball-g.png", Price =800, StockQuantity = 5 , IsApproved = true , CategoryId=7 , IsHome = true},
                new Product(){ProductName = "Wilson NFL Ball", Description = "One Size" , Path = "theme/img/ball-p.png", Price =100, StockQuantity = 5 , IsApproved = true , CategoryId=7}

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