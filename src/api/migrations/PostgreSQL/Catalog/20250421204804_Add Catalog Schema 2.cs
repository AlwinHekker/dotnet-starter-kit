using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSH.Starter.WebApi.Migrations.PostgreSQL.Catalog
{
    /// <inheritdoc />
    public partial class AddCatalogSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "catalog",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfigurable",
                schema: "catalog",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                schema: "catalog",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInStock",
                schema: "catalog",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewArrival",
                schema: "catalog",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnSale",
                schema: "catalog",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisibleIndividually",
                schema: "catalog",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                schema: "catalog",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                schema: "catalog",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                schema: "catalog",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductFamily",
                schema: "catalog",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                schema: "catalog",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                schema: "catalog",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentFeatureId",
                schema: "catalog",
                table: "Features",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                schema: "catalog",
                table: "Features",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Features_ParentFeatureId",
                schema: "catalog",
                table: "Features",
                column: "ParentFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ProductId",
                schema: "catalog",
                table: "Features",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Features_ParentFeatureId",
                schema: "catalog",
                table: "Features",
                column: "ParentFeatureId",
                principalSchema: "catalog",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Products_ProductId",
                schema: "catalog",
                table: "Features",
                column: "ProductId",
                principalSchema: "catalog",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Features_ParentFeatureId",
                schema: "catalog",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Products_ProductId",
                schema: "catalog",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ParentFeatureId",
                schema: "catalog",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ProductId",
                schema: "catalog",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsConfigurable",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsInStock",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsNewArrival",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsOnSale",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsVisibleIndividually",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductFamily",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ParentFeatureId",
                schema: "catalog",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "catalog",
                table: "Features");
        }
    }
}
