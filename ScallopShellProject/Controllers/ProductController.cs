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
    public class ProductController : Controller
    {
        private readonly ArticleRepository _articleRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ImageRepository _imageRepository;


        public ProductController(ArticleRepository articleRepository, CategoryRepository categoryRepository, ImageRepository imageRepository)


        {

            
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;

        }
        public IActionResult Index(string name = "e16c617f-be3d-49bd-b882-b1796edf6603")
        {
            IndexViewModel view = new IndexViewModel();

            

            view.article = _articleRepository.GetArticleById(Guid.Parse(name));


            var Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            if (Cart == null)
            {
                Cart cartIni = new Cart();

                cartIni.ArticleList = cartIni.ArticleList = new List<Article>();
                HttpContext.Session.SetObjectAsJson("Cart", cartIni);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartIni);


            }

            Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            view.Cart = Cart;






            return View(view);
        }


        public string addCart(string article)

        {

            Guid guid = Guid.Parse(article);



            Article art = _articleRepository.GetArticleById(guid);

            var Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            if (Cart == null)
            {
                Cart cartIni = new Cart();

                cartIni.ArticleList = _articleRepository.GertArticleByCategory(Guid.Parse("3c8d1d1c-e759-11e9-91be-d8cb8a97b101"));
          
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartIni);


            }
            else
            {
                Cart.ArticleList.Add(art);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            }


            return "";
        }
    }
}