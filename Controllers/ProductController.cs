using E_Trade.MvsWebUI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Trade.MvsWebUI.Controllers
{
    public class ProductController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Product
        [Authorize]
        public ActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Obsolete]
        public ActionResult Create(Product CreateProduct)
        {
            var categoriler = _context.Categories.ToList();
            if (Request.Files.Count > 0)
            {
                string FileName = Path.GetFileName(Request.Files[0].FileName);
                string Extension = Path.GetExtension(Request.Files[0].FileName);
                string Way = "~/Theme/img/"+ FileName + Extension;
                Request.Files[0].SaveAs(Server.MapPath(Way));
                CreateProduct.PictureUrl = "/Theme/img/" + FileName + Extension;

            }
            var test = CreateProduct.Category.Name;

            
            foreach (var item in categoriler)
            {
                if (item.Name == test)
                {
                    CreateProduct.Category = _context.Categories.Where(i => i.Name == test).FirstOrDefault();
                    _context.Products.Add(CreateProduct);
                    _context.SaveChanges();
                    TempData["AlertMessage"] = "Product Creaded SuccesFully...!";
                }
                else
                {

                    TempData["ErrorMessage"] = "The product could not be added because there is no such category...!!!";

                }
            }
          
            return RedirectToAction("Create");
        }
        
        public ActionResult Delete(int id)
        {
            var delete = _context.Products.Find(id);
            _context.Products.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Call(int id)
        {
            var _call = _context.Products.Find(id);
            return View("Call", _call);
        }
        
        public ActionResult Update(Product UpdateId)
        {
            var _update = _context.Products.Find(UpdateId.Id);
            _update.Name = UpdateId.Name;
            _update.Description = UpdateId.Description;
            _update.Stock = UpdateId.Stock;
            _update.Category.Name = UpdateId.Category.Name;
            _update.IsApproved = UpdateId.IsApproved;
            _update.Price = UpdateId.Price;
            _update.PictureUrl = UpdateId.PictureUrl;
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}