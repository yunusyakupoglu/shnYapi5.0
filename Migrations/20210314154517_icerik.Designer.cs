﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shnYapi5._0.data;

namespace shnYapi5._0.Migrations
{
    [DbContext(typeof(shnYapi5_0Context))]
    [Migration("20210314154517_icerik")]
    partial class icerik
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("shnYapi5._0.Entity.Kayit", b =>
                {
                    b.Property<int>("kayitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("adminID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("projeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("kayitID");

                    b.HasIndex("adminID");

                    b.HasIndex("projeID");

                    b.ToTable("Kayit");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.admin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("admin");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.proje", b =>
                {
                    b.Property<int>("projeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("icerik")
                        .HasColumnType("TEXT");

                    b.Property<string>("imgURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("projeAdi")
                        .HasColumnType("TEXT");

                    b.Property<string>("projeBasligi")
                        .HasColumnType("TEXT");

                    b.HasKey("projeID");

                    b.ToTable("proje");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.Kayit", b =>
                {
                    b.HasOne("shnYapi5._0.Entity.admin", "admin")
                        .WithMany("Kayitlar")
                        .HasForeignKey("adminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shnYapi5._0.Entity.proje", "proje")
                        .WithMany("Kayitlar")
                        .HasForeignKey("projeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("admin");

                    b.Navigation("proje");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.admin", b =>
                {
                    b.Navigation("Kayitlar");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.proje", b =>
                {
                    b.Navigation("Kayitlar");
                });
#pragma warning restore 612, 618
        }
    }
}
