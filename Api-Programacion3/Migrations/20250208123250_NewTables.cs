using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Programacion3.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Clients_ClientId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Cart_CartId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_Item_CartId",
                table: "Items",
                newName: "IX_Items_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_ClientId",
                table: "Carts",
                newName: "IX_Carts_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Clients_ClientId",
                table: "Carts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Carts_CartId",
                table: "Items",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Clients_ClientId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Carts_CartId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CartId",
                table: "Item",
                newName: "IX_Item_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_ClientId",
                table: "Cart",
                newName: "IX_Cart_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Clients_ClientId",
                table: "Cart",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Cart_CartId",
                table: "Item",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }
    }
}
