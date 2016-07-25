using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using EtudeV2.Data;
using EtudeV2.Data.Entities;
using EtudeV2.Models;

namespace EtudeV2.Controllers
{
    public class ProjectsController : BaseApiController
    {
        public ProjectsController(IEtudeV2Repository repo)
            : base(repo) { }

        // Get action for Projects
        public object Get()
        {
            return TheRepository.GetAllProjects();
        } 

        // Get Project by ID
        public ProjectModel Get(int id)
        {
            return TheModelFactory.Create(TheRepository.GetProject(id));
        }
    }
}