using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using EtudeV2.Data;
using EtudeV2.Data.Entities;

namespace EtudeV2.Tests.Data
{
    [TestFixture]
    class TrackRepositoryTests
    {
        // fields
        private static readonly EtudeV2Context Context = new EtudeV2Context();
        private Track _sampleTrack;

        [TestFixtureSetUp]
        public void Initialize()
        {
            //
        }

        [SetUp]
        public void TestInit()
        {
            _sampleTrack = new Track()
            {
                Description = "TestTrack",
                Id = 5000,
                ParentTrackId = 5000,
                Project = new Project(),
                Title = "TestTrack",
                Version = 1.0
            };
        }

        [Test]
        public void AddTrackWithDefaults()
        {
            // arrange

            // act
            Context.Tracks.Add(_sampleTrack);

            // assert
            int rowCount = Context.Tracks.Count();
            rowCount.ShouldBeGreaterThan(0);
        }

        [Test]
        public void DeleteTrackWithDefaults()
        {
            // arrange
            Context.Tracks.Add(_sampleTrack);

            // act
            Context.Tracks.Remove(_sampleTrack);

            // assert
            Context.Tracks.ShouldNotContain(_sampleTrack);
        }

        [Test]
        public void AddTrackWithIncorrectInput()
        {
            // arrange

            // act

            // assert
            Should.Throw<SqlException>(() =>
            {
                Context.Database.ExecuteSqlCommand(
                    "INSERT INTO Projects.Tracks (Description, Id, ParentTrackId, Project, Title, Version)" +
                    "VALUES (1, '1', '2', null, 2, '3')"
                    );
            });
        }
    }
}
