﻿// <auto-generated />
using System;
using MachinegoAPI.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MachinegoAPI.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230228104252_MigrationInit")]
    partial class MigrationInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Attachments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Asfalt Traşlama"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Elek Ataşmanı"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Grapple"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hidrolik Kırıcı"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Kazık Çakma"
                        });
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ABG"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Abf-Titan"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Agarin"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ajlr"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Alfamix"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Altrad"
                        });
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.CategoryBrand", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "BrandId");

                    b.HasIndex("BrandId");

                    b.ToTable("CategoryBrand");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            BrandId = 1
                        },
                        new
                        {
                            CategoryId = 1,
                            BrandId = 2
                        },
                        new
                        {
                            CategoryId = 1,
                            BrandId = 4
                        },
                        new
                        {
                            CategoryId = 2,
                            BrandId = 3
                        },
                        new
                        {
                            CategoryId = 3,
                            BrandId = 2
                        },
                        new
                        {
                            CategoryId = 4,
                            BrandId = 5
                        },
                        new
                        {
                            CategoryId = 5,
                            BrandId = 6
                        },
                        new
                        {
                            CategoryId = 5,
                            BrandId = 5
                        });
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.CategoryType", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("CategoryType");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            TypeId = 1
                        },
                        new
                        {
                            CategoryId = 1,
                            TypeId = 2
                        },
                        new
                        {
                            CategoryId = 1,
                            TypeId = 4
                        },
                        new
                        {
                            CategoryId = 2,
                            TypeId = 3
                        },
                        new
                        {
                            CategoryId = 3,
                            TypeId = 4
                        },
                        new
                        {
                            CategoryId = 4,
                            TypeId = 3
                        },
                        new
                        {
                            CategoryId = 5,
                            TypeId = 5
                        },
                        new
                        {
                            CategoryId = 6,
                            TypeId = 6
                        });
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.MachiceAttachment", b =>
                {
                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("AttachmentId")
                        .HasColumnType("int");

                    b.HasKey("MachineId", "AttachmentId");

                    b.HasIndex("AttachmentId");

                    b.ToTable("MachineAttachments");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("MachineTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.MachineCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MachineCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hafriyat Grubu"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Forklift ve İstifleyiciler"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manlift"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Asfalt ve Yol"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Beton Grubu"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Dozer"
                        });
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.MachineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MachineTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "El Silindiri"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Toprak Silindiri"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Asfalt Silindiri"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mini Tandem Silindiri"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Su Tankeri"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Lastik Tekerlekli Silindir"
                        });
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.TypeAttachment", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("AttachmentId")
                        .HasColumnType("int");

                    b.HasKey("TypeId", "AttachmentId");

                    b.HasIndex("AttachmentId");

                    b.ToTable("TypeAttachment");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            AttachmentId = 1
                        },
                        new
                        {
                            TypeId = 1,
                            AttachmentId = 2
                        },
                        new
                        {
                            TypeId = 1,
                            AttachmentId = 4
                        },
                        new
                        {
                            TypeId = 2,
                            AttachmentId = 3
                        },
                        new
                        {
                            TypeId = 3,
                            AttachmentId = 3
                        },
                        new
                        {
                            TypeId = 3,
                            AttachmentId = 2
                        },
                        new
                        {
                            TypeId = 4,
                            AttachmentId = 4
                        },
                        new
                        {
                            TypeId = 5,
                            AttachmentId = 5
                        });
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.CategoryBrand", b =>
                {
                    b.HasOne("MachinegoAPI.DataAccess.Models.Brand", "Brand")
                        .WithMany("Categories")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachinegoAPI.DataAccess.Models.MachineCategory", "MachineCategory")
                        .WithMany("Brands")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("MachineCategory");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.CategoryType", b =>
                {
                    b.HasOne("MachinegoAPI.DataAccess.Models.MachineCategory", "MachineCategory")
                        .WithMany("Types")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachinegoAPI.DataAccess.Models.MachineType", "MachineType")
                        .WithMany("Categories")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineCategory");

                    b.Navigation("MachineType");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.MachiceAttachment", b =>
                {
                    b.HasOne("MachinegoAPI.DataAccess.Models.Attachment", "Attachment")
                        .WithMany("Machines")
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachinegoAPI.DataAccess.Models.Machine", "Machine")
                        .WithMany("Attachments")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.Machine", b =>
                {
                    b.HasOne("MachinegoAPI.DataAccess.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachinegoAPI.DataAccess.Models.MachineCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachinegoAPI.DataAccess.Models.MachineType", "MachineType")
                        .WithMany()
                        .HasForeignKey("MachineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("MachineType");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.TypeAttachment", b =>
                {
                    b.HasOne("MachinegoAPI.DataAccess.Models.Attachment", "Attachment")
                        .WithMany("Types")
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachinegoAPI.DataAccess.Models.MachineType", "MachineType")
                        .WithMany("Attachments")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("MachineType");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.Attachment", b =>
                {
                    b.Navigation("Machines");

                    b.Navigation("Types");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.Brand", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.Machine", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.MachineCategory", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("Types");
                });

            modelBuilder.Entity("MachinegoAPI.DataAccess.Models.MachineType", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}