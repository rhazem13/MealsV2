using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealsV2.Migrations
{
    public partial class addpasswordhashandpasswordsalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserLogin");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "UserLogin",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "UserLogin",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UserLogin");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserLogin",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "");
        }
    }
}
