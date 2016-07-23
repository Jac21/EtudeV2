//#define TEST_SEED
//#define FORCE_RECREATE

using System;
using System.Collections.Generic;
using EtudeV2.Data.Entities;

namespace EtudeV2.Data
{
    public class EtudeV2Seeder
    {
        private readonly EtudeV2Context _context;

        public EtudeV2Seeder(EtudeV2Context context)
        {
            this._context = context;
        }

        void SeedSiteUsers()
        {
            try
            {
                var siteUser = new SiteUser()
                {
                    AppId = "SSB3aWxsIG1ha2UgbXkgQVBJIHNlY3VyZQ==",
                    EmailAddress = "jcantu521@gmail.com",
                    Id = 0000,
                    Name = "Jac21",
                    Password = "passwordOne",
                    Projects = new List<Project>()
                    {
                        Capacity = 1,
                    },
                    Secret = "VGhpcyBDb3Vyc2UgSXMgQXdlc29tZQ=="
                };

                _context.SiteUsers.Add(siteUser);

                var token = new AuthToken()
                {
                    Expiration = DateTime.Today.AddDays(365),
                    Id = 0000,
                    SiteUser = siteUser,
                    Token = "1234567890"
                };

                _context.AuthTokens.Add(token);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR ON SEEDING SITE USERS, EXCEPTION:\n {0}", ex);
            }
        }

        void SeedProjectsAndTracks()
        {
            try
            {
                var project = new Project()
                {
                    CurrentDate = DateTime.Now,
                    Description = "Sleep Paralysis",
                    Id = 0000,
                    ProjectTracks = new List<Track>()
                    {
                        Capacity = 1,
                    },
                    UserName = "Jac21",
                    Version = 1.0
                };

                _context.Projects.Add(project);

                var track = new Track()
                {
                    Description = "Rhythm guitar track",
                    Id = 0000,
                    ParentTrackId = 0,
                    Project = project,
                    Title = "Rhythm Guitar (Jeremy)",
                    Version = 1.0
                };

                _context.Tracks.Add(track);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR ON SEEDING PROJECT AND TRACK DATA, EXCEPTION:\n {0}", ex);
            }
        }

        public void Seed()
        {
            SeedSiteUsers();
            SeedProjectsAndTracks();
        }
    }
}
