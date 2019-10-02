﻿// <auto-generated />
using System;
using DataProj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataProj.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<Guid?>("IdImage");

                    b.Property<decimal>("PrecoUnit");

                    b.Property<int>("Qtd");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.ToTable("Article");
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
                    b.HasOne("DataProj.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage");
                });
#pragma warning restore 612, 618
        }
    }
}
