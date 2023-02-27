using MachinegoAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = new[]
            {
                new MachineCategory { Id = 1, Name = "Hafriyat Grubu"},
                new MachineCategory { Id = 2, Name = "Forklift ve İstifleyiciler" },
                new MachineCategory { Id = 3, Name = "Manlift" },
                new MachineCategory { Id = 4, Name = "Asfalt ve Yol" },
                new MachineCategory { Id = 5, Name = "Beton Grubu" },
                new MachineCategory { Id = 6, Name = "Dozer" }
            };

            var brands = new[]
            {
                new Brand { Id = 1, Name = "ABG" },
                new Brand { Id = 2, Name = "Abf-Titan" },
                new Brand { Id = 3, Name = "Agarin" },
                new Brand { Id = 4, Name = "Ajlr" },
                new Brand { Id = 5, Name = "Alfamix" },
                new Brand { Id = 6, Name = "Altrad" }
            };
            var types = new[]
            {
                new MachineType { Id = 1, Name = "El Silindiri" },
                new MachineType { Id = 2, Name = "Toprak Silindiri" },
                new MachineType { Id = 3, Name = "Asfalt Silindiri" },
                new MachineType { Id = 4, Name = "Mini Tandem Silindiri" },
                new MachineType { Id = 5, Name = "Su Tankeri" },
                new MachineType { Id = 6, Name = "Lastik Tekerlekli Silindir" }
            };
            var attachments = new[]
            {
                new Attachment() { Id = 1, Name = "Asfalt Traşlama"},
                new Attachment() { Id = 2, Name = "Elek Ataşmanı"},
                new Attachment() { Id = 3, Name = "Grapple"},
                new Attachment() { Id = 4, Name = "Hidrolik Kırıcı"},
                new Attachment() { Id = 5, Name = "Kazık Çakma"}
            };
            var categoryBrand = new[]
            {
                new CategoryBrand() { CategoryId = 1, BrandId = 1},
                new CategoryBrand() { CategoryId = 1, BrandId = 2},
                new CategoryBrand() { CategoryId = 1, BrandId = 4},
                new CategoryBrand() { CategoryId = 2, BrandId = 3},
                new CategoryBrand() { CategoryId = 3, BrandId = 2},
                new CategoryBrand() { CategoryId = 4, BrandId = 5},
                new CategoryBrand() { CategoryId = 5, BrandId = 6},
                new CategoryBrand() { CategoryId = 5, BrandId = 5},

            };
            var categoryType = new[]
            {
                new CategoryType() { CategoryId = 1, TypeId = 1},
                new CategoryType() { CategoryId = 1, TypeId = 2},
                new CategoryType() { CategoryId = 1, TypeId = 4},
                new CategoryType() { CategoryId = 2, TypeId = 3},
                new CategoryType() { CategoryId = 3, TypeId = 4},
                new CategoryType() { CategoryId = 4, TypeId = 3},
                new CategoryType() { CategoryId = 5, TypeId = 5},
                new CategoryType() { CategoryId = 6, TypeId = 6},

            };
            var typeAttachment = new[]
{
                new TypeAttachment() { TypeId = 1, AttachmentId = 1},
                new TypeAttachment() { TypeId = 1, AttachmentId = 2},
                new TypeAttachment() { TypeId = 1, AttachmentId = 4},
                new TypeAttachment() { TypeId = 2, AttachmentId = 3},
                new TypeAttachment() { TypeId = 3, AttachmentId = 3},
                new TypeAttachment() { TypeId = 3, AttachmentId = 2},
                new TypeAttachment() { TypeId = 4, AttachmentId = 4},
                new TypeAttachment() { TypeId = 5, AttachmentId = 5},
            };


            modelBuilder.Entity<CategoryBrand>().HasKey(e => new { e.CategoryId, e.BrandId });
            modelBuilder.Entity<CategoryBrand>()
                .HasOne(ky => ky.MachineCategory)
                .WithMany(k => k.Brands)
                .HasForeignKey(ky => ky.CategoryId);
            modelBuilder.Entity<CategoryBrand>()
                .HasOne(ky => ky.Brand)
                .WithMany(k => k.Categories)
                .HasForeignKey(ky => ky.BrandId);

            modelBuilder.Entity<CategoryType>().HasKey(e => new { e.CategoryId, e.TypeId });
            modelBuilder.Entity<CategoryType>()
                .HasOne(ky => ky.MachineCategory)
                .WithMany(k => k.Types)
                .HasForeignKey(ky => ky.CategoryId);
            modelBuilder.Entity<CategoryType>()
                .HasOne(ky => ky.MachineType)
                .WithMany(k => k.Categories)
                .HasForeignKey(ky => ky.TypeId);

            modelBuilder.Entity<TypeAttachment>().HasKey(e => new { e.TypeId, e.AttachmentId });
            modelBuilder.Entity<TypeAttachment>()
                .HasOne(ky => ky.MachineType)
                .WithMany(k => k.Attachments)
                .HasForeignKey(ky => ky.TypeId);
            modelBuilder.Entity<TypeAttachment>()
                .HasOne(ky => ky.Attachment)
                .WithMany(k => k.Types)
                .HasForeignKey(ky => ky.AttachmentId);
         

            modelBuilder.Entity<MachiceAttachment>().HasKey(e => new { e.MachineId, e.AttachmentId });
            modelBuilder.Entity<MachiceAttachment>()
                .HasOne(ky => ky.Machine)
                .WithMany(k => k.Attachments)
                .HasForeignKey(ky => ky.MachineId);
            modelBuilder.Entity<MachiceAttachment>()
                .HasOne(ky => ky.Attachment)
                .WithMany(k => k.Machines)
                .HasForeignKey(ky => ky.AttachmentId);




            modelBuilder.Entity<MachineCategory>().HasData(categories);
            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<MachineType>().HasData(types);
            modelBuilder.Entity<Attachment>().HasData(attachments);
            modelBuilder.Entity<CategoryBrand>().HasData(categoryBrand);
            modelBuilder.Entity<CategoryType>().HasData(categoryType);
            modelBuilder.Entity<TypeAttachment>().HasData(typeAttachment);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<MachineCategory> MachineCategories { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<MachiceAttachment> MachineAttachments { get; set; }
    }
}
