using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseService.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "accountid",
                table: "expenses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accountid",
                table: "expenses");
        }
    }
}
