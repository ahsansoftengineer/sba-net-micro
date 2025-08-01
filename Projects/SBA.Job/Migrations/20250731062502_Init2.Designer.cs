﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SBA.Projectz.Data;

#nullable disable

namespace SBA.Job.Migrations
{
    [DbContext(typeof(DBCtxProjectz))]
    [Migration("20250731062502_Init2")]
    partial class Init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GLOB.Hierarchy.Global.GlobalLookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("Created_At");

                    b.Property<string>("Desc")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnOrder(4);

                    b.Property<int?>("GlobalLookupBaseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnOrder(3);

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("Updated_At");

                    b.HasKey("Id");

                    b.HasIndex("GlobalLookupBaseId");

                    b.ToTable("GlobalLookups");
                });

            modelBuilder.Entity("GLOB.Hierarchy.Global.GlobalLookupBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("Created_At");

                    b.Property<string>("Desc")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnOrder(3);

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("Updated_At");

                    b.HasKey("Id");

                    b.ToTable("GlobalLookupBases");
                });

            modelBuilder.Entity("GLOB.Infra.Model.Base.ProjectzLookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("Created_At");

                    b.Property<string>("Desc")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnOrder(3);

                    b.Property<int?>("ProjectzLookupBaseId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("Updated_At");

                    b.HasKey("Id");

                    b.HasIndex("ProjectzLookupBaseId");

                    b.ToTable("ProjectzLookups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "111-111-111",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)),
                            Desc = "ProjectzLookup 1 Desc",
                            Name = "ProjectzLookup 1",
                            ProjectzLookupBaseId = 1,
                            Status = 0,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0))
                        },
                        new
                        {
                            Id = 2,
                            Code = "222-222-222",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)),
                            Desc = "ProjectzLookup 2 Desc",
                            Name = "ProjectzLookup 2",
                            ProjectzLookupBaseId = 2,
                            Status = 0,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0))
                        },
                        new
                        {
                            Id = 3,
                            Code = "333-333-333",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)),
                            Desc = "ProjectzLookup 3 Desc",
                            Name = "ProjectzLookup 3",
                            ProjectzLookupBaseId = 3,
                            Status = 0,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("GLOB.Infra.Model.Base.ProjectzLookupBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("Created_At");

                    b.Property<string>("Desc")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnOrder(3);

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("Updated_At");

                    b.HasKey("Id");

                    b.ToTable("ProjectzLookupBases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)),
                            Desc = "ProjectzLookupBase 1 Desc",
                            Name = "ProjectzLookupBase 1",
                            Status = 0,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0))
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)),
                            Desc = "ProjectzLookupBase 2 Desc",
                            Name = "ProjectzLookupBase 2",
                            Status = 0,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0))
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)),
                            Desc = "ProjectzLookupBase 3 Desc",
                            Name = "ProjectzLookupBase 3",
                            Status = 0,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("GLOB.Hierarchy.Global.GlobalLookup", b =>
                {
                    b.HasOne("GLOB.Hierarchy.Global.GlobalLookupBase", "GlobalLookupBase")
                        .WithMany("GlobalLookup")
                        .HasForeignKey("GlobalLookupBaseId");

                    b.Navigation("GlobalLookupBase");
                });

            modelBuilder.Entity("GLOB.Infra.Model.Base.ProjectzLookup", b =>
                {
                    b.HasOne("GLOB.Infra.Model.Base.ProjectzLookupBase", "ProjectzLookupBase")
                        .WithMany("ProjectzLookups")
                        .HasForeignKey("ProjectzLookupBaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ProjectzLookupBase");
                });

            modelBuilder.Entity("GLOB.Hierarchy.Global.GlobalLookupBase", b =>
                {
                    b.Navigation("GlobalLookup");
                });

            modelBuilder.Entity("GLOB.Infra.Model.Base.ProjectzLookupBase", b =>
                {
                    b.Navigation("ProjectzLookups");
                });
#pragma warning restore 612, 618
        }
    }
}
