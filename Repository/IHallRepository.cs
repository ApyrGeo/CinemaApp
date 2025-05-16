
using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository
{
    public interface IHallRepository : IRepository<Hall>
    {
        Task<int> AddWithReturnAsync(Hall entity);
        Task<List<Hall>> GetHallsByCinemaId(int cinemaId);
    }
}
