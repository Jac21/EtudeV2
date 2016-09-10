using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EtudeV2.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public ApplicationUser Artist { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string CoverArt { get; set; }
        public IEnumerable<TrackModel> Tracks { get; set; } 
    }
}