﻿// <auto-generated />
using System;
using ARS_DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ARS_DAL.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230224071224_SET_1_Migration")]
    partial class SET_1_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ARS_Models.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticipantId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("ARS_Models.SessionDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.Property<string>("UploadLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SessionDetails");
                });

            modelBuilder.Entity("ARS_Models.SessionParticipantsMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("SessionDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId", "SessionDetailsId")
                        .IsUnique();

                    b.ToTable("SessionParticipantsMapping");
                });

            modelBuilder.Entity("ARS_Models.SessionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("SessionType");
                });
#pragma warning restore 612, 618
        }
    }
}
