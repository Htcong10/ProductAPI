using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.AddColumn<string>(
                name: "ChucNangDefault",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "HTC_CATEGORY",
                columns: table => new
                {
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    STATUS = table.Column<bool>(type: "bit", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTC_CATEGORY", x => x.CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "HTC_CUSTOMER",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BIRTHDAY = table.Column<DateTime>(type: "DATE", nullable: false),
                    ADDRESS = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NUMBER = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTC_CUSTOMER", x => x.CUSTOMER_ID);
                });

            migrationBuilder.CreateTable(
                name: "HTC_CUSTOMER_BILL",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BILL_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    SUM_PRICE = table.Column<double>(type: "float", nullable: false),
                    NAME_CUSTOMER = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NUMBER_CUSTOMER = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    LIST_PRODUCT_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTC_CUSTOMER_BILL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HTC_PRODUCT",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DECRIPSTION = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NAME = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    PRICE = table.Column<int>(type: "int", unicode: false, nullable: false),
                    IMAGE_URL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    CATEGORY_ID = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTC_PRODUCT", x => x.PRODUCT_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HTC_CATEGORY");

            migrationBuilder.DropTable(
                name: "HTC_CUSTOMER");

            migrationBuilder.DropTable(
                name: "HTC_CUSTOMER_BILL");

            migrationBuilder.DropTable(
                name: "HTC_PRODUCT");

            migrationBuilder.DropColumn(
                name: "ChucNangDefault",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }
    }
}
