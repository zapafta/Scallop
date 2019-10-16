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
            List<Article> lReturn = new List<Article>();

            //addimage
            foreach (var item in l)
            {

                item.ArticleImage = context.ArticleImage.Include(t=> t.Image).Where(t => t.IdArticle == item.Id).ToList();
                lReturn.Add(item);
            }


            return lReturn;
        }




        public Article GetArticleById( Guid id)
        {

            Article article = context.Article.Where(t => t.Id == id).FirstOrDefault();
            article.ArticleImage = context.ArticleImage.Where(t => t.IdArticle == article.Id).ToList();
            return article;
        }





        public List<Article> GetArticlesByCategories(List<Guid> ListFilterd)
        {
            List<Article> l = context.Article.Where(t => ListFilterd.Contains(t.IdCategory)).ToList();
            return l;
        }



             public void SaveArticle(Article article, List<Image> images)
        {







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
      
                ArticleNew.IdCategory = article.IdCategory;
                context.Entry(ArticleNew).State = EntityState.Added;


                context.SaveChanges();



                List<ArticleImage> ListArticleImageToSave = new List<ArticleImage>();
                foreach (var item in images)
                {
                    ArticleImage articleImage = new ArticleImage();
                    articleImage.IdImage = item.Id;
                    articleImage.IdArticle = ArticleNew.Id;
                    ListArticleImageToSave.Add(articleImage);

                    context.Image.Add(item);
                    context.SaveChanges();

                    context.ArticleImage.Add(articleImage);
                    context.SaveChanges();

                }


      
            }
            else
            {

                Verify.Descricao = article.Descricao;
                Verify.PrecoUnit = article.PrecoUnit;
                Verify.Qtd = article.Qtd;
                Verify.Active = article.Active;
             
                Verify.IdCategory = article.IdCategory;
                context.Entry(Verify).State = EntityState.Modified;
                context.SaveChanges();

                //Vamos Alterar
            }




        }



    }
}
