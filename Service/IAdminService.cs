using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Service
{
    public interface IAdminService
    {
        Task AddHall(Hall hall);
        Task AddMovie(Movie movie);
        Task<List<Hall>> GetHalls(int cinemaId);
        Task<Ticket> GetTicket(int id);
        Task<Admin?> LoginAsync(string username, string password);
        Task RemoveHall(Hall hall);
    }
}
