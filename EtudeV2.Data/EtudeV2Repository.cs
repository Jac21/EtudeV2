using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtudeV2.Data.Entities;

namespace EtudeV2.Data
{
    public class EtudeV2Repository : IEtudeV2Repository
    {
        // context declaration and constructor
        private readonly EtudeV2Context _context;

        public EtudeV2Repository(EtudeV2Context context)
        {
            this._context = context;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        /*
         * Project Methods
         */

        public IQueryable<Project> FindProject(string searchString)
        {
            return _context.Projects.Include("Project")
                .Where(f => f.Description.Contains(searchString));
        }

        public IQueryable<Project> GetAllProjects()
        {
            return _context.Projects;
        }

        public IQueryable<Project> GetTracksForProject(string description)
        {
            return _context.Projects.Include("ProjectTracks")
                .Where(d => d.Description == description);
        }

        public Project GetProject(int id)
        {
            return _context.Projects
                .FirstOrDefault(f => f.Id == id);
        }

        /*
         * Track Methods
         */

        public IQueryable<Track> FindTrack(string searchString)
        {
            return _context.Tracks.Include("Track")
                .Where(f => f.Description.Contains(searchString));
        }
        public IQueryable<Track> GetAllTracks()
        {
            return _context.Tracks;
        }

        public Track GetTrack(int id)
        {
            return _context.Tracks
                .FirstOrDefault(f => f.Id == id);
        }

        /*
         * Token Methods
         */

        public AuthToken GetAuthToken(string token)
        {
            return _context.AuthTokens.Include("ApiUser")
                .Where(t => t.Token == token)
                .FirstOrDefault();
        }

        /*
         *  Inserts
         */

        public bool Insert(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Insert(Track track)
        {
            try
            {
                _context.Tracks.Add(track);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Insert(AuthToken token)
        {
            try
            {
                _context.AuthTokens.Add(token);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*
         * Update
         */

        public bool UpdateEntity<T>(DbSet<T> dbSet, T entity) where T : class
        {
            try
            {
                dbSet.AttachAsModified(entity, _context);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Project project)
        {
            return UpdateEntity(_context.Projects, project);
        }

        public bool Update(Track track)
        {
            return UpdateEntity(_context.Tracks, track);
        }

        /*
         * Deletes
         */ 


        public bool DeleteProject(int id)
        {
            try
            {
                var entity = _context.Projects.Where(f => f.Id == id).FirstOrDefault();

                if (entity != null)
                {
                    DeleteTrack(id);
                    _context.Projects.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // Logging
            }

            return false;
        }

        public bool DeleteTrack(int id)
        {
            try
            {
                var entity = _context.Tracks.Where(f => f.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    _context.Tracks.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // Logging
            }

            return false;
        }
    }
}
