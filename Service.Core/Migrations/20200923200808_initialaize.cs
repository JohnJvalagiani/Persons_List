using Microsoft.EntityFrameworkCore.Migrations;

namespace IG.Core.Migrations
{
    public partial class initialaize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Pictures_PictureId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PictureId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Pictures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonForeignKey",
                table: "Pictures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PersonForeignKey",
                table: "Pictures",
                column: "PersonForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Persons_PersonForeignKey",
                table: "Pictures",
                column: "PersonForeignKey",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Persons_PersonForeignKey",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_PersonForeignKey",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "PersonForeignKey",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PictureId",
                table: "Persons",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Pictures_PictureId",
                table: "Persons",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
