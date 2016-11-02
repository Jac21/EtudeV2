using System.Web.Http;
using EtudeV2.Data;
using EtudeV2.Models;

namespace EtudeV2.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private readonly IEtudeV2Repository _repo;
        private ModelFactory _modelFactory;

        protected BaseApiController(IEtudeV2Repository repo)
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
            get { return _modelFactory ?? (_modelFactory = new ModelFactory(this.Request, TheRepository)); }
        }
    }
}