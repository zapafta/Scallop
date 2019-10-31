using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProj.Models;
using Microsoft.AspNetCore.Mvc;
using ScallopShellProject.Models;
using ScallopShellProject.SessionModel;

namespace ScallopShellProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly ArticleRepository _articleRepository;
        private readonly CategoryRepository _categoryRepository;

        public ShopController(ArticleRepository articleRepository, CategoryRepository categoryRepository)


        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;

        }


        public IActionResult Index()
        {

        ShopViewModel sh = new ShopViewModel();

            sh.ListAllCategories = _categoryRepository.GetCategories();

            List<Guid> GuidsCategories = new List<Guid>();

            foreach (var item in sh.ListAllCategories)
            {
                GuidsCategories.Add(item.Id);
            }




            sh.ListArticlesByCategories = _articleRepository.GetArticlesByCategories(GuidsCategories);



            var Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            if (Cart == null)
            {
                Cart cartIni = new Cart();

                cartIni.ArticleList = _articleRepository.GertArticleByCategory(Guid.Parse("3c8d1d1c-e759-11e9-91be-d8cb8a97b101"));
                HttpContext.Session.SetObjectAsJson("Cart", cartIni);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartIni);


            }

            Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            
            sh.Cart = Cart;

            return View(sh);
        }

        public IActionResult LoadArticleByCategorie(string IdCategory)

                                 
        {
            ShopViewModel sh = new ShopViewModel();

            sh.ListAllCategories = _categoryRepository.GetCategories();

            List<Guid> GuidsCategories = new List<Guid>();

            foreach (var item in sh.ListAllCategories)
            {
                GuidsCategories.Add(item.Id);
            }




            sh.ListArticlesByCategories = _articleRepository.GertArticleByCategory(Guid.Parse(IdCategory));

            return PartialView("_Products",sh);

        }




        public string addCart(string article)

        {

            Guid guid = Guid.Parse(article);



            Article art=_articleRepository.GetArticleById(guid);

            var Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            if (Cart == null)
            {
                Cart cartIni = new Cart();

                cartIni.ArticleList = cartIni.ArticleList = new List<Article>();
                HttpContext.Session.SetObjectAsJson("Cart", cartIni);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartIni);


            }
            else
            {
                Cart.ArticleList.Add(art);
                HttpContext.Session.SetObjectAsJson("Cart", Cart);
            }


            return "";
        }



    }
}