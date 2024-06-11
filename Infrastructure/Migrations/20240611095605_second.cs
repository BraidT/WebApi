using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "PrivateParticipants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "PaymentType",
                table: "PrivateParticipants",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "ParticipantCount",
                table: "EventBusinessParticipants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "BusinessParticipants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantCount",
                table: "BusinessParticipants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "PaymentType",
                table: "BusinessParticipants",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "PrivateParticipants");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "PrivateParticipants");

            migrationBuilder.DropColumn(
                name: "ParticipantCount",
                table: "EventBusinessParticipants");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "BusinessParticipants");

            migrationBuilder.DropColumn(
                name: "ParticipantCount",
                table: "BusinessParticipants");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "BusinessParticipants");
        }
    }
}
