using Microsoft.EntityFrameworkCore.Migrations;

namespace ELCV.Infrastructure.Migrations
{
    public partial class EntitiesChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryCode1",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateCode1",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryCode1",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_CountryCode1",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryCode1",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateCode1",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StateCode1",
                table: "Cities");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Countrycode = table.Column<string>(nullable: true),
                    StateCode = table.Column<string>(nullable: true),
                    CityCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PicturePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SkillTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterCode = table.Column<string>(nullable: true),
                    ParameterValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ResumeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_PersonId",
                table: "Resumes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_ResumeId",
                table: "WorkExperiences",
                column: "ResumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SkillTypes");

            migrationBuilder.DropTable(
                name: "SystemParameters");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                table: "States",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateCode1",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryCode1",
                table: "States",
                column: "CountryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryCode1",
                table: "Cities",
                column: "CountryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateCode1",
                table: "Cities",
                column: "StateCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryCode1",
                table: "Cities",
                column: "CountryCode1",
                principalTable: "Countries",
                principalColumn: "CountryCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateCode1",
                table: "Cities",
                column: "StateCode1",
                principalTable: "States",
                principalColumn: "StateCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryCode1",
                table: "States",
                column: "CountryCode1",
                principalTable: "Countries",
                principalColumn: "CountryCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
