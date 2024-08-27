using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AH.Migrations.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Added_CollationsAndTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:CollationDefinition:en_ci_ai", "en-u-ks-level1,en-u-ks-level1,icu,False")
                .Annotation("Npgsql:CollationDefinition:en_ci_as", "en-u-ks-level2,en-u-ks-level2,icu,False");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "People",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                collation: "en_ci_ai",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "People",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                collation: "en_ci_ai",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1L, "John", "Doe" },
                    { 2L, "Jane", "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:CollationDefinition:en_ci_ai", "en-u-ks-level1,en-u-ks-level1,icu,False")
                .OldAnnotation("Npgsql:CollationDefinition:en_ci_as", "en-u-ks-level2,en-u-ks-level2,icu,False");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "People",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldCollation: "en_ci_ai");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "People",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldCollation: "en_ci_ai");
        }
    }
}
