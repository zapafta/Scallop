using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataProj.Models;
using ScallopShellProject.Models;
using ScallopShellProject.SessionModel;

namespace ScallopShellProject.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {



            CartViewModel cartView = new CartViewModel();

            var Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            if (Cart == null)
            {
                Cart cartIni = new Cart();

                cartIni.ArticleList = cartIni.ArticleList = new List<Article>();
                HttpContext.Session.SetObjectAsJson("Cart", cartIni);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartIni);


            }

            Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            cartView.Cart = Cart;

            return View(cartView);
        }
    }
}