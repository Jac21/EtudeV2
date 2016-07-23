using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtudeV2.Data.Entities
{
    public class Project
    {
        public Project()
        {
            ProjectTracks = new List<Track>();
        }

        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public string UserName { get; set; }
        public ICollection<Track> ProjectTracks { get; set; } 
    }
}
