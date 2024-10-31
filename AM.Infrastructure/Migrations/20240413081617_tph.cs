using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Passengers",
                newName: "PassLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Passengers",
                newName: "PassFirstName");

            migrationBuilder.AlterColumn<string>(
                name: "PassFirstName",
                table: "Passengers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "IsTraveller",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTraveller",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "PassLastName",
                table: "Passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PassFirstName",
                table: "Passengers",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
