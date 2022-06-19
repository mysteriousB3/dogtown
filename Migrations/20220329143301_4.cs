using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dog7.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpiredSellingPost",
                columns: table => new
                {
                    ExpiredSellingPostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    sellingPostId = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "longtext", nullable: true),
                    breed = table.Column<string>(type: "longtext", nullable: true),
                    sellerId = table.Column<int>(type: "int", nullable: false),
                    farmName = table.Column<string>(type: "longtext", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    sellingPostName = table.Column<string>(type: "longtext", nullable: true),
                    sellingPostDescription = table.Column<string>(type: "longtext", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    pedegree = table.Column<string>(type: "longtext", nullable: true),
                    sellingPostPostingDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    sellingPostPostExpiredDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    postLike = table.Column<int>(type: "int", nullable: false),
                    view = table.Column<int>(type: "int", nullable: false),
                    sellingPostPicUpdateDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpiredSellingPost", x => x.ExpiredSellingPostId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpiredSellingPost");
        }
    }
}
