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

        public ZingarelhoController(ArticleRepository articleRepository, CategoryRepository categoryRepository)


        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;

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
    }
}