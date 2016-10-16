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
        private string[] _projectNameStrings;
        private string[] _trackTitleStrings;
        private string[] _coverArtPathStrings;

        public EtudeV2Seeder(EtudeV2Context context)
        {
            this._context = context;

            this._random = new Random();

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

            this._coverArtPathStrings = new[]
            {
                "/images/covers/Blur.jpg",
                "/images/covers/Deafheaven.png",
                "/images/covers/ds.jpg",
                "/images/covers/fmj.jpg"
            };
        }

        void SeedProjectsAndTracks()
        {
            try
            {
                var project = new Project()
                {
                    Name = _projectNameStrings[_random.Next(3)],
                    Description = "Track #1 of new EP",
                    Id = 1,
                    ProjectTracks = new List<Track>()
                    {
                        Capacity = 1,
                    },
                    UserName = "Jac21",
                    CoverArt = _coverArtPathStrings[_random.Next(3)],
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

            SeedProjectsAndTracks();
        }
    }
}
