using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Data.Migrations
{
    public partial class AddFilmImageProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Films",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Films");
        }
    }
}
