using E_Trade.MvsWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Trade.MvsWebUI.Controllers
{
    
    public class CategoryController : Controller
    {
        DataContext _contex = new DataContext();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category AddCategory)
        {
            _contex.Categories.Add(AddCategory);
            _contex.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            var _delete = _contex.Categories.Find(id);
            _contex.Categories.Remove(_delete);
            _contex.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Call(int id)
        {
            var _call = _contex.Categories.Find(id);
            return View("Call",_call);
        }
        public ActionResult Update(Category update)
        {
            var _update = _contex.Categories.Find(update.Id);
            _update.Name = update.Name;
            _update.Description = update.Description;
            _contex.SaveChanges();
            return RedirectToAction("List");

        }
        public ActionResult List()
        {
            
            return View(_contex.Categories.ToList());
        }
      
      
    }
}