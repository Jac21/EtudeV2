using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtudeV2.Data.Entities
{
    public class SiteUser
    {
        public SiteUser()
        {
            Projects = new List<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Secret { get; set; }
        public string AppId { get; set; }
        public string Password { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
