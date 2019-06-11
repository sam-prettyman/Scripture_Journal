using Microsoft.EntityFrameworkCore.Migrations;

namespace Scripture_Journal.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Collection",
                table: "Scripture",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Book",
                table: "Scripture",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Collection",
                table: "Scripture",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Book",
                table: "Scripture",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);
        }
    }
}
