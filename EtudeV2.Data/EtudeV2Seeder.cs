//#define TEST_SEED

using System;
using System.Collections.Generic;
using EtudeV2.Data.Entities;

namespace EtudeV2.Data
{
    public class EtudeV2Seeder
    {
        private readonly EtudeV2Context _context;

        // For Seeding data purposes
        private Random _random;
        private string[] _siteUserNameStrings;
        private string[] _projectNameStrings;
        private string[] _trackTitleStrings;

        public EtudeV2Seeder(EtudeV2Context context)
        {
            this._context = context;

            this._random = new Random();

            this._siteUserNameStrings = new[]
            {
                "Jac21",
                "Lv15",
                "TestNameOne",
                "TestNameDos"
            };

            this._projectNameStrings = new[]
            {
                "Sleep Paralysis",
                "Intro",
                "Heart to Say",
                "Straight and Narrow"
            };

            this._trackTitleStrings = new[]
            {
                "Lead Guitar",
                "Rhythm Guitar",
                "Drums",
                "Bass"
            };
        }

        void SeedSiteUsers()
        {
            try
            {
                var siteUser = new SiteUser()
                {
                    AppId = "SSB3aWxsIG1ha2UgbXkgQVBJIHNlY3VyZQ==",
                    EmailAddress = "jcantu521@gmail.com",
                    Id = 1,
                    Name = _siteUserNameStrings[_random.Next(3)],
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
                    Id = 1,
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
                    Name = _projectNameStrings[_random.Next(3)],
                    Description = "Track #1 of new EP",
                    Id = 1,
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
                    Id = 1,
                    ParentTrackId = 0,
                    Project = project,
                    Title = _trackTitleStrings[_random.Next(3)],
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
            /*
#if TEST_SEED
            _context.Database.ExecuteSqlCommand("DELETE FROM Projects.Tracks");
            _context.Database.ExecuteSqlCommand("DELETE FROM Projects.Project");
            _context.Database.ExecuteSqlCommand("DELETE FROM [User].AuthToken");
            _context.Database.ExecuteSqlCommand("DELETE FROM [User].SiteUser");
#endif
             * */

            SeedSiteUsers();
            SeedProjectsAndTracks();
        }
    }
}
