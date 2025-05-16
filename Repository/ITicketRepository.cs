using CinemaApp.Domain;
using CinemaApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<Ticket> AddWithReturnAsync(Ticket ticket);
        Task<IEnumerable<Seat>> GetTakenSeatsByHall(int id);
        Task<IEnumerable<Ticket>> GetUserTickets(int id);
    }
}
