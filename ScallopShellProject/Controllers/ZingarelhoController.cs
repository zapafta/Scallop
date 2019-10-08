using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProj.Models;
using Microsoft.AspNetCore.Mvc;
using ScallopShellProject.Models;

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

            if (wp != pw)
            {

                return RedirectToAction("Index", "Home");

            }




            ZingarelhoViewModel zinga = new ZingarelhoViewModel();

            zinga.ListAllCategories = _categoryRepository.GetCategories();
            zinga.ListAllArticles = _articleRepository.GetArticles();



            return View(zinga);
        }

        public ZingarelhoViewModel EditArticle(string id)
        {
            ZingarelhoViewModel zinga = new ZingarelhoViewModel();


            zinga.Article=_articleRepository.GetArticleById(Guid.Parse(id));

        
            zinga.ListAllCategories = _categoryRepository.GetCategories();
            zinga.ListAllArticles = _articleRepository.GetArticles();






            return (zinga);
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

                if (string.IsNullOrEmpty(zinga.ListImage))
                {
                    throw new Exception("Temos que associar pelo menos uma imagem ao artigo");
                }

                List<Image> imageToSave = new List<Image>();
                Image image = new Image();
                image.Id = Guid.NewGuid();
                image.ImageByte = Convert.FromBase64String(zinga.ListImage);
                imageToSave.Add(image);
                
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