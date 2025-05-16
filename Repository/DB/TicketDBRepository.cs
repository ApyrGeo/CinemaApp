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
    public class TicketDBRepository : ITicketRepository
    {
        private readonly AppDbContext _dbContext;

        public TicketDBRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _dbContext.Tickets
                .Include(t => t.User)  // User that bought the ticket
                .Include(t => t.Projection)  // Projection the ticket is for
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _dbContext.Tickets
                .Include(t => t.User)
                .Include(t => t.Projection)
                .ToListAsync();
        }

        public async Task AddAsync(Ticket entity)
        {
            await _dbContext.Tickets.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket entity)
        {
            _dbContext.Tickets.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticket = await GetByIdAsync(id);
            if (ticket != null)
            {
                _dbContext.Tickets.Remove(ticket);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Ticket>> GetUserTickets(int id)
        {
            var tickets = await _dbContext.Tickets
             .Include(t => t.User)             
             .Include(t => t.Projection)     
                 .ThenInclude(p => p.Movie)
             .Include(t => t.Projection)
                 .ThenInclude(p => p.Hall) 
             .Include(t => t.Seat)              
             .Where(t => t.UserId == id)
             .ToListAsync();

            return tickets;
        }

        public async Task<IEnumerable<Seat>> GetTakenSeatsByHall(int id)
        {
            return await _dbContext.Tickets
                .Where(t => t.Projection.HallId == id)
                .Select(t => t.Seat)
                .ToListAsync();

        }

        public Task<Ticket> AddWithReturnAsync(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
            return Task.FromResult(ticket);
        }
    }
}
