using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EtudeV2.Data;

namespace EtudeV2.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private IEtudeV2Repository _repo;
    }
}