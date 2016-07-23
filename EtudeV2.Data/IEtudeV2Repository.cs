using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtudeV2.Data.Entities;

namespace EtudeV2.Data
{
    public interface IEtudeV2Repository
    {
        // general method
        bool SaveAll();

        // Site Users
        IQueryable<SiteUser> FindUser(string searchString);
        IQueryable<SiteUser> GetAllUsers();
        IQueryable<SiteUser> GetProjectsForUser(string userName);
        IQueryable<SiteUser> GetTracksForUser(string userName);
        SiteUser GetSiteUser(int id);

        // Project
        IQueryable<Project> FindProject(string searchString);
        IQueryable<Project> GetAllProjects();
        IQueryable<Project> GetTracksForProject(string description);
        Project GetProject(int id);

        // Track
        IQueryable<Track> FindTrack(string searchString);
        IQueryable<Track> GetAllTracks();
        Track GetTrack(int id);

        // Tokens
        AuthToken GetAuthToken(string token);

        /*
         * DB Methods
         */

        // Inserts
        bool Insert(SiteUser siteUser);
        bool Insert(Project project);
        bool Insert(Track track);
        bool Insert(AuthToken token);

        // Update
        bool Update(SiteUser siteUser);
        bool Update(Project project);
        bool Update(Track track);

        // Deletes
        bool DeleteUser(int id);
        bool DeleteProject(int id);
        bool DeleteTrack(int id);
    }
}
