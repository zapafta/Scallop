using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProj.Models;
using Microsoft.AspNetCore.Mvc;
using ScallopShellProject.Models;

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

            return View(sh);
        }
    }
}