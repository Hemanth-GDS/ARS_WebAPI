using Microsoft.EntityFrameworkCore.Migrations;

namespace ARS_DAL.Migrations
{
    public partial class SET_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParticipantIntrests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantID = table.Column<int>(type: "int", nullable: false),
                    SessionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantIntrests", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantIntrests_ParticipantID_SessionTypeId",
                table: "ParticipantIntrests",
                columns: new[] { "ParticipantID", "SessionTypeId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantIntrests");
        }
    }
}
