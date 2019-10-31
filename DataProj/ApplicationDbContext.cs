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
        public virtual DbSet<EncomendaCabec> EncomendaCabec { get; set; }
        public virtual DbSet<EncomendaLinha> EncomendaLinha { get; set; }
        public virtual DbSet<UserSite> UserSite { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {


            base.OnModelCreating(modelBuilder);
        }




        }
}
