﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OPGAVESTYRINGSSYSTEM;

#nullable disable

namespace OPGAVESTYRINGSSYSTEM.Migrations
{
    [DbContext(typeof(OpgaveStyringsDBContext))]
    [Migration("20221014085543_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Task", b =>
                {
                    b.Property<int?>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Team", b =>
                {
                    b.Property<int?>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentTaskTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.HasIndex("CurrentTaskTaskId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.TeamWorker", b =>
                {
                    b.Property<int?>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("WorkerId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamWorkers");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Todo", b =>
                {
                    b.Property<int?>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoId");

                    b.HasIndex("TaskId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Worker", b =>
                {
                    b.Property<int?>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentTodoTodoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("WorkerId");

                    b.HasIndex("CurrentTodoTodoId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Team", b =>
                {
                    b.HasOne("OPGAVESTYRINGSSYSTEM.Model.Task", "CurrentTask")
                        .WithMany()
                        .HasForeignKey("CurrentTaskTaskId");

                    b.Navigation("CurrentTask");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.TeamWorker", b =>
                {
                    b.HasOne("OPGAVESTYRINGSSYSTEM.Model.Team", "Team")
                        .WithMany("TeanWorkers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OPGAVESTYRINGSSYSTEM.Model.Worker", "Worker")
                        .WithMany("TeamWorker")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Todo", b =>
                {
                    b.HasOne("OPGAVESTYRINGSSYSTEM.Model.Task", null)
                        .WithMany("Todos")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Worker", b =>
                {
                    b.HasOne("OPGAVESTYRINGSSYSTEM.Model.Todo", "CurrentTodo")
                        .WithMany()
                        .HasForeignKey("CurrentTodoTodoId");

                    b.Navigation("CurrentTodo");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Task", b =>
                {
                    b.Navigation("Todos");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Team", b =>
                {
                    b.Navigation("TeanWorkers");
                });

            modelBuilder.Entity("OPGAVESTYRINGSSYSTEM.Model.Worker", b =>
                {
                    b.Navigation("TeamWorker");
                });
#pragma warning restore 612, 618
        }
    }
}