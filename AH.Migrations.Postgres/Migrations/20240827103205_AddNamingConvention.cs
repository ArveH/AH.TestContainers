using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AH.Migrations.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddNamingConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "people");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "people",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "people",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "people",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_people",
                table: "people",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_people",
                table: "people");

            migrationBuilder.RenameTable(
                name: "people",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "People",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "People",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "People",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");
        }
    }
}
