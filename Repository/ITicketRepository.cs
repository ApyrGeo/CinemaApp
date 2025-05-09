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
    }
}
