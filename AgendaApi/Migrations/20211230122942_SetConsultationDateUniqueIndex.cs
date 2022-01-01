using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaApi.Migrations
{
    public partial class SetConsultationDateUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Consultations_Date",
                table: "Consultations",
                column: "Date",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Consultations_Date",
                table: "Consultations");
        }
    }
}
