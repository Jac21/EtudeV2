using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}