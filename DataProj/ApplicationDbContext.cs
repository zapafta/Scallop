using DataProj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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


            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
.SelectMany(t => t.GetForeignKeys())
.Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            //
         

            base.OnModelCreating(modelBuilder);
        }




        }
}
