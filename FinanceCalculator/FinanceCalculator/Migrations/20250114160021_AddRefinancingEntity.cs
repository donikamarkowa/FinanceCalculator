using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceCalculator.Migrations
{
    public partial class AddRefinancingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Refinancings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewInterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewDurationMonths = table.Column<int>(type: "int", nullable: false),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Savings = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refinancings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Refinancings");
        }
    }
}
