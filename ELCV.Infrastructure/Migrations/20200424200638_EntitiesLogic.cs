using Microsoft.EntityFrameworkCore.Migrations;

namespace ELCV.Infrastructure.Migrations
{
    public partial class EntitiesLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_People_PersonId1",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Resumes_ResumeId1",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_ResumeId1",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_PersonId1",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "ResumeId1",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "States");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StateCode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StateCode",
                table: "Addresses");

            migrationBuilder.AddColumn<long>(
                name: "ResumeForeignKey",
                table: "WorkExperiences",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "ParameterCode",
                table: "SystemParameters",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StateCode",
                table: "States",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "States",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SkillTypeId",
                table: "Skills",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "PersonId",
                table: "Resumes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CityCode",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StateId",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StateId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResumeSkill",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<long>(nullable: false),
                    SkillId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeSkill_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_ResumeForeignKey",
                table: "WorkExperiences",
                column: "ResumeForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParameters_ParameterCode",
                table: "SystemParameters",
                column: "ParameterCode",
                unique: true,
                filter: "[ParameterCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_States_StateCode",
                table: "States",
                column: "StateCode",
                unique: true,
                filter: "[StateCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillTypeId",
                table: "Skills",
                column: "SkillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_PersonId",
                table: "Resumes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityCode",
                table: "Cities",
                column: "CityCode",
                unique: true,
                filter: "[CityCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSkill_ResumeId",
                table: "ResumeSkill",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSkill_SkillId",
                table: "ResumeSkill",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_People_PersonId",
                table: "Resumes",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillTypes_SkillTypeId",
                table: "Skills",
                column: "SkillTypeId",
                principalTable: "SkillTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Resumes_ResumeForeignKey",
                table: "WorkExperiences",
                column: "ResumeForeignKey",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_People_PersonId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillTypes_SkillTypeId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Resumes_ResumeForeignKey",
                table: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "ResumeSkill");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_ResumeForeignKey",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_SystemParameters_ParameterCode",
                table: "SystemParameters");

            migrationBuilder.DropIndex(
                name: "IX_States_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_StateCode",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillTypeId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_PersonId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AddressId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CityCode",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ResumeForeignKey",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "WorkExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ResumeId1",
                table: "WorkExperiences",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParameterCode",
                table: "SystemParameters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StateCode",
                table: "States",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "States",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SkillTypeId",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Resumes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PersonId1",
                table: "Resumes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityCode",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_ResumeId1",
                table: "WorkExperiences",
                column: "ResumeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_PersonId1",
                table: "Resumes",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_People_PersonId1",
                table: "Resumes",
                column: "PersonId1",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Resumes_ResumeId1",
                table: "WorkExperiences",
                column: "ResumeId1",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
