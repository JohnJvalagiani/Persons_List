using Microsoft.EntityFrameworkCore.Migrations;

namespace IG.Core.Migrations
{
    public partial class initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Persons_PersonForeignKey",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_PersonForeignKey",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "PersonForeignKey",
                table: "Pictures");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "conectedpersonId",
                table: "ConnectedPersons",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Pictures_PictureId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PictureId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "PersonForeignKey",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "conectedpersonId",
                table: "ConnectedPersons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PersonForeignKey",
                table: "Pictures",
                column: "PersonForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Persons_PersonForeignKey",
                table: "Pictures",
                column: "PersonForeignKey",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
