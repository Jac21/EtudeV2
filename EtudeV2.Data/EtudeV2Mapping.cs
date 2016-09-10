using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtudeV2.Data.Entities;

namespace EtudeV2.Data
{
    public class EtudeV2Mapping
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            MapTracks(modelBuilder);
            MapProject(modelBuilder);
            MapAuthToken(modelBuilder);
        }

        static void MapAuthToken(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthToken>().ToTable("AuthToken", "User");
        }

        static void MapProject(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project", "Projects");
        }

        static void MapTracks(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>().ToTable("Tracks", "Projects");
        }
    }
}
