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

            List<Article> l = context.Article.Include(t => t.ImageList).ToList();



            return l.OrderBy(t => t.Ordenacao).ToList();
        }




        public Article GetArticleById( Guid id)
        {

            Article article = context.Article.Include(t => t.ImageList).Where(t => t.Id == id).FirstOrDefault();
            
            return article;
        }





        public List<Article> GetArticlesByCategories(List<Guid> ListFilterd)
        {
            List<Article> l = context.Article.Include(t=> t.ImageList).Where(t => ListFilterd.Contains(t.IdCategory)).ToList();
           return l.OrderBy(t => t.Ordenacao).ToList();
        }


        public List<Article> GertArticleByCategory(Guid ListFilterd)
        {
            List<Article> l = context.Article.Include(t => t.ImageList).Where(t => t.IdCategory == ListFilterd).ToList();

            return l.OrderBy(t => t.Ordenacao).ToList();
        }



        public void SaveArticle(Article article, List<Image> images)
        {

            foreach (var item in images)
            {
                Image VerifyImage = context.Image.Where(t => t.Id == item.Id).FirstOrDefault();
                if (VerifyImage == null)
                {
                    //Vamos gravar
                    Image ImageNew = new Image();
                    context.Entry(item).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    context.Entry(VerifyImage).State = EntityState.Modified;
                    context.SaveChanges();
                    //Vamos Alterar
                }
            }

            Article Verify = context.Article.Where(t => t.Id == article.Id).FirstOrDefault();
                if (Verify==null)
            {
                //Vamos gravar
                Article ArticleNew = new Article();
                ArticleNew.Id = Guid.NewGuid();
                ArticleNew.Descricao = article.Descricao;
                ArticleNew.PrecoUnit = article.PrecoUnit;
                ArticleNew.Qtd = article.Qtd;
                ArticleNew.Active = article.Active;
                ArticleNew.ImageList = images;
                ArticleNew.IdCategory = article.IdCategory;
                ArticleNew.DescricaoLonga = article.DescricaoLonga;
                context.Entry(ArticleNew).State = EntityState.Added;
                context.SaveChanges();
            }
            else
            {
                Verify.Descricao = article.Descricao;
                Verify.PrecoUnit = article.PrecoUnit;
                Verify.Qtd = article.Qtd;
                Verify.Active = article.Active;
                Verify.ImageList = images;
                Verify.IdCategory = article.IdCategory;
                Verify.DescricaoLonga = Verify.DescricaoLonga;
                context.Entry(Verify).State = EntityState.Modified;
                context.SaveChanges();

                //Vamos Alterar
            }




        }



    }
}
