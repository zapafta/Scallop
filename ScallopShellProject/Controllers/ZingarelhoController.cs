using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using ScallopShellProject.Models;
using ScallopShellProject.SessionModel;

namespace ScallopShellProject.Controllers
{
    public class ZingarelhoController : Controller
    {

        private readonly ArticleRepository _articleRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ImageRepository _imageRepository;

        public ZingarelhoController(ArticleRepository articleRepository, CategoryRepository categoryRepository, ImageRepository imageRepository)


        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;

        }
        public IActionResult Index(string pw = "")
        {




            string wp = "Jogos2009";



            wp = HttpContext.Session.GetString("Test");


            Response.Cookies.Append("Cart", "TATA");




            if (pw != "Jogos2009")
            {

                return RedirectToAction("Index", "Home");

            }




            ZingarelhoViewModel zinga = new ZingarelhoViewModel();

            zinga.ListAllCategories = _categoryRepository.GetCategories();
            zinga.ListAllArticles = _articleRepository.GetArticles();


            var Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            if (Cart == null)
            {
                Cart cartIni = new Cart();

                cartIni.ArticleList = cartIni.ArticleList = new List<Article>();
                HttpContext.Session.SetObjectAsJson("Cart", cartIni);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartIni);


            }

            Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            zinga.Cart = Cart;



            return View(zinga);
        }

        public ZingarelhoViewModel EditArticle(string id)
        {
            ZingarelhoViewModel zinga = new ZingarelhoViewModel();


            zinga.Article=_articleRepository.GetArticleById(Guid.Parse(id));

        
            zinga.ListAllCategories = _categoryRepository.GetCategories();
            zinga.ListAllArticles = _articleRepository.GetArticles();


            string json = JsonConvert.SerializeObject(zinga, Formatting.Indented);




            return zinga;
        }


            public string SaveArticle(ZingarelhoViewModel zinga)
        {


            try
            {

                if (zinga.Article.PrecoUnit == 0)
                {
                    throw new Exception("Nao pode ser zero");
                }

                if (zinga.Article.Descricao == "")
                {
                    throw new Exception("Nao ser vazia a descricao");
                }


                if (zinga.Article.DescricaoLonga == "")
                {
                    throw new Exception("Nao ser vazia a descricao");
                }

                if (string.IsNullOrEmpty(zinga.ListImage))
                {
                    throw new Exception("Temos que associar pelo menos uma imagem ao artigo");
                }



               var ListBaseImage= zinga.ListImage.Split("€");

                List<Image> imageToSave = new List<Image>();
                int contador = 0;

                for (int i = 0; i < ListBaseImage.Length; i++)
                {
                    if(i>0)
                    {
                        Image image = new Image();
                        image.Id = Guid.NewGuid();
                        image.ImageByte = Convert.FromBase64String(ListBaseImage[i]);
                             imageToSave.Add(image);
                        contador = contador + 1;
                    }
                        
                            
                            }

               
               
                
                _articleRepository.SaveArticle(zinga.Article, imageToSave);
                
            

                zinga.ListAllCategories = _categoryRepository.GetCategories();
                zinga.ListAllArticles = _articleRepository.GetArticles();



                return "1";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }





    }
}