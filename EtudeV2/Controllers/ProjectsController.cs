using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        /* Post a new Project
        public HttpResponseMessage Post([FromBody]ProjectModel project)
        {
            try
            {
                var entity = project;

                if (entity == null)
                {
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read Project entry in body");
                }

                if (TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(entity));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Write to DB not successful");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
         */

        // Delete an existing project by ID
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (TheRepository.DeleteProject(id) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}