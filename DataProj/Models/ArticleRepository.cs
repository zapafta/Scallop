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



             public void SaveArticle(Article article, List<Image> images)
        {



            foreach (var item in images)
            {

                context.Image.Add(item);
                context.SaveChanges();




            }




            Article Verify = context.Article.Where(t => t.Id == article.Id).FirstOrDefault();
               

                if (Verify==null)
            {
                //Vamos gravar
                Article ArticleNew = new Article();
                ArticleNew.Descricao = article.Descricao;
                ArticleNew.PrecoUnit = article.PrecoUnit;
                ArticleNew.Qtd = article.Qtd;
                ArticleNew.Active = article.Active;
                ArticleNew.IdImage = images[0].Id;
                ArticleNew.IdCategory = article.IdCategory;
                
                context.Entry(ArticleNew).State = EntityState.Added;
                context.SaveChanges();



            }
            else
            {

                Verify.Descricao = article.Descricao;
                Verify.PrecoUnit = article.PrecoUnit;
                Verify.Qtd = article.Qtd;
                Verify.Active = article.Active;
                Verify.IdImage = images[0].Id;
                Verify.IdCategory = article.IdCategory;
                context.Entry(Verify).State = EntityState.Modified;
                context.SaveChanges();

                //Vamos Alterar
            }




        }



    }
}
