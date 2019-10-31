using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScallopShellProject.Models;
using ScallopShellProject.SessionModel;
using DataProj.Models;

namespace ScallopShellProject.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {



            CheckoutViewModel checkoutView = new CheckoutViewModel();

            var Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            if (Cart == null)
            {
                Cart cartIni = new Cart();

                cartIni.ArticleList = cartIni.ArticleList = new List<Article>();
                HttpContext.Session.SetObjectAsJson("Cart", cartIni);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartIni);


            }

            Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            checkoutView.Cart = Cart;

            return View(checkoutView);
        }
    }
}