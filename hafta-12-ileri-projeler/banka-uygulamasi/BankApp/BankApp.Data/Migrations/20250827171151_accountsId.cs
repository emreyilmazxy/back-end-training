using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class accountsId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverAccountId",
                table: "MoneyTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderAccountId",
                table: "MoneyTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransactions_ReceiverAccountId",
                table: "MoneyTransactions",
                column: "ReceiverAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransactions_SenderAccountId",
                table: "MoneyTransactions",
                column: "SenderAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_Accounts_ReceiverAccountId",
                table: "MoneyTransactions",
                column: "ReceiverAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_Accounts_SenderAccountId",
                table: "MoneyTransactions",
                column: "SenderAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_Accounts_ReceiverAccountId",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_Accounts_SenderAccountId",
                table: "MoneyTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransactions_ReceiverAccountId",
                table: "MoneyTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransactions_SenderAccountId",
                table: "MoneyTransactions");

            migrationBuilder.DropColumn(
                name: "ReceiverAccountId",
                table: "MoneyTransactions");

            migrationBuilder.DropColumn(
                name: "SenderAccountId",
                table: "MoneyTransactions");
        }
    }
}
