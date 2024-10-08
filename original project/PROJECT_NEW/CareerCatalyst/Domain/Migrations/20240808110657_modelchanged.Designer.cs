﻿// <auto-generated />
using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(NewDbContext))]
    [Migration("20240808110657_modelchanged")]
    partial class modelchanged
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.AuthUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConnectionId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("OnlineStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthUser", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Breed", b =>
                {
                    b.Property<Guid>("Category")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("Breed", (string)null);
                });

            modelBuilder.Entity("Domain.Models.CompanyUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Company")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Company" }, "IX_CompanyUser_Company");

                    b.ToTable("CompanyUser", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Industry", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Industry", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Interview", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("Interviewee")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("interviewee");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SheduledBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ApplicationId" }, "IX_Interviews_ApplicationId");

                    b.HasIndex(new[] { "CompanyId" }, "IX_Interviews_CompanyId");

                    b.HasIndex(new[] { "JobId" }, "IX_Interviews_JobId");

                    b.HasIndex(new[] { "SheduledBy" }, "IX_Interviews_SheduledBy");

                    b.HasIndex(new[] { "Interviewee" }, "IX_Interviews_interviewee");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("Domain.Models.JobApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Applicant")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datesubmitted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JobPostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("JobPost_id");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Resume_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Applicant" }, "IX_JobApplications_Applicant");

                    b.HasIndex(new[] { "JobPostId" }, "IX_JobApplications_JobPost_id");

                    b.HasIndex(new[] { "ResumeId" }, "IX_JobApplications_Resume_id");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("Domain.Models.JobCategory", b =>
                {
                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.ToTable("JobCategory", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobPost", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IndustryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobSummary")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "LocationId" }, "IX_JobPost_JobLocation");

                    b.HasIndex(new[] { "PostedBy" }, "IX_JobPost_PostedBy");

                    b.ToTable("JobPost", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobProviderCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("IndustryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LegalName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Location")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IndustryId" }, "IX_JobProviderCompany_IndustryId");

                    b.HasIndex(new[] { "Location" }, "IX_JobProviderCompany_Location");

                    b.ToTable("JobProviderCompany", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobResponsibility", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<Guid>("JobPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex(new[] { "JobPost" }, "IX_JobResponsibility_JobPost");

                    b.ToTable("JobResponsibility", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobSeeker", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobSeekers");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobSeekerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProfileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "JobSeekerId" }, "IX_JobSeekerProfile_JobSeekerId");

                    b.HasIndex(new[] { "ResumeId" }, "IX_JobSeekerProfile_ResumeId");

                    b.ToTable("JobSeekerProfile", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfileSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JobSeekerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JobSeekerProfileId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSeekerProfileSkills");
                });

            modelBuilder.Entity("Domain.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Profile1", b =>
                {
                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varbinary(50)");

                    b.Property<byte[]>("ProfileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varbinary(50)");

                    b.Property<Guid>("User")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("Profile", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Qualification", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("JobPostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JobseekerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "JobPostId" }, "IX_Qualification_JobPostId");

                    b.HasIndex(new[] { "JobseekerProfileId" }, "IX_Qualification_JobseekerProfileId");

                    b.ToTable("Qualification", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Resume", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Resume", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Role", b =>
                {
                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Domain.Models.SavedJob", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Job")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SavedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Job" }, "IX_SavedJobs_Job");

                    b.HasIndex(new[] { "SavedBy" }, "IX_SavedJobs_SavedBy");

                    b.ToTable("SavedJobs");
                });

            modelBuilder.Entity("Domain.Models.SignUpRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SignUpRequests");
                });

            modelBuilder.Entity("Domain.Models.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Skill", (string)null);
                });

            modelBuilder.Entity("Domain.Models.WorkExperience", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobSeekerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ServiceEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ServiceStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Experiences");

                    b.HasIndex(new[] { "JobSeekerProfileId" }, "IX_WorkExperience_JobSeekerProfileId");

                    b.ToTable("WorkExperience", (string)null);
                });

            modelBuilder.Entity("JobSeekerProfileSkill", b =>
                {
                    b.Property<Guid>("JobSeekerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JobSeekerProfileId", "SkillId");

                    b.HasIndex(new[] { "SkillId" }, "IX_JobSeekerProfileSkill_SkillId");

                    b.ToTable("JobSeekerProfileSkill", (string)null);
                });

            modelBuilder.Entity("Domain.Models.CompanyUser", b =>
                {
                    b.HasOne("Domain.Models.JobProviderCompany", "CompanyNavigation")
                        .WithMany("CompanyUsers")
                        .HasForeignKey("Company")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_CompanyUser_JobProviderCompany");

                    b.Navigation("CompanyNavigation");
                });

            modelBuilder.Entity("Domain.Models.Interview", b =>
                {
                    b.HasOne("Domain.Models.JobApplication", "Application")
                        .WithMany("Interviews")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("Domain.Models.JobProviderCompany", "Company")
                        .WithMany("Interviews")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.JobSeeker", "IntervieweeNavigation")
                        .WithMany("Interviews")
                        .HasForeignKey("Interviewee");

                    b.HasOne("Domain.Models.JobPost", "Job")
                        .WithMany("Interviews")
                        .HasForeignKey("JobId");

                    b.HasOne("Domain.Models.CompanyUser", "SheduledByNavigation")
                        .WithMany("Interviews")
                        .HasForeignKey("SheduledBy");

                    b.Navigation("Application");

                    b.Navigation("Company");

                    b.Navigation("IntervieweeNavigation");

                    b.Navigation("Job");

                    b.Navigation("SheduledByNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobApplication", b =>
                {
                    b.HasOne("Domain.Models.JobSeeker", "ApplicantNavigation")
                        .WithMany("JobApplications")
                        .HasForeignKey("Applicant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.JobPost", "JobPost")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Resume", "Resume")
                        .WithMany("JobApplications")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicantNavigation");

                    b.Navigation("JobPost");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("Domain.Models.JobPost", b =>
                {
                    b.HasOne("Domain.Models.Location", "Location")
                        .WithMany("JobPosts")
                        .HasForeignKey("LocationId")
                        .IsRequired()
                        .HasConstraintName("FK_JobPost_Location");

                    b.HasOne("Domain.Models.CompanyUser", "PostedByNavigation")
                        .WithMany("JobPosts")
                        .HasForeignKey("PostedBy")
                        .IsRequired()
                        .HasConstraintName("FK_JobPost_Industry");

                    b.Navigation("Location");

                    b.Navigation("PostedByNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobProviderCompany", b =>
                {
                    b.HasOne("Domain.Models.Industry", "Industry")
                        .WithMany("JobProviderCompanies")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Location", "LocationNavigation")
                        .WithMany("JobProviderCompanies")
                        .HasForeignKey("Location")
                        .IsRequired()
                        .HasConstraintName("FK_JobProviderCompany_Location");

                    b.Navigation("Industry");

                    b.Navigation("LocationNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobResponsibility", b =>
                {
                    b.HasOne("Domain.Models.JobPost", "JobPostNavigation")
                        .WithMany("JobResponsibilities")
                        .HasForeignKey("JobPost")
                        .IsRequired()
                        .HasConstraintName("FK_JobResponsibility_JobPost");

                    b.Navigation("JobPostNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfile", b =>
                {
                    b.HasOne("Domain.Models.JobSeeker", "JobSeeker")
                        .WithMany("JobSeekerProfiles")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Resume", "Resume")
                        .WithMany("JobSeekerProfiles")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("JobSeeker");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfileSkill", b =>
                {
                    b.HasOne("Domain.Models.JobSeekerProfile", "JobseekerProfile")
                        .WithMany()
                        .HasForeignKey("JobSeekerProfileId");

                    b.HasOne("Domain.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId");

                    b.Navigation("JobseekerProfile");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Domain.Models.Qualification", b =>
                {
                    b.HasOne("Domain.Models.JobPost", "JobPost")
                        .WithMany("Qualifications")
                        .HasForeignKey("JobPostId")
                        .HasConstraintName("FK_Qualification_JobSeekerProfile");

                    b.HasOne("Domain.Models.JobSeekerProfile", "JobseekerProfile")
                        .WithMany("Qualifications")
                        .HasForeignKey("JobseekerProfileId");

                    b.Navigation("JobPost");

                    b.Navigation("JobseekerProfile");
                });

            modelBuilder.Entity("Domain.Models.SavedJob", b =>
                {
                    b.HasOne("Domain.Models.JobPost", "JobNavigation")
                        .WithMany("SavedJobs")
                        .HasForeignKey("Job")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.JobSeeker", "SavedByNavigation")
                        .WithMany("SavedJobs")
                        .HasForeignKey("SavedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobNavigation");

                    b.Navigation("SavedByNavigation");
                });

            modelBuilder.Entity("Domain.Models.WorkExperience", b =>
                {
                    b.HasOne("Domain.Models.JobSeekerProfile", "JobSeekerProfile")
                        .WithMany("WorkExperiences")
                        .HasForeignKey("JobSeekerProfileId")
                        .IsRequired()
                        .HasConstraintName("FK_WorkExperience_JobSeekerProfile");

                    b.Navigation("JobSeekerProfile");
                });

            modelBuilder.Entity("JobSeekerProfileSkill", b =>
                {
                    b.HasOne("Domain.Models.JobSeekerProfile", null)
                        .WithMany()
                        .HasForeignKey("JobSeekerProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.CompanyUser", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("Domain.Models.Industry", b =>
                {
                    b.Navigation("JobProviderCompanies");
                });

            modelBuilder.Entity("Domain.Models.JobApplication", b =>
                {
                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("Domain.Models.JobPost", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("JobApplications");

                    b.Navigation("JobResponsibilities");

                    b.Navigation("Qualifications");

                    b.Navigation("SavedJobs");
                });

            modelBuilder.Entity("Domain.Models.JobProviderCompany", b =>
                {
                    b.Navigation("CompanyUsers");

                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("Domain.Models.JobSeeker", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("JobApplications");

                    b.Navigation("JobSeekerProfiles");

                    b.Navigation("SavedJobs");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfile", b =>
                {
                    b.Navigation("Qualifications");

                    b.Navigation("WorkExperiences");
                });

            modelBuilder.Entity("Domain.Models.Location", b =>
                {
                    b.Navigation("JobPosts");

                    b.Navigation("JobProviderCompanies");
                });

            modelBuilder.Entity("Domain.Models.Resume", b =>
                {
                    b.Navigation("JobApplications");

                    b.Navigation("JobSeekerProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
