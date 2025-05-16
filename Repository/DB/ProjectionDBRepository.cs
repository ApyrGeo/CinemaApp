using CinemaApp.Domain;
using CinemaApp.EFData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository.DB
{
    public class ProjectionDBRepository : IProjectionRepository
    {
        private readonly AppDbContext _dbContext;

        public ProjectionDBRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Projection?> GetByIdAsync(int id)
        {
            return await _dbContext.Projections
                .Include(p => p.Movie)  // Movie related to projection
                .Include(p => p.Hall)   // Hall where the projection occurs
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Projection>> GetAllAsync()
        {
            return await _dbContext.Projections
                .Include(p => p.Movie)
                .Include(p => p.Hall)
                .ToListAsync();
        }

        public async Task AddAsync(Projection entity)
        {
            await _dbContext.Projections.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Projection entity)
        {
            _dbContext.Projections.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var projection = await GetByIdAsync(id);
            if (projection != null)
            {
                _dbContext.Projections.Remove(projection);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Projection>> GetProjectionsByCinemaIdAsync(int cinemaId)
        {
            return await _dbContext.Projections
                .Include(p => p.Hall) 
                .Include(p => p.Movie)

                .Where(p => p.Hall.CinemaId == cinemaId)
                .ToListAsync();
        }

        public Task<List<Seat>> GetAllTakenSeatsFromProjection(int? projectionId)
        {
            return _dbContext.Tickets
                .Include(t => t.Seat)
                .Where(t => t.ProjectionId == projectionId)
                .Select(t => t.Seat)
                .ToListAsync();
        }

        public Task<List<Movie>> GetAllMoviesByCinemaId(int cinemaId)
        {
            return _dbContext.Movies
                .Include(m => m.Projections)
                .Where(m => m.Projections.Any(p => p.Hall.CinemaId == cinemaId))
                .ToListAsync();
        }

        public Task<List<Projection>> GetProjectionsByHallId(int id)
        {
            return _dbContext.Projections
                .Include(p => p.Movie)
                .Include(p => p.Hall)
                .Where(p => p.HallId == id)
                .ToListAsync();
        }
    }
}
