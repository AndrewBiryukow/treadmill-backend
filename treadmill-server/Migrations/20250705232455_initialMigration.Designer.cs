﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using treadmill_server.Contexts;

#nullable disable

namespace treadmill_server.Migrations
{
    [DbContext(typeof(TreadmillEfCoreContext))]
    [Migration("20250705232455_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("treadmill_server.Entities.FitnessMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("DeviceLocalId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("device_local_id");

                    b.Property<int>("DeviceType")
                        .HasColumnType("integer")
                        .HasColumnName("device_type");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_fitness_machines");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_fitness_machines_user_id");

                    b.ToTable("fitness_machines", (string)null);
                });

            modelBuilder.Entity("treadmill_server.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("treadmill_server.Entities.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Calories")
                        .HasColumnType("integer")
                        .HasColumnName("calories");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Distance")
                        .HasColumnType("integer")
                        .HasColumnName("distance");

                    b.Property<int>("FitnessMachineId")
                        .HasColumnType("integer")
                        .HasColumnName("fitness_machine_id");

                    b.Property<int>("Time")
                        .HasColumnType("integer")
                        .HasColumnName("time");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_workouts");

                    b.HasIndex("FitnessMachineId")
                        .HasDatabaseName("ix_workouts_fitness_machine_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_workouts_user_id");

                    b.ToTable("workouts", (string)null);
                });

            modelBuilder.Entity("treadmill_server.Entities.FitnessMachine", b =>
                {
                    b.HasOne("treadmill_server.Entities.User", null)
                        .WithMany("FitnessMachines")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_fitness_machines_users_user_id");
                });

            modelBuilder.Entity("treadmill_server.Entities.Workout", b =>
                {
                    b.HasOne("treadmill_server.Entities.FitnessMachine", null)
                        .WithMany("Workouts")
                        .HasForeignKey("FitnessMachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workouts_fitness_machines_fitness_machine_id");

                    b.HasOne("treadmill_server.Entities.User", null)
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workouts_users_user_id");
                });

            modelBuilder.Entity("treadmill_server.Entities.FitnessMachine", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("treadmill_server.Entities.User", b =>
                {
                    b.Navigation("FitnessMachines");

                    b.Navigation("Workouts");
                });
#pragma warning restore 612, 618
        }
    }
}
