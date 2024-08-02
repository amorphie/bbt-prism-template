﻿// <auto-generated />
using System;
using BBT.MyProjectName.EntityFrameworkCore;
using BBT.Prism.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BBT.MyProjectName.Migrations
{
    [DbContext(typeof(MyProjectNameDbContext))]
    [Migration("20240718201231_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Prism_DatabaseProvider", EfCoreDatabaseProvider.PostgreSql)
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BBT.MyProjectName.Issues.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<Guid>("IssueId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("BBT.MyProjectName.Issues.GitRepository", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)");

                    b.HasKey("Id");

                    b.ToTable("Repositories", (string)null);
                });

            modelBuilder.Entity("BBT.MyProjectName.Issues.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AssignedUserId")
                        .HasColumnType("uuid");

                    b.Property<int?>("CloseReason")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedByBehalfOf")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastCommentTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ModifiedAt");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("ModifiedBy");

                    b.Property<Guid?>("ModifiedByBehalfOf")
                        .HasColumnType("uuid")
                        .HasColumnName("ModifiedByBehalfOf");

                    b.Property<Guid>("RepositoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Issues", (string)null);
                });

            modelBuilder.Entity("BBT.MyProjectName.Issues.Label", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Labels", (string)null);
                });

            modelBuilder.Entity("BBT.MyProjectName.Issues.Comment", b =>
                {
                    b.HasOne("BBT.MyProjectName.Issues.Issue", null)
                        .WithMany("Comments")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BBT.MyProjectName.Issues.Issue", b =>
                {
                    b.HasOne("BBT.MyProjectName.Issues.GitRepository", null)
                        .WithMany()
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("BBT.MyProjectName.Issues.IssueLabel", "Labels", b1 =>
                        {
                            b1.Property<Guid>("IssueId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("LabelId")
                                .HasColumnType("uuid");

                            b1.HasKey("IssueId", "LabelId");

                            b1.HasIndex("LabelId");

                            b1.ToTable("IssueLabels", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("IssueId");

                            b1.HasOne("BBT.MyProjectName.Issues.Label", null)
                                .WithMany()
                                .HasForeignKey("LabelId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();
                        });

                    b.Navigation("Labels");
                });

            modelBuilder.Entity("BBT.MyProjectName.Issues.Issue", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
