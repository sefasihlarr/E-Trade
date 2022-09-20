using E_Trade.MvsWebUI.Entity;
using E_Trade.MvsWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Trade.MvsWebUI.Controllers
{
    public class CardController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Card
        public ActionResult Index()
        {
            return View(GetCard());
        }
        public ActionResult AddToCard(int id)
        {
            var product = _context.Products.Where(i => i.Id == id).FirstOrDefault();
            if (product != null)
            {
                GetCard().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCard(int id)
        {
            var product = _context.Products.Where(i => i.Id == id).FirstOrDefault();
            if (product != null)
            {
                GetCard().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }

        public Card GetCard()
        {
            var card = (Card)Session["Card"];
            if (card == null)
            {
                card = new Card();
                Session["Card"] = card;

            }
            return card;

        }
    }
}