using DataProj.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataProj
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
  : base(options)
        {


        }


        public virtual DbSet<Article> Article { get; set; }

        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<ArticleImage> ArticleImage { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<ArticleImage>()
     .HasKey(c => new { c.IdArticle, c.IdImage });


            modelBuilder.Entity<ArticleImage>()
                .HasOne(bc => bc.Article)
                .WithMany(b => b.ArticleImage)
                .HasForeignKey(bc => bc.IdArticle)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ArticleImage>()
                .HasOne(bc => bc.Image)
                .WithMany(c => c.ArticleImage)
                .HasForeignKey(bc => bc.IdImage)
                     .OnDelete(DeleteBehavior.Restrict);
      


            base.OnModelCreating(modelBuilder);
        }




        }
}
