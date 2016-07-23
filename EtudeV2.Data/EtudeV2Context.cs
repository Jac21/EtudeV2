using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtudeV2.Data.Entities;

namespace EtudeV2.Data
{
    public class EtudeV2Context : DbContext
    {
        public EtudeV2Context()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        static EtudeV2Context()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EtudeV2Context, EtudeV2MigrationConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            EtudeV2Mapping.Configure(modelBuilder);
        }

        public DbSet<AuthToken> AuthTokens { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
