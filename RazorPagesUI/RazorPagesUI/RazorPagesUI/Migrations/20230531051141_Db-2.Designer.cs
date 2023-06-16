﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace RazorPagesUI.Migrations
{
    [DbContext(typeof(SurveyDbContext))]
    [Migration("20230531051141_Db-2")]
    partial class Db2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RazorPagesUI.Data.AnswerTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerTemplate");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("RazorPagesUI.Data.CampaignAssignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssignedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AssignedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("AssignmentURL")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeactivatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeactivatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AssignedById");

                    b.HasIndex("CampaignId");

                    b.HasIndex("DeactivatedById");

                    b.HasIndex("UserId", "CampaignId")
                        .IsUnique();

                    b.ToTable("CampaignAssignment");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Institution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Institution");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            Name = "Georgia Southern University"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            Name = "Savannah College of Art and Design"
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            Name = "Georgia State University"
                        },
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            Name = "University of Georgia"
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            Name = "Emory University"
                        });
                });

            modelBuilder.Entity("RazorPagesUI.Data.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnswerType")
                        .HasColumnType("int");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<Guid?>("FollowsAnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QuestionField")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("FollowsAnswerId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Right", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Right");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Create Campaign"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Assign Campaign"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Distribute Campaign"
                        });
                });

            modelBuilder.Entity("RazorPagesUI.Data.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampaignAssignmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeStarted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CampaignAssignmentId");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("RazorPagesUI.Data.SurveyAnswer", b =>
                {
                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("TimeEntered")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAnswer")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("SurveyId", "AnswerTemplateId");

                    b.HasIndex("AnswerTemplateId");

                    b.ToTable("SurveyAnswer");
                });

            modelBuilder.Entity("RazorPagesUI.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid>("InstitutionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            EMail = "eric.landers@fake_email.com",
                            InstitutionId = new Guid("11111111-1111-1111-1111-111111111111"),
                            Name = "Eric Landers"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            EMail = "gsu.one@fake_email.com",
                            InstitutionId = new Guid("11111111-1111-1111-1111-111111111111"),
                            Name = "GSU One"
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            EMail = "gsu.2@fake_email.com",
                            InstitutionId = new Guid("11111111-1111-1111-1111-111111111111"),
                            Name = "GSU 2"
                        },
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            EMail = "scad.1@fake_email.com",
                            InstitutionId = new Guid("22222222-2222-2222-2222-222222222222"),
                            Name = "SCAD 1"
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            EMail = "scad.2@fake_email.com",
                            InstitutionId = new Guid("22222222-2222-2222-2222-222222222222"),
                            Name = "SCAD 2"
                        },
                        new
                        {
                            Id = new Guid("66666666-6666-6666-6666-666666666666"),
                            EMail = "gastate.1@fake_email.com",
                            InstitutionId = new Guid("33333333-3333-3333-3333-333333333333"),
                            Name = "GAState 1"
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777777777"),
                            EMail = "gastate.2@fake_email.com",
                            InstitutionId = new Guid("33333333-3333-3333-3333-333333333333"),
                            Name = "GAState 2"
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888888888"),
                            EMail = "uga.1@fake_email.com",
                            InstitutionId = new Guid("44444444-4444-4444-4444-444444444444"),
                            Name = "UGA 1"
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999999"),
                            EMail = "uga.2@fake_email.com",
                            InstitutionId = new Guid("44444444-4444-4444-4444-444444444444"),
                            Name = "UGA 2"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                            EMail = "eu.1@fake_email.com",
                            InstitutionId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Name = "EU 1"
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                            EMail = "eu.2@fake_email.com",
                            InstitutionId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Name = "EU 2"
                        });
                });

            modelBuilder.Entity("RazorPagesUI.Data.UserRight", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RightId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RightId");

                    b.HasIndex("RightId");

                    b.ToTable("UserRight");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                            RightId = 1
                        },
                        new
                        {
                            UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                            RightId = 2
                        },
                        new
                        {
                            UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                            RightId = 3
                        },
                        new
                        {
                            UserId = new Guid("22222222-2222-2222-2222-222222222222"),
                            RightId = 3
                        },
                        new
                        {
                            UserId = new Guid("33333333-3333-3333-3333-333333333333"),
                            RightId = 3
                        },
                        new
                        {
                            UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("22222222-2222-2222-2222-222222222222"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("33333333-3333-3333-3333-333333333333"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("44444444-4444-4444-4444-444444444444"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("55555555-5555-5555-5555-555555555555"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("66666666-6666-6666-6666-666666666666"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("77777777-7777-7777-7777-777777777777"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("88888888-8888-8888-8888-888888888888"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("99999999-9999-9999-9999-999999999999"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                            RightId = 4
                        },
                        new
                        {
                            UserId = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                            RightId = 4
                        });
                });

            modelBuilder.Entity("RazorPagesUI.Data.AnswerTemplate", b =>
                {
                    b.HasOne("RazorPagesUI.Data.Question", "Question")
                        .WithMany("AnswerTemplates")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Campaign", b =>
                {
                    b.HasOne("RazorPagesUI.Data.User", "CreatedBy")
                        .WithMany("CampaignsCreated")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("RazorPagesUI.Data.CampaignAssignment", b =>
                {
                    b.HasOne("RazorPagesUI.Data.User", "AssignedBy")
                        .WithMany()
                        .HasForeignKey("AssignedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RazorPagesUI.Data.Campaign", "Campaign")
                        .WithMany("CampaignAssignments")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RazorPagesUI.Data.User", "DeactivatedBy")
                        .WithMany()
                        .HasForeignKey("DeactivatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RazorPagesUI.Data.User", "User")
                        .WithMany("CampaignAssignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AssignedBy");

                    b.Navigation("Campaign");

                    b.Navigation("DeactivatedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Question", b =>
                {
                    b.HasOne("RazorPagesUI.Data.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RazorPagesUI.Data.AnswerTemplate", "FollowsAnswer")
                        .WithMany()
                        .HasForeignKey("FollowsAnswerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Campaign");

                    b.Navigation("FollowsAnswer");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Survey", b =>
                {
                    b.HasOne("RazorPagesUI.Data.CampaignAssignment", "CampaignAssignment")
                        .WithMany()
                        .HasForeignKey("CampaignAssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CampaignAssignment");
                });

            modelBuilder.Entity("RazorPagesUI.Data.SurveyAnswer", b =>
                {
                    b.HasOne("RazorPagesUI.Data.AnswerTemplate", "AnswerTemplate")
                        .WithMany("SurveyAnswers")
                        .HasForeignKey("AnswerTemplateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RazorPagesUI.Data.Survey", "Survey")
                        .WithMany("Answers")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AnswerTemplate");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("RazorPagesUI.Data.User", b =>
                {
                    b.HasOne("RazorPagesUI.Data.Institution", "Institution")
                        .WithMany("Users")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("RazorPagesUI.Data.UserRight", b =>
                {
                    b.HasOne("RazorPagesUI.Data.Right", "Right")
                        .WithMany("UserRights")
                        .HasForeignKey("RightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RazorPagesUI.Data.User", "User")
                        .WithMany("UserRights")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Right");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RazorPagesUI.Data.AnswerTemplate", b =>
                {
                    b.Navigation("SurveyAnswers");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Campaign", b =>
                {
                    b.Navigation("CampaignAssignments");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Institution", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Question", b =>
                {
                    b.Navigation("AnswerTemplates");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Right", b =>
                {
                    b.Navigation("UserRights");
                });

            modelBuilder.Entity("RazorPagesUI.Data.Survey", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("RazorPagesUI.Data.User", b =>
                {
                    b.Navigation("CampaignAssignments");

                    b.Navigation("CampaignsCreated");

                    b.Navigation("UserRights");
                });
#pragma warning restore 612, 618
        }
    }
}
