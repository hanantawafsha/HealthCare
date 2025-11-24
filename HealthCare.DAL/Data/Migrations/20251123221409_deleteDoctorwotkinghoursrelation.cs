using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteDoctorwotkinghoursrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DoctorWorkingHours_DoctorWorkingHoursId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorWorkingHoursId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorWorkingHoursId",
                table: "Appointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorWorkingHoursId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorWorkingHoursId",
                table: "Appointments",
                column: "DoctorWorkingHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DoctorWorkingHours_DoctorWorkingHoursId",
                table: "Appointments",
                column: "DoctorWorkingHoursId",
                principalTable: "DoctorWorkingHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
