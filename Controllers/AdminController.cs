using E_Trade.MvsWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Trade.MvsWebUI.Controllers
{
    public class AdminController : Controller
    {
        DataContext _conntext = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View(_conntext.Products.ToList());
        }
    }
}