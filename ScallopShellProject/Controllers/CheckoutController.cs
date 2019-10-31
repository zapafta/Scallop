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


        public string SaveCheckoutForm(CheckoutViewModel checkout)
        {


            try
            {

                if (string.IsNullOrEmpty(checkout.Cidade))
                {
                    throw new Exception("Preenche a cidade");
                }

                if (string.IsNullOrEmpty(checkout.CodPostal))
                {
                    throw new Exception("Preenche o código postal");
                }


                if (string.IsNullOrEmpty(checkout.Email))
                {
                    throw new Exception("Preenche o email");
                }


                if (string.IsNullOrEmpty(checkout.Morada))
                {
                    throw new Exception("Preenche a morada");
                }


                if (string.IsNullOrEmpty(checkout.Nome))
                {
                    throw new Exception("Preenche o nome");
                }


                if (string.IsNullOrEmpty(checkout.Telefone.ToString()))
                {
                    throw new Exception("Preenche o telefone");
                }





                return "1";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }


    }
}