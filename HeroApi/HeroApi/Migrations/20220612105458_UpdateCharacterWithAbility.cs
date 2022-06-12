using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroApi.Migrations
{
    public partial class UpdateCharacterWithAbility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ability_Description",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ability_Description",
                table: "Characters");
        }
    }
}
