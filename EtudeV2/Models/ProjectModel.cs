using System.Collections.Generic;

namespace EtudeV2.Models
{
    public class ProjectModel
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TrackModel> Tracks { get; set; } 
    }
}