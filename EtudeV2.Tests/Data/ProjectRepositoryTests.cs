using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EtudeV2.Data;
using EtudeV2.Data.Entities;
using NUnit.Framework;
using Shouldly;

namespace EtudeV2.Tests.Data
{
    [TestFixture]
    class ProjectRepositoryTests
    {
        // fields
        private static readonly EtudeV2Context Context = new EtudeV2Context();
        private Project _sampleProject;

        [TestFixtureSetUp]
        public void Initialize()
        {
            //
        }

        [SetUp]
        public void Test_Init()
        {
            _sampleProject = new Project()
            {
                Description = "TestProject",
                Id = 500,
                Name = "TestProject",
                ProjectTracks = new List<Track>()
                {
                    Capacity = 1
                },
                UserName = "TestName"
            };
        }

        [Test]
        public void Add_Project_With_Defaults()
        {
            // arrange

            // act
            Context.Projects.Add(_sampleProject);

            // assert
            int rowCount = Context.Projects.Count();
            rowCount.ShouldBeGreaterThan(0);
        }


        [Test]
        public void Delete_Project_With_Defaults()
        {
            // arrange
            Context.Projects.Add(_sampleProject);

            // act 
            Context.Projects.Remove(_sampleProject);

            // assert
            Context.Projects.ShouldNotContain(_sampleProject);
        }

        [Test]
        public void Add_Project_With_Incorrect_Input()
        {
            // arrange

            // act

            // assert
            Should.Throw<SqlException>(() =>
            {
                Context.Database.ExecuteSqlCommand(
                    "INSERT INTO Projects.Project (CurrentDate, Description, Id, Name, ProjectTracks, UserName)" +
                    "VALUES ('Not a DateTime, Whoops', 1, '1', 2, List<null>, 3)"
                    );
            });
        }
    }
}
