using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository
{
    public interface IProjectionRepository : IRepository<Projection>
    {
        Task<List<Movie>> GetAllMoviesByCinemaId(int cinemaId);
        Task<List<Seat>> GetAllTakenSeatsFromProjection(int? projectionId);
        Task<List<Projection>> GetProjectionsByCinemaIdAsync(int cinemaId);
    }
}
