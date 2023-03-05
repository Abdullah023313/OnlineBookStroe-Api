using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookStroe.Migrations
{
    /// <inheritdoc />
    public partial class changeCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carts",
                newName: "ItemId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Carts",
                newName: "CartId");
        }
    }
}
