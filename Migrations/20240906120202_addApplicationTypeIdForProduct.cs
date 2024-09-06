using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class addApplicationTypeIdForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Category_CategoryId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderReceiptAddress",
                table: "orderReceiptAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_applicationType",
                table: "applicationType");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "orderReceiptAddress",
                newName: "OrderReceiptAddress");

            migrationBuilder.RenameTable(
                name: "applicationType",
                newName: "ApplicationType");

            migrationBuilder.RenameIndex(
                name: "IX_product_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationTypeId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderReceiptAddress",
                table: "OrderReceiptAddress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationType",
                table: "ApplicationType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ApplicationType_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "ApplicationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ApplicationType_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderReceiptAddress",
                table: "OrderReceiptAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationType",
                table: "ApplicationType");

            migrationBuilder.DropColumn(
                name: "ApplicationTypeId",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "OrderReceiptAddress",
                newName: "orderReceiptAddress");

            migrationBuilder.RenameTable(
                name: "ApplicationType",
                newName: "applicationType");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "product",
                newName: "IX_product_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderReceiptAddress",
                table: "orderReceiptAddress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_applicationType",
                table: "applicationType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_Category_CategoryId",
                table: "product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
