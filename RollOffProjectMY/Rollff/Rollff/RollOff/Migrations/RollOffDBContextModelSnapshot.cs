﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RollOff.Data;

namespace RollOff.Migrations
{
    [DbContext(typeof(RollOffDBContext))]
    partial class RollOffDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RollOff.Models.Domain.AssignedFrom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignedTo")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FeedbackFormId")
                        .HasColumnType("int");

                    b.Property<int>("RollOffFormId")
                        .HasColumnType("int");

                    b.Property<int>("UserDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AssignedFrom");
                });

            modelBuilder.Entity("RollOff.Models.Domain.Employee", b =>
                {
                    b.Property<int>("GlobalGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeNo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocalGrade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewGlobalPractice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PSPName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeopleManager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Practice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProjectEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProjectStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GlobalGroupID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RollOff.Models.Domain.FeedbackForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Communication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelevantExperience")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleCompetance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnicalSkill")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FeedbackForm");
                });

            modelBuilder.Entity("RollOff.Models.Domain.RollOffForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeaveType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LongLeave")
                        .HasColumnType("bit");

                    b.Property<string>("OtherReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PerformanceIssue")
                        .HasColumnType("bit");

                    b.Property<string>("PrimarySkill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Resgined")
                        .HasColumnType("bit");

                    b.Property<bool>("UnderProbation")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RollOffForm");
                });

            modelBuilder.Entity("RollOff.Models.Domain.TransferedFrom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignedFrom")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAactivate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTransfered")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TransferedFrom");
                });

            modelBuilder.Entity("RollOff.Models.Domain.UserDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
