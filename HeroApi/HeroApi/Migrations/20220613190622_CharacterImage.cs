using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroApi.Migrations
{
    public partial class CharacterImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Characters",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Characters");
        }
    }
}
