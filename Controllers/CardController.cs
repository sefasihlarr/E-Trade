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

        public ActionResult Order(Order AddOrder)
        {
            var card = GetCard();
            SaveOrder(card, AddOrder);
            card.Clear();
            return RedirectToAction("List","Home");

        }

        private void SaveOrder(Card card, Order addOrder)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(111111, 999999).ToString();
            order.Total = card.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = addOrder.UserName;
            order.Adress = addOrder.Adress;
            order.City = addOrder.City;
            order.District = addOrder.District;
            order.Street = addOrder.Street;
            order.PostCode = addOrder.PostCode;

            order.OrderLines = new List<OrderLine>();

            foreach (var pr in card.CardLines)
            {
                OrderLine orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;

                order.OrderLines.Add(orderline);


            }

            _context.Orders.Add(order);
            _context.SaveChanges();



        }
    }
}