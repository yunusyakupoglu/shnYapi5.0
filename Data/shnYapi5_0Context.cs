using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using shnYapi5._0.Entity;
using shnYapi5._0.Models;

namespace shnYapi5._0.data
{
    public class shnYapi5_0Context : DbContext
    {
        public shnYapi5_0Context (DbContextOptions<shnYapi5_0Context> options)
            : base(options)
        {
        }

        public DbSet<admin> admins { get; set; }
        public DbSet<Kayit> kayits { get; set; }
        public DbSet<proje> projes { get; set; }
        public DbSet<homeCards> homeCards { get; set; }
        public DbSet<homeParagraph> homeParagraphs { get; set; }
        public DbSet<misyonumuz> misyons { get; set; }
        public DbSet<vizyon> vizyons { get; set; }
        public DbSet<vizyonList> vizyonLists { get; set; }
        public DbSet<Haritalar> haritalars { get; set; }
        public DbSet<maps> maps { get; set; }
        public DbSet<adress> adresses { get; set; }
        public DbSet<eMail> mails { get; set; }
        public DbSet<phone> phones { get; set; }
        public DbSet<mail> Mail { get; set; }
        public DbSet<gallery> galleries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>().ToTable("admin");
            modelBuilder.Entity<Kayit>().ToTable("Kayit");
            modelBuilder.Entity<proje>().ToTable("proje");
            modelBuilder.Entity<homeCards>().ToTable("homeCards");
            modelBuilder.Entity<homeParagraph>().ToTable("homeParagraph");
            modelBuilder.Entity<misyonumuz>().ToTable("misyonumuz");
            modelBuilder.Entity<vizyon>().ToTable("vizyon");
            modelBuilder.Entity<vizyonList>().ToTable("vizyonList");
            modelBuilder.Entity<Haritalar>().ToTable("Haritalar");
            modelBuilder.Entity<maps>().ToTable("maps");
            modelBuilder.Entity<adress>().ToTable("adress");
            modelBuilder.Entity<eMail>().ToTable("eMail");
            modelBuilder.Entity<phone>().ToTable("phone");
            modelBuilder.Entity<gallery>().ToTable("gallery");
        }

        internal Task UpdateAsync(proje proje)
        {
            throw new NotImplementedException();
        }

        public DbSet<shnYapi5._0.Entity.eMail> eMail { get; set; }

        public DbSet<shnYapi5._0.Entity.phone> phone { get; set; }

    }
}
