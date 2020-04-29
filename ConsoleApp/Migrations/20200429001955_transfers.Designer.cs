﻿// <auto-generated />
using System;
using LeagueApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeagueApp.Migrations
{
    [DbContext(typeof(VoetbalContext))]
    [Migration("20200429001955_transfers")]
    partial class transfers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Objects.Speler", b =>
                {
                    b.Property<int>("spelerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rugnummer")
                        .HasColumnType("int");

                    b.Property<int?>("teamstamnummer")
                        .HasColumnType("int");

                    b.Property<int>("waarde")
                        .HasColumnType("int");

                    b.HasKey("spelerid");

                    b.HasIndex("teamstamnummer");

                    b.ToTable("spelers");
                });

            modelBuilder.Entity("Model.Objects.Team", b =>
                {
                    b.Property<int>("stamnummer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("naamTrainer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("stamnummer");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("Model.Objects.Transfer", b =>
                {
                    b.Property<int>("transferid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("nieuwe_teamID")
                        .HasColumnType("int");

                    b.Property<int>("oude_teamID")
                        .HasColumnType("int");

                    b.Property<int>("spelerID")
                        .HasColumnType("int");

                    b.Property<int>("transferPrijs")
                        .HasColumnType("int");

                    b.HasKey("transferid");

                    b.HasIndex("nieuwe_teamID");

                    b.HasIndex("oude_teamID");

                    b.HasIndex("spelerID");

                    b.ToTable("transfers");
                });

            modelBuilder.Entity("Model.Objects.Speler", b =>
                {
                    b.HasOne("Model.Objects.Team", "team")
                        .WithMany("spelers")
                        .HasForeignKey("teamstamnummer");
                });

            modelBuilder.Entity("Model.Objects.Transfer", b =>
                {
                    b.HasOne("Model.Objects.Team", "nieuwe_team")
                        .WithMany()
                        .HasForeignKey("nieuwe_teamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Objects.Team", "oude_team")
                        .WithMany()
                        .HasForeignKey("oude_teamID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Model.Objects.Speler", "speler")
                        .WithMany()
                        .HasForeignKey("spelerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
