using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EtudeV2.Data;
using EtudeV2.Models;

namespace EtudeV2.Controllers
{
    public class TracksController : BaseApiController
    {
        public TracksController(IEtudeV2Repository repo)
            : base(repo) { }

        // Get action for Tracks
        public object Get()
        {
            return TheRepository.GetAllTracks();
        }

        // Get Track by ID
        public TrackModel Get(int id)
        {
            return TheModelFactory.Create(TheRepository.GetTrack(id));
        }

        // Post a new track
        public HttpResponseMessage Post([FromBody]TrackModel track)
        {
            try
            {
                var entity = TheModelFactory.Parse(track);

                if (entity == null)
                {
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read track entry in body");
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

        // Delete Track by ID
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (TheRepository.DeleteTrack(id) && TheRepository.SaveAll())
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