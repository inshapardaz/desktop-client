﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Inshapardaz.Desktop.Domain.Contexts;

namespace Inshapardaz.Desktop.Domain.Migrations
{
    [DbContext(typeof(ApplicationDatabase))]
    [Migration("20170810201633_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
