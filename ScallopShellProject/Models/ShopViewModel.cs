using DataProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScallopShellProject.Models
{
    public class ShopViewModel
    {


        public List<Category> ListAllCategories { get; set; }

        public List<Article> ListArticlesByCategories { get; set; }


    }
}
