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
        public IActionResult Index( string pw="")
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


        public IActionResult SaveArticle(ZingarelhoViewModel zinga)
        {







            List<Image> imageToSave = new List<Image>();

            Image image = new Image();
            image.Id = Guid.NewGuid();
            image.ImageByte = Convert.FromBase64String(zinga.ListImage);

            imageToSave.Add(image);

            _articleRepository.SaveArticle(zinga.Article, imageToSave);

            
      


            string wp = "Jogos2009";





            zinga.ListAllCategories = _categoryRepository.GetCategories();
            zinga.ListAllArticles = _articleRepository.GetArticles();



            return View("Zingarelho?pw=Jogos2009", zinga);
        }





    }
}