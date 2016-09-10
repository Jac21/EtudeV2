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
        bool Insert(Project project);
        bool Insert(Track track);
        bool Insert(AuthToken token);

        // Update
        bool Update(Project project);
        bool Update(Track track);

        // Deletes
        bool DeleteProject(int id);
        bool DeleteTrack(int id);
    }
}
