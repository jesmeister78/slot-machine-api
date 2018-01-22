﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SlotMachineApiNetCore2.Model;

namespace SlotMachineApiNetCore2.Migrations
{
    [DbContext(typeof(SlotMachineContext))]
    [Migration("20180119154714_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("SlotMachineDomain.BetRecord", b =>
                {
                    b.Property<string>("PlayerId");

                    b.Property<double>("Balance");

                    b.Property<double>("BetAmount");

                    b.Property<int>("NumRows");

                    b.Property<DateTime>("Timestamp");

                    b.Property<double>("WinAmount");

                    b.HasKey("PlayerId");

                    b.ToTable("BetRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
