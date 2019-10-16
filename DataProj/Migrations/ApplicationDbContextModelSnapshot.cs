﻿// <auto-generated />
using System;
using DataProj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataProj.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("IdCategory");

                    b.Property<decimal>("PrecoUnit");

                    b.Property<int>("Qtd");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("DataProj.Models.ArticleImage", b =>
                {
                    b.Property<Guid>("IdArticle");

                    b.Property<Guid>("IdImage");

                    b.HasKey("IdArticle", "IdImage");

                    b.HasIndex("IdImage");

                    b.ToTable("ArticleImage");
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

            modelBuilder.Entity("DataProj.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ImageByte")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("DataProj.Models.Article", b =>
                {
                    b.HasOne("DataProj.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataProj.Models.ArticleImage", b =>
                {
                    b.HasOne("DataProj.Models.Article", "Article")
                        .WithMany("ArticleImage")
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataProj.Models.Image", "Image")
                        .WithMany("ArticleImage")
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
