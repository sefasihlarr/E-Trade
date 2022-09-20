using E_Trade.MvsWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Trade.MvsWebUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Home

        public ActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        [Authorize]
        public ActionResult Details(int id)
        {
             
                return View(_context.Products.Where(i => i.Id == id).FirstOrDefault());
      
        }

        [Authorize]
        public ActionResult List(int? id)
        {
            
            
            if (id != null)
            {
            
                return View(_context.Products.Where(i => i.CategoryId == id).ToList());
            }
            else
            {
                return View(_context.Products.ToList());
            }

            
        }
        [Authorize]
        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }

        public PartialViewResult GetProducts()
        {
            return PartialView(_context.Products.ToList());
        }
    }
}