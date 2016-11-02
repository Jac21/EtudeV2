using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EtudeV2.Data;
using EtudeV2.Models;

namespace EtudeV2.Controllers
{
    public class ProjectsController : BaseApiController
    {
        public ProjectsController(IEtudeV2Repository repo)
            : base(repo) { }

        // Get action for Projects
        [ResponseType(typeof(ProjectModel))]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(TheRepository.GetAllProjects());
            }
            catch (HttpResponseException)
            {
                return InternalServerError();
            }
            
        } 

        // Get Project by ID
        public ProjectModel Get(int projectId)
        {
            return TheModelFactory.Create(TheRepository.GetProject(projectId));
        }

        // Post a new Project 
        public HttpResponseMessage Post([FromBody]ProjectModel project)
        {
            try
            {
                var entity = TheModelFactory.Parse(project);

                if (entity == null)
                {
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read Project entry in body");
                }

                TheRepository.Insert(entity);

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

        // Delete an existing project by ID
        public HttpResponseMessage Delete(int projectId)
        {
            try
            {
                if (TheRepository.DeleteProject(projectId) && TheRepository.SaveAll())
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
        public HttpResponseMessage Patch(int projectId, [FromBody] ProjectModel project)
        {
            try
            {
                var entity = TheRepository.GetProject(projectId);

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