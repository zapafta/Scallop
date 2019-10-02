using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProj.Models
{
    public class ArticleRepository
    {
        ApplicationDbContext context;
        public ArticleRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }


        public List<Article> GetArticles()
        {

            List<Article> l = context.Article.Where(t=>t.Active==true).ToList();
            return l;
        }


    }
}
