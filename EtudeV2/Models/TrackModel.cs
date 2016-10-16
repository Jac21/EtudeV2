using System.ComponentModel.DataAnnotations;

namespace EtudeV2.Models
{
    public class TrackModel
    {
        public int Id { get; set; }
        public string Url { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        public byte File { get; set; }
    }
}