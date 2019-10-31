using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using ScallopShellProject.Models;
using ScallopShellProject.SessionModel;

namespace ScallopShellProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ArticleRepository _articleRepository;
        [TempData]
        public string Message { get; set; }


        public HomeController(ArticleRepository articleRepository)


        {
            _articleRepository = articleRepository;

        }


        public IActionResult Index()
        {
            IndexViewModel index = new IndexViewModel();
     

        index.Articles = _articleRepository.GetArticles();




            var Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            if (Cart==null)
            {
                Cart cartIni = new Cart();

                cartIni.ArticleList = new List<Article>();
                HttpContext.Session.SetObjectAsJson("Cart", cartIni);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartIni);


            }

            Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            index.Cart = Cart;


            return View(index);
        }


    

        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            option.IsEssential = true;
            option.HttpOnly = false;
            option.Expires = DateTime.Now.AddMonths(1);

            Response.Cookies.Append(key, value, option);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
