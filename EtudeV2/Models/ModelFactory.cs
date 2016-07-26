using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;
using EtudeV2.Data;
using EtudeV2.Data.Entities;

namespace EtudeV2.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        public IEtudeV2Repository _repo { get; set; }

        public ModelFactory(HttpRequestMessage request, IEtudeV2Repository repo)
        {
            this._urlHelper = new UrlHelper(request);
            _repo = repo;
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
    }
}