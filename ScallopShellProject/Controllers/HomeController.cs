using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataProj.Models;
using Microsoft.AspNetCore.Mvc;
using ScallopShellProject.Models;

namespace ScallopShellProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ArticleRepository _articleRepository;



        public HomeController(ArticleRepository articleRepository)


        {
            _articleRepository = articleRepository;

        }


        public IActionResult Index()
        {
            IndexViewModel index = new IndexViewModel();

            index.Articles = _articleRepository.GetArticles();

       







            return View(index);
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
