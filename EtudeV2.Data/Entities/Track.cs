using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtudeV2.Data.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public int ParentTrackId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Version { get; set; }

        public virtual Project Project { get; set; }
    }
}
