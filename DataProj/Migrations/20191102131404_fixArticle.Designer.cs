﻿// <auto-generated />
using System;
using DataProj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataProj.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191102131404_fixArticle")]
    partial class fixArticle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataProj.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("DescricaoLonga");

                    b.Property<Guid>("IdCategory");

                    b.Property<int>("Ordenacao");

                    b.Property<decimal>("PrecoUnit");

                    b.Property<int>("Qtd");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("DataProj.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("DataProj.Models.EncomendaCabec", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodPostal")
                        .IsRequired();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<Guid>("IdUserSite");

                    b.Property<string>("Localidade")
                        .IsRequired();

                    b.Property<string>("Morada")
                        .IsRequired();

                    b.Property<bool>("Payment");

                    b.HasKey("Id");

                    b.HasIndex("IdUserSite");

                    b.ToTable("EncomendaCabec");
                });

            modelBuilder.Entity("DataProj.Models.EncomendaLinha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreation");

                    b.Property<DateTime>("DateModification");

                    b.Property<Guid>("IdArticle");

                    b.Property<Guid>("IdEncomendaCabec");

                    b.Property<bool>("IsPayment");

                    b.Property<decimal>("PrecoUnit");

                    b.Property<int>("Qty");

                    b.Property<string>("UserCreation")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IdArticle");

                    b.HasIndex("IdEncomendaCabec");

                    b.ToTable("EncomendaLinha");
                });

            modelBuilder.Entity("DataProj.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ArticleId");

                    b.Property<byte[]>("ImageByte")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("DataProj.Models.UserSite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("UserSite");
                });

            modelBuilder.Entity("DataProj.Models.Article", b =>
                {
                    b.HasOne("DataProj.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataProj.Models.EncomendaCabec", b =>
                {
                    b.HasOne("DataProj.Models.UserSite", "UserSite")
                        .WithMany()
                        .HasForeignKey("IdUserSite")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataProj.Models.EncomendaLinha", b =>
                {
                    b.HasOne("DataProj.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataProj.Models.EncomendaCabec", "EncomendaCabec")
                        .WithMany()
                        .HasForeignKey("IdEncomendaCabec")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataProj.Models.Image", b =>
                {
                    b.HasOne("DataProj.Models.Article")
                        .WithMany("ImageList")
                        .HasForeignKey("ArticleId");
                });
#pragma warning restore 612, 618
        }
    }
}
