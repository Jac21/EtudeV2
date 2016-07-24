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
        // for paging purposes
        private const int PAGE_SIZE = 10;

        public ProjectsController(IEtudeV2Repository repo)
            : base(repo) { }

        // Get action for Projects
        public object Get(bool param, int page = 0)
        {
            // set query objects, grab projects and order
            IQueryable<Project> query;

            query = TheRepository.GetAllProjects();

            var baseQuery = query.OrderBy(f => f.Description);

            // for paging
            var totalCount = baseQuery.Count();
            var totalPages = Math.Ceiling((double) totalCount/PAGE_SIZE);

            var helper = new UrlHelper(Request);
            var prevUrl = page > 0 ? helper.Link("Project", new {page = page - 1}) : "";
            var nextUrl = page < totalPages - 1 ? helper.Link("Project", new {page = page + 1}) : "";

            var results = baseQuery.Skip(PAGE_SIZE*page)
                .Take(PAGE_SIZE)
                .ToList()
                .Select(f => TheModelFactory.Create(f));

            return new
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                PrevPageUrl = prevUrl,
                NextPageUrl = nextUrl,
                Results = results
            };
        } 

        // Get Project by ID
        public ProjectModel Get(int id)
        {
            return TheModelFactory.Create(TheRepository.GetProject(id));
        }
    }
}