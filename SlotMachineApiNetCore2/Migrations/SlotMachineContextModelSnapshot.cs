﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using SlotMachineApiNetCore2.Model;

namespace SlotMachineApiNetCore2.Migrations
{
    [DbContext(typeof(SlotMachineContext))]
    partial class SlotMachineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SlotMachineDomain.BetRecord", b =>
                {
                    b.Property<Guid>("BetId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.Property<double>("BetAmount");

                    b.Property<int>("NumRows");

                    b.Property<Guid>("SessionId");

                    b.Property<DateTime>("Timestamp");

                    b.Property<double>("WinAmount");

                    b.HasKey("BetId");

                    b.HasIndex("SessionId");

                    b.ToTable("BetRecords");
                });

            modelBuilder.Entity("SlotMachineDomain.GamblingSession", b =>
                {
                    b.Property<Guid>("SessionId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("FinalBalance");

                    b.Property<double>("InitialBalance");

                    b.Property<int>("PlayerGroup");

                    b.Property<string>("PlayerId");

                    b.Property<DateTime?>("SessionEnd");

                    b.Property<DateTime>("SessionStart");

                    b.Property<int>("TimerInterval");

                    b.Property<int>("TotalNumBets");

                    b.HasKey("SessionId");

                    b.ToTable("GamblingSessions");
                });

            modelBuilder.Entity("SlotMachineDomain.GrcsResponse", b =>
                {
                    b.Property<Guid>("GrcsResponseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Answer");

                    b.Property<int>("NumMinutesPlayed");

                    b.Property<int>("QuestionId");

                    b.Property<Guid>("SessionId");

                    b.HasKey("GrcsResponseId");

                    b.HasIndex("SessionId");

                    b.ToTable("GrcsResponses");
                });

            modelBuilder.Entity("SlotMachineDomain.BetRecord", b =>
                {
                    b.HasOne("SlotMachineDomain.GamblingSession", "Session")
                        .WithMany("BetRecords")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SlotMachineDomain.GrcsResponse", b =>
                {
                    b.HasOne("SlotMachineDomain.GamblingSession", "Session")
                        .WithMany("GrcsResponses")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
