using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentApp.Migrations
{
    public partial class TransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MessageType = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionId = table.Column<string>(type: "TEXT", nullable: true),
                    AccountId = table.Column<long>(type: "INTEGER", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
