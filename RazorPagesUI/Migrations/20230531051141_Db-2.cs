using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RazorPagesUI.Migrations
{
    /// <inheritdoc />
    public partial class Db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Right",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Right", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    InstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InactiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaign_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRight",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRight", x => new { x.UserId, x.RightId });
                    table.ForeignKey(
                        name: "FK_UserRight_Right_RightId",
                        column: x => x.RightId,
                        principalTable: "Right",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRight_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignAssignment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignmentURL = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeactivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignAssignment_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignAssignment_User_AssignedById",
                        column: x => x.AssignedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignAssignment_User_DeactivatedById",
                        column: x => x.DeactivatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignAssignment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignAssignmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_CampaignAssignment_CampaignAssignmentId",
                        column: x => x.CampaignAssignmentId,
                        principalTable: "CampaignAssignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionField = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    FollowsAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnswerType = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_AnswerTemplate_FollowsAnswerId",
                        column: x => x.FollowsAnswerId,
                        principalTable: "AnswerTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswer",
                columns: table => new
                {
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAnswer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TimeEntered = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswer", x => new { x.SurveyId, x.AnswerTemplateId });
                    table.ForeignKey(
                        name: "FK_SurveyAnswer_AnswerTemplate_AnswerTemplateId",
                        column: x => x.AnswerTemplateId,
                        principalTable: "AnswerTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyAnswer_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Institution",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Georgia Southern University" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Savannah College of Art and Design" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Georgia State University" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "University of Georgia" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Emory University" }
                });

            migrationBuilder.InsertData(
                table: "Right",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Create Campaign" },
                    { 3, "Assign Campaign" },
                    { 4, "Distribute Campaign" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "EMail", "InstitutionId", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "eric.landers@fake_email.com", new Guid("11111111-1111-1111-1111-111111111111"), "Eric Landers" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "gsu.one@fake_email.com", new Guid("11111111-1111-1111-1111-111111111111"), "GSU One" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "gsu.2@fake_email.com", new Guid("11111111-1111-1111-1111-111111111111"), "GSU 2" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "scad.1@fake_email.com", new Guid("22222222-2222-2222-2222-222222222222"), "SCAD 1" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "scad.2@fake_email.com", new Guid("22222222-2222-2222-2222-222222222222"), "SCAD 2" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "gastate.1@fake_email.com", new Guid("33333333-3333-3333-3333-333333333333"), "GAState 1" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "gastate.2@fake_email.com", new Guid("33333333-3333-3333-3333-333333333333"), "GAState 2" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "uga.1@fake_email.com", new Guid("44444444-4444-4444-4444-444444444444"), "UGA 1" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "uga.2@fake_email.com", new Guid("44444444-4444-4444-4444-444444444444"), "UGA 2" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "eu.1@fake_email.com", new Guid("55555555-5555-5555-5555-555555555555"), "EU 1" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "eu.2@fake_email.com", new Guid("55555555-5555-5555-5555-555555555555"), "EU 2" }
                });

            migrationBuilder.InsertData(
                table: "UserRight",
                columns: new[] { "RightId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("11111111-1111-1111-1111-111111111111") },
                    { 2, new Guid("11111111-1111-1111-1111-111111111111") },
                    { 3, new Guid("11111111-1111-1111-1111-111111111111") },
                    { 4, new Guid("11111111-1111-1111-1111-111111111111") },
                    { 3, new Guid("22222222-2222-2222-2222-222222222222") },
                    { 4, new Guid("22222222-2222-2222-2222-222222222222") },
                    { 3, new Guid("33333333-3333-3333-3333-333333333333") },
                    { 4, new Guid("33333333-3333-3333-3333-333333333333") },
                    { 4, new Guid("44444444-4444-4444-4444-444444444444") },
                    { 4, new Guid("55555555-5555-5555-5555-555555555555") },
                    { 4, new Guid("66666666-6666-6666-6666-666666666666") },
                    { 4, new Guid("77777777-7777-7777-7777-777777777777") },
                    { 4, new Guid("88888888-8888-8888-8888-888888888888") },
                    { 4, new Guid("99999999-9999-9999-9999-999999999999") },
                    { 4, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerTemplate_QuestionId",
                table: "AnswerTemplate",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_UserId",
                table: "Campaign",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAssignment_AssignedById",
                table: "CampaignAssignment",
                column: "AssignedById");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAssignment_CampaignId",
                table: "CampaignAssignment",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAssignment_DeactivatedById",
                table: "CampaignAssignment",
                column: "DeactivatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAssignment_UserId_CampaignId",
                table: "CampaignAssignment",
                columns: new[] { "UserId", "CampaignId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_CampaignId",
                table: "Question",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_FollowsAnswerId",
                table: "Question",
                column: "FollowsAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_CampaignAssignmentId",
                table: "Survey",
                column: "CampaignAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswer_AnswerTemplateId",
                table: "SurveyAnswer",
                column: "AnswerTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_InstitutionId",
                table: "User",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRight_RightId",
                table: "UserRight",
                column: "RightId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerTemplate_Question_QuestionId",
                table: "AnswerTemplate",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerTemplate_Question_QuestionId",
                table: "AnswerTemplate");

            migrationBuilder.DropTable(
                name: "SurveyAnswer");

            migrationBuilder.DropTable(
                name: "UserRight");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Right");

            migrationBuilder.DropTable(
                name: "CampaignAssignment");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "AnswerTemplate");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Institution");
        }
    }
}
