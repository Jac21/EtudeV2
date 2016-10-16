using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;
using EtudeV2.Data;
using EtudeV2.Data.Entities;

namespace EtudeV2.Models
{
    public class ModelFactory
    {
        private readonly UrlHelper _urlHelper;
        public IEtudeV2Repository Repo { get; set; }

        public ModelFactory(HttpRequestMessage request, IEtudeV2Repository repo)
        {
            this._urlHelper = new UrlHelper(request);
            Repo = repo;
        }

        public ProjectModel Create(Project project)
        {
            return new ProjectModel
            {
                Url = _urlHelper.Link("Project", new {id = project.Id}),
                Description = project.Description,
                Name = project.Name,
                Tracks = project.ProjectTracks.Select(m => Create(m))
            };
        }

        public TrackModel Create(Track track)
        {
            return new TrackModel()
            {
                Url = _urlHelper.Link("Track", new {id = track.Id}),
                Description = track.Description,
                Title = track.Title
            };
        }

        public Project Parse(ProjectModel model)
        {
            try
            {
                var entry = new Project
                {
                    Name = model.Name,
                    Description = model.Description,
                    UserName = model.Name,
                    CoverArt = model.CoverArt
                };

                return entry;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Track Parse(TrackModel model)
        {
            try
            {
                var entry = new Track
                {
                    Title = model.Title,
                    Description = model.Description
                };


                return entry;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}