﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalCore.DataAccess;

namespace PortalCore.DataAccess.Migrations
{
    [DbContext(typeof(PagesContext))]
    [Migration("20190318214933_models4")]
    partial class models4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Conditional", b =>
                {
                    b.Property<int>("ConditionalId");

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.Property<int>("ModelId");

                    b.HasKey("ConditionalId");

                    b.HasIndex("ModelId");

                    b.ToTable("Conditionals");
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Design", b =>
                {
                    b.Property<int>("DesignId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive");

                    b.Property<int>("Order");

                    b.Property<int>("PageId");

                    b.HasKey("DesignId");

                    b.HasIndex("PageId");

                    b.ToTable("Design");
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Endpoint", b =>
                {
                    b.Property<int>("EndpointId");

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsList");

                    b.Property<string>("Method");

                    b.Property<int>("ModelId");

                    b.HasKey("EndpointId");

                    b.HasIndex("ModelId");

                    b.ToTable("Endpoints");
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Model", b =>
                {
                    b.Property<int>("ModelId");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Namespace");

                    b.HasKey("ModelId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MasterPageId");

                    b.Property<int?>("ModelId");

                    b.Property<string>("Name");

                    b.Property<int>("PageType");

                    b.Property<int?>("ReservedPage");

                    b.HasKey("PageId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Parameter", b =>
                {
                    b.Property<int>("ParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName");

                    b.Property<int>("EndpointId");

                    b.Property<int>("Type");

                    b.HasKey("ParameterId");

                    b.HasIndex("EndpointId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Property", b =>
                {
                    b.Property<int>("PropertyId");

                    b.Property<int?>("ChildModelId");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsList");

                    b.Property<int>("ModelId");

                    b.Property<int?>("Type");

                    b.HasKey("PropertyId");

                    b.HasIndex("ChildModelId");

                    b.HasIndex("ModelId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.View", b =>
                {
                    b.Property<int>("ViewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PageId");

                    b.Property<string>("Razor");

                    b.HasKey("ViewId");

                    b.HasIndex("PageId");

                    b.ToTable("Views");
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Conditional", b =>
                {
                    b.HasOne("PortalCore.Models.Internal.Entites.Model", "Model")
                        .WithMany("Conditionals")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Design", b =>
                {
                    b.HasOne("PortalCore.Models.Internal.Entites.Page", "Page")
                        .WithMany("Designs")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Endpoint", b =>
                {
                    b.HasOne("PortalCore.Models.Internal.Entites.Model", "Model")
                        .WithMany("Endpoints")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Parameter", b =>
                {
                    b.HasOne("PortalCore.Models.Internal.Entites.Endpoint", "Endpoint")
                        .WithMany("Parameters")
                        .HasForeignKey("EndpointId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.Property", b =>
                {
                    b.HasOne("PortalCore.Models.Internal.Entites.Model", "ChildModel")
                        .WithMany("ParentProperties")
                        .HasForeignKey("ChildModelId");

                    b.HasOne("PortalCore.Models.Internal.Entites.Model", "Model")
                        .WithMany("ChildProperties")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortalCore.Models.Internal.Entites.View", b =>
                {
                    b.HasOne("PortalCore.Models.Internal.Entites.Page", "Page")
                        .WithMany("Views")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
