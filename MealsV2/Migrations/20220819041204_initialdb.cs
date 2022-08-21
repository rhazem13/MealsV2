using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealsV2.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCat",
                columns: table => new
                {
                    FoodCatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCat", x => x.FoodCatId);
                });

            migrationBuilder.CreateTable(
                name: "MainCat",
                columns: table => new
                {
                    MainCatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCat", x => x.MainCatId);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Nationality = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    ActivityLevel = table.Column<byte>(type: "tinyint", nullable: true),
                    RecommendedCalories = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserData__1788CC4CDC5CFE4A", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodCatId = table.Column<int>(type: "int", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    IsCountable = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                    table.ForeignKey(
                        name: "FK__Meals__FoodCatId__2C3393D0",
                        column: x => x.FoodCatId,
                        principalTable: "FoodCat",
                        principalColumn: "FoodCatId");
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Email);
                    table.ForeignKey(
                        name: "FK__UserLogin__UserI__25869641",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserMeals",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    UserMealDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MainCatId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserMeal__3B16655B336CCC12", x => new { x.UserMealDate, x.UserId, x.MealId });
                    table.ForeignKey(
                        name: "FK__UserMeals__MainC__30F848ED",
                        column: x => x.MainCatId,
                        principalTable: "MainCat",
                        principalColumn: "MainCatId");
                    table.ForeignKey(
                        name: "FK__UserMeals__MealI__300424B4",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId");
                    table.ForeignKey(
                        name: "FK__UserMeals__UserI__2F10007B",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_FoodCatId",
                table: "Meals",
                column: "FoodCatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_MainCatId",
                table: "UserMeals",
                column: "MainCatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_MealId",
                table: "UserMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_UserId",
                table: "UserMeals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserMeals");

            migrationBuilder.DropTable(
                name: "MainCat");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropTable(
                name: "FoodCat");
        }
    }
}
