﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shnYapi5._0.data;

namespace shnYapi5._0.Migrations
{
    [DbContext(typeof(shnYapi5_0Context))]
    [Migration("20210412000100_gallery")]
    partial class gallery
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("shnYapi5._0.Entity.Haritalar", b =>
                {
                    b.Property<int>("haritaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adres")
                        .HasColumnType("TEXT");

                    b.Property<string>("aciklama")
                        .HasColumnType("TEXT");

                    b.Property<string>("x")
                        .HasColumnType("TEXT");

                    b.Property<string>("y")
                        .HasColumnType("TEXT");

                    b.HasKey("haritaID");

                    b.ToTable("Haritalar");
                });

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

            modelBuilder.Entity("shnYapi5._0.Entity.adress", b =>
                {
                    b.Property<int>("adresID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("No")
                        .HasColumnType("TEXT");

                    b.Property<string>("ilce")
                        .HasColumnType("TEXT");

                    b.Property<string>("isYeri")
                        .HasColumnType("TEXT");

                    b.Property<string>("mahalle")
                        .HasColumnType("TEXT");

                    b.Property<string>("sehir")
                        .HasColumnType("TEXT");

                    b.Property<string>("sokak")
                        .HasColumnType("TEXT");

                    b.HasKey("adresID");

                    b.ToTable("adress");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.eMail", b =>
                {
                    b.Property<int>("emailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.HasKey("emailID");

                    b.ToTable("eMail");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.gallery", b =>
                {
                    b.Property<int>("imgID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("imgName")
                        .HasColumnType("TEXT");

                    b.Property<string>("imgYol")
                        .HasColumnType("TEXT");

                    b.HasKey("imgID");

                    b.ToTable("gallery");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.homeCards", b =>
                {
                    b.Property<int>("cardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("aciklama")
                        .HasColumnType("TEXT");

                    b.Property<string>("baslik")
                        .HasColumnType("TEXT");

                    b.Property<string>("icerik")
                        .HasColumnType("TEXT");

                    b.Property<string>("imgName")
                        .HasColumnType("TEXT");

                    b.Property<string>("imgYol")
                        .HasColumnType("TEXT");

                    b.HasKey("cardID");

                    b.ToTable("homeCards");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.homeParagraph", b =>
                {
                    b.Property<int>("paragraphID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("section1")
                        .HasColumnType("TEXT");

                    b.Property<string>("section2")
                        .HasColumnType("TEXT");

                    b.Property<string>("section3")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("paragraphID");

                    b.ToTable("homeParagraph");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.mail", b =>
                {
                    b.Property<int>("mailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("mailAdress")
                        .HasColumnType("TEXT");

                    b.HasKey("mailID");

                    b.ToTable("Mail");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.maps", b =>
                {
                    b.Property<int>("mapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("stringURL")
                        .HasColumnType("TEXT");

                    b.HasKey("mapID");

                    b.ToTable("maps");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.misyonumuz", b =>
                {
                    b.Property<int>("misyonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("content")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("misyonID");

                    b.ToTable("misyonumuz");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.phone", b =>
                {
                    b.Property<int>("phoneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("phoneID");

                    b.ToTable("phone");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.proje", b =>
                {
                    b.Property<int>("projeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("icerik")
                        .HasColumnType("TEXT");

                    b.Property<string>("imgName")
                        .HasColumnType("TEXT");

                    b.Property<string>("imgYol")
                        .HasColumnType("TEXT");

                    b.Property<string>("projeAdi")
                        .HasColumnType("TEXT");

                    b.Property<string>("projeBasligi")
                        .HasColumnType("TEXT");

                    b.HasKey("projeID");

                    b.ToTable("proje");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.vizyon", b =>
                {
                    b.Property<int>("vizyonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("arz")
                        .HasColumnType("TEXT");

                    b.Property<string>("content")
                        .HasColumnType("TEXT");

                    b.Property<string>("talep")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("vizyonID");

                    b.ToTable("vizyon");
                });

            modelBuilder.Entity("shnYapi5._0.Entity.vizyonList", b =>
                {
                    b.Property<int>("vizyonListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("content")
                        .HasColumnType("TEXT");

                    b.HasKey("vizyonListID");

                    b.ToTable("vizyonList");
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