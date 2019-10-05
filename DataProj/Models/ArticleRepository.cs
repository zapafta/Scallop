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

            List<Article> l = context.Article.ToList();
            return l;
        }





        public List<Article> GetArticlesByCategories(List<Guid> ListFilterd)
        {
            List<Article> l = context.Article.Where(t => ListFilterd.Contains(t.IdCategory)).ToList();
            return l;
        }



    }
}
