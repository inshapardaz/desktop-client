using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Inshapardaz.Desktop.Domain.Contexts;
using Inshapardaz.Desktop.Domain.Entities.Dictionary;

namespace Inshapardaz.Desktop.Domain.Migrations
{
    [DbContext(typeof(DictionaryDatabase))]
    partial class DictionaryDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.Dictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsPublic");

                    b.Property<int>("Language");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("UserId")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Dictionary");
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.Meaning", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Context");

                    b.Property<string>("Example");

                    b.Property<string>("Value");

                    b.Property<long>("WordDetailId");

                    b.HasKey("Id");

                    b.HasIndex("WordDetailId");

                    b.ToTable("Meaning");
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.Translation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Language");

                    b.Property<string>("Value");

                    b.Property<long>("WordDetailId");

                    b.HasKey("Id");

                    b.HasIndex("WordDetailId");

                    b.ToTable("Translation");
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DictionaryId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Pronunciation");

                    b.Property<string>("Title");

                    b.Property<string>("TitleWithMovements");

                    b.HasKey("Id");

                    b.HasIndex("DictionaryId");

                    b.ToTable("Word");
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.WordDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Attributes");

                    b.Property<int>("Language");

                    b.Property<long>("WordInstanceId");

                    b.HasKey("Id");

                    b.HasIndex("WordInstanceId");

                    b.ToTable("WordDetail");
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.WordRelation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("RelatedWordId");

                    b.Property<int>("RelationType");

                    b.Property<long>("SourceWordId");

                    b.HasKey("Id");

                    b.HasIndex("RelatedWordId");

                    b.HasIndex("SourceWordId");

                    b.ToTable("WordRelation");
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.Meaning", b =>
                {
                    b.HasOne("Inshapardaz.Desktop.Domain.Entities.Dictionary.WordDetail", "WordDetail")
                        .WithMany("Meaning")
                        .HasForeignKey("WordDetailId")
                        .HasConstraintName("FK_Meaning_WordDetail");
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.Translation", b =>
                {
                    b.HasOne("Inshapardaz.Desktop.Domain.Entities.Dictionary.WordDetail", "WordDetail")
                        .WithMany("Translation")
                        .HasForeignKey("WordDetailId")
                        .HasConstraintName("FK_Translation_WordDetail");
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.Word", b =>
                {
                    b.HasOne("Inshapardaz.Desktop.Domain.Entities.Dictionary.Dictionary", "Dictionary")
                        .WithMany("Word")
                        .HasForeignKey("DictionaryId")
                        .HasConstraintName("FK_Word_Dictionary")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.WordDetail", b =>
                {
                    b.HasOne("Inshapardaz.Desktop.Domain.Entities.Dictionary.Word", "WordInstance")
                        .WithMany("WordDetail")
                        .HasForeignKey("WordInstanceId")
                        .HasConstraintName("FK_WordDetail_Word");
                });

            modelBuilder.Entity("Inshapardaz.Desktop.Domain.Entities.Dictionary.WordRelation", b =>
                {
                    b.HasOne("Inshapardaz.Desktop.Domain.Entities.Dictionary.Word", "RelatedWord")
                        .WithMany("WordRelationRelatedWord")
                        .HasForeignKey("RelatedWordId")
                        .HasConstraintName("FK_WordRelation_RelatedWord");

                    b.HasOne("Inshapardaz.Desktop.Domain.Entities.Dictionary.Word", "SourceWord")
                        .WithMany("WordRelationSourceWord")
                        .HasForeignKey("SourceWordId")
                        .HasConstraintName("FK_WordRelation_SourceWord");
                });
        }
    }
}
