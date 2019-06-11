using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scripture_Journal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scripture",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Collection = table.Column<string>(nullable: true),
                    Book = table.Column<string>(nullable: true),
                    Chapter = table.Column<string>(nullable: true),
                    Verse = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripture", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scripture");
        }
    }
}
