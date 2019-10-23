using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProj.Models;
using Microsoft.AspNetCore.Mvc;
using ScallopShellProject.Models;

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






            return View(view);
        }
    }
}