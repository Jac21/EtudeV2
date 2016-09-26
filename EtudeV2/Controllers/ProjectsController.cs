using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EtudeV2.Data;
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
        public ProjectModel Get(int projectId)
        {
            return TheModelFactory.Create(TheRepository.GetProject(projectId));
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

        // Patch existing project by ID
        [System.Web.Mvc.HttpPut]
        [System.Web.Mvc.HttpPatch]
        public HttpResponseMessage Patch(int id, [FromBody] ProjectModel project)
        {
            try
            {
                var entity = TheRepository.GetProject(id);

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Project not found!");
                }

                if (TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}