using Microsoft.EntityFrameworkCore.Migrations;

namespace IG.Core.Migrations
{
    public partial class init195 : Migration
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
                name: "ForeignKey",
                table: "ConnectedPersons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedPersons_ForeignKey",
                table: "ConnectedPersons",
                column: "ForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectedPersons_Persons_ForeignKey",
                table: "ConnectedPersons",
                column: "ForeignKey",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectedPersons_Persons_ForeignKey",
                table: "ConnectedPersons");

            migrationBuilder.DropIndex(
                name: "IX_ConnectedPersons_ForeignKey",
                table: "ConnectedPersons");

            migrationBuilder.DropColumn(
                name: "ForeignKey",
                table: "ConnectedPersons");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "ConnectedPersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
