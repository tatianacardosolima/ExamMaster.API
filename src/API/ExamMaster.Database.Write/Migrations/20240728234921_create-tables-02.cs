using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockExam.Manage.Database.Write.Migrations
{
    /// <inheritdoc />
    public partial class createtables02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsCorrectAnswer",
                table: "AnswerOption",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(350)",
                oldMaxLength: 350);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "IsCorrectAnswer",
                table: "AnswerOption",
                type: "tinyint(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }
    }
}
