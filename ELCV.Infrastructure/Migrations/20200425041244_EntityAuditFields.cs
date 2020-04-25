using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELCV.Infrastructure.Migrations
{
    public partial class EntityAuditFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_People_PersonId",
                table: "PersonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_Skills_SkillId",
                table: "PersonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSkill_Resumes_ResumeId",
                table: "ResumeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSkill_Skills_SkillId",
                table: "ResumeSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResumeSkill",
                table: "ResumeSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSkill",
                table: "PersonSkill");

            migrationBuilder.RenameTable(
                name: "ResumeSkill",
                newName: "ResumeSkills");

            migrationBuilder.RenameTable(
                name: "PersonSkill",
                newName: "PersonSkills");

            migrationBuilder.RenameIndex(
                name: "IX_ResumeSkill_SkillId",
                table: "ResumeSkills",
                newName: "IX_ResumeSkills_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_ResumeSkill_ResumeId",
                table: "ResumeSkills",
                newName: "IX_ResumeSkills_ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSkill_SkillId",
                table: "PersonSkills",
                newName: "IX_PersonSkills_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSkill_PersonId",
                table: "PersonSkills",
                newName: "IX_PersonSkills_PersonId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "WorkExperiences",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "WorkExperiences",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "WorkExperiences",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "WorkExperiences",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "SystemParameters",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "SystemParameters",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "SystemParameters",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "SystemParameters",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "States",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "States",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "States",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "States",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "SkillTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "SkillTypes",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "SkillTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "SkillTypes",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Skills",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Skills",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Resumes",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Resumes",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Resumes",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Resumes",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "People",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "People",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Countries",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Countries",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Cities",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Cities",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Addresses",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Addresses",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "ResumeSkills",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "ResumeSkills",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "ResumeSkills",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "ResumeSkills",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "PersonSkills",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PersonSkills",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "PersonSkills",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "PersonSkills",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResumeSkills",
                table: "ResumeSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSkills",
                table: "PersonSkills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkills_People_PersonId",
                table: "PersonSkills",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkills_Skills_SkillId",
                table: "PersonSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSkills_Resumes_ResumeId",
                table: "ResumeSkills",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSkills_Skills_SkillId",
                table: "ResumeSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkills_People_PersonId",
                table: "PersonSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkills_Skills_SkillId",
                table: "PersonSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSkills_Resumes_ResumeId",
                table: "ResumeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSkills_Skills_SkillId",
                table: "ResumeSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResumeSkills",
                table: "ResumeSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSkills",
                table: "PersonSkills");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "SystemParameters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SystemParameters");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "SystemParameters");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SystemParameters");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "States");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "States");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "SkillTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SkillTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "SkillTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SkillTypes");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "ResumeSkills");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ResumeSkills");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "ResumeSkills");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ResumeSkills");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "PersonSkills");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PersonSkills");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "PersonSkills");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PersonSkills");

            migrationBuilder.RenameTable(
                name: "ResumeSkills",
                newName: "ResumeSkill");

            migrationBuilder.RenameTable(
                name: "PersonSkills",
                newName: "PersonSkill");

            migrationBuilder.RenameIndex(
                name: "IX_ResumeSkills_SkillId",
                table: "ResumeSkill",
                newName: "IX_ResumeSkill_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_ResumeSkills_ResumeId",
                table: "ResumeSkill",
                newName: "IX_ResumeSkill_ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSkills_SkillId",
                table: "PersonSkill",
                newName: "IX_PersonSkill_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSkills_PersonId",
                table: "PersonSkill",
                newName: "IX_PersonSkill_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResumeSkill",
                table: "ResumeSkill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSkill",
                table: "PersonSkill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_People_PersonId",
                table: "PersonSkill",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_Skills_SkillId",
                table: "PersonSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSkill_Resumes_ResumeId",
                table: "ResumeSkill",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSkill_Skills_SkillId",
                table: "ResumeSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
