using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Inshapardaz.Desktop.Domain.Contexts;

namespace Inshapardaz.Desktop.Domain.Migrations.ApplicationDatabaseMigrations
{
    [DbContext(typeof(ApplicationDatabase))]
    partial class ApplicationDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("UseOffline");

                    b.Property<string>("UserInterfaceLanguage");

                    b.HasKey("Id");

                    b.ToTable("Setting");
                });
        }
    }
}
