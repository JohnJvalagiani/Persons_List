using Microsoft.EntityFrameworkCore.Migrations;

namespace IG.Core.Migrations
{
    public partial class init55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectedPersons_Persons_PersonId",
                table: "ConnectedPersons");

            migrationBuilder.DropIndex(
                name: "IX_ConnectedPersons_PersonId",
                table: "ConnectedPersons");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "ConnectedPersons");

            migrationBuilder.AddColumn<int>(
                name: "PersonForeignKey",
                table: "ConnectedPersons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedPersons_PersonForeignKey",
                table: "ConnectedPersons",
                column: "PersonForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectedPersons_Persons_PersonForeignKey",
                table: "ConnectedPersons",
                column: "PersonForeignKey",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectedPersons_Persons_PersonForeignKey",
                table: "ConnectedPersons");

            migrationBuilder.DropIndex(
                name: "IX_ConnectedPersons_PersonForeignKey",
                table: "ConnectedPersons");

            migrationBuilder.DropColumn(
                name: "PersonForeignKey",
                table: "ConnectedPersons");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "ConnectedPersons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedPersons_PersonId",
                table: "ConnectedPersons",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectedPersons_Persons_PersonId",
                table: "ConnectedPersons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
