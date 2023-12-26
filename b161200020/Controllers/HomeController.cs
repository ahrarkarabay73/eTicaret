using b161200020.Entity;
using b161200020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace b161200020.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        public DataContext Context { get => _context; set => _context = value; }

        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                ProductName = i.ProductName,
                Description = i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
                Price = i.Price,
                Path = i.Path,
                StockQuantity = i.StockQuantity,
                CategoryId = i.CategoryId
            }).ToList();
            return View(urunler);
        }
        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var urunler = _context.Products.Where(i => i.IsApproved).Select(i => new ProductModel()
            {
                Id=i.Id,
                ProductName=i.ProductName,
                Description=i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
                Price=i.Price,
                Path=i.Path,
                StockQuantity=i.StockQuantity,
                CategoryId=i.CategoryId
            }).AsQueryable();
            if(id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }
            return View(urunler.ToList());
        }
        public PartialViewResult _GetCategory()
        { 
            return PartialView(_context.Categories.ToList());
        }   
    }
}