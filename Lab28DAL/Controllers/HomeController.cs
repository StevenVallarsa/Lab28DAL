using Lab28DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab28DAL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CardList()
        {
            Deck d;

            if(Session["deck"] == null)
            {
                d = CardAPIDAL.GetNewDeck();
                Session["deck"] = d;
            }
            else
            {
                d = (Deck) Session["deck"];
            }

            Session["deck"] = CardAPIDAL.UpdateDeck(d);

            List<Card> cards = CardAPIDAL.DrawCards(5, d);
            return View(cards);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}