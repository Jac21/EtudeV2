using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EtudeV2.Data;
using EtudeV2.Models;

namespace EtudeV2.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private IEtudeV2Repository _repo;
        private ModelFactory _modelFactory;

        public BaseApiController(IEtudeV2Repository repo)
        {
            this._repo = repo;
        }

        protected IEtudeV2Repository TheRepository
        {
            get
            {
                return _repo;
            }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, TheRepository);
                }

                return _modelFactory;
            }
        }
    }
}