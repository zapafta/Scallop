using DataProj.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScallopShellProject.Models
{
    public class ZingarelhoViewModel
    {

        public List<Category> ListAllCategories { get; set; }

        public List<Article> ListAllArticles { get; set; }

        public Article Article { get; set; }

        public string ListImage { get; set; }


        public List<IFormFile> FilesPhotos { get; set; }







    }
}
