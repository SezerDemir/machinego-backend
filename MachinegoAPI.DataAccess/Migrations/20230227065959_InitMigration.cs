using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachinegoAPI.DataAccess.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryBrand",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBrand", x => new { x.CategoryId, x.BrandId });
                    table.ForeignKey(
                        name: "FK_CategoryBrand_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBrand_MachineCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MachineCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryType",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryType", x => new { x.CategoryId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_CategoryType_MachineCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MachineCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryType_MachineTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machines_MachineCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MachineCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machines_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeAttachment",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAttachment", x => new { x.TypeId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_TypeAttachment_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeAttachment_MachineTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineAttachments",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAttachments", x => new { x.MachineId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_MachineAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAttachments_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Asfalt Traşlama" },
                    { 2, "Elek Ataşmanı" },
                    { 3, "Grapple" },
                    { 4, "Hidrolik Kırıcı" },
                    { 5, "Kazık Çakma" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ABG" },
                    { 2, "Abf-Titan" },
                    { 3, "Agarin" },
                    { 4, "Ajlr" },
                    { 5, "Alfamix" },
                    { 6, "Altrad" }
                });

            migrationBuilder.InsertData(
                table: "MachineCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hafriyat Grubu" },
                    { 2, "Forklift ve İstifleyiciler" },
                    { 3, "Manlift" },
                    { 4, "Asfalt ve Yol" },
                    { 5, "Beton Grubu" },
                    { 6, "Dozer" }
                });

            migrationBuilder.InsertData(
                table: "MachineTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "El Silindiri" },
                    { 2, "Toprak Silindiri" },
                    { 3, "Asfalt Silindiri" },
                    { 4, "Mini Tandem Silindiri" },
                    { 5, "Su Tankeri" },
                    { 6, "Lastik Tekerlekli Silindir" }
                });

            migrationBuilder.InsertData(
                table: "CategoryBrand",
                columns: new[] { "BrandId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 },
                    { 3, 2 },
                    { 2, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 6, 5 }
                });

            migrationBuilder.InsertData(
                table: "CategoryType",
                columns: new[] { "CategoryId", "TypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 3 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "TypeAttachment",
                columns: new[] { "AttachmentId", "TypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 },
                    { 3, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBrand_BrandId",
                table: "CategoryBrand",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryType_TypeId",
                table: "CategoryType",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAttachments_AttachmentId",
                table: "MachineAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_BrandId",
                table: "Machines",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_CategoryId",
                table: "Machines",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineTypeId",
                table: "Machines",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAttachment_AttachmentId",
                table: "TypeAttachment",
                column: "AttachmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryBrand");

            migrationBuilder.DropTable(
                name: "CategoryType");

            migrationBuilder.DropTable(
                name: "MachineAttachments");

            migrationBuilder.DropTable(
                name: "TypeAttachment");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "MachineCategories");

            migrationBuilder.DropTable(
                name: "MachineTypes");
        }
    }
}
