using System;
using System.Net;
using System.Net.Http;
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