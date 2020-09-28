using Microsoft.EntityFrameworkCore.Migrations;

namespace IG.Core.Migrations
{
    public partial class dass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectedPersons_Persons_ForeignKey",
                table: "ConnectedPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConnectedPersons",
                table: "ConnectedPersons");

            migrationBuilder.RenameTable(
                name: "ConnectedPersons",
                newName: "ConnectedPerson");

            migrationBuilder.RenameIndex(
                name: "IX_ConnectedPersons_ForeignKey",
                table: "ConnectedPerson",
                newName: "IX_ConnectedPerson_ForeignKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConnectedPerson",
                table: "ConnectedPerson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectedPerson_Persons_ForeignKey",
                table: "ConnectedPerson",
                column: "ForeignKey",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectedPerson_Persons_ForeignKey",
                table: "ConnectedPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConnectedPerson",
                table: "ConnectedPerson");

            migrationBuilder.RenameTable(
                name: "ConnectedPerson",
                newName: "ConnectedPersons");

            migrationBuilder.RenameIndex(
                name: "IX_ConnectedPerson_ForeignKey",
                table: "ConnectedPersons",
                newName: "IX_ConnectedPersons_ForeignKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConnectedPersons",
                table: "ConnectedPersons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectedPersons_Persons_ForeignKey",
                table: "ConnectedPersons",
                column: "ForeignKey",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
