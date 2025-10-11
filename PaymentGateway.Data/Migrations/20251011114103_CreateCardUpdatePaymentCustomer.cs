using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentGateway.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateCardUpdatePaymentCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentGateway_PaymentGatewayId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "PaymentGateway");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Products",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Products",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Payment",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "PaymentGatewayId",
                table: "Payment",
                newName: "CardId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Payment",
                newName: "Created");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_PaymentGatewayId",
                table: "Payment",
                newName: "IX_Payment_CardId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSold",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Number",
                table: "Customer",
                type: "decimal(18,0)",
                precision: 18,
                scale: 0,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Last4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Network = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Number",
                table: "Customer",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_CustomerId",
                table: "Card",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Card_CardId",
                table: "Payment",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Card_CardId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Number",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isSold",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Products",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Payment",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Payment",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Payment",
                newName: "PaymentGatewayId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_CardId",
                table: "Payment",
                newName: "IX_Payment_PaymentGatewayId");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldPrecision: 18,
                oldScale: 0);

            migrationBuilder.CreateTable(
                name: "PaymentGateway",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecretKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGateway", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentGateway_PaymentGatewayId",
                table: "Payment",
                column: "PaymentGatewayId",
                principalTable: "PaymentGateway",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
