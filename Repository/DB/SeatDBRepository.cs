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
    public class SeatDBRepository : ISeatRepository
    {
        private  readonly AppDbContext _context;

        public SeatDBRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetAllAsync()
        {
            return await _context.Seats.ToListAsync();
        }

        public async Task<Seat?> GetByIdAsync(int id)
        {
            return await _context.Seats.FindAsync(id);
        }

        public async Task AddAsync(Seat entity)
        {
            await _context.Seats.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seat entity)
        {
            _context.Seats.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var seat = await GetByIdAsync(id);
            if (seat != null)
            {
                _context.Seats.Remove(seat);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Seat>> GetByHallAsync(int hallId)
        {
            return await _context.Seats
                .Where(s => s.HallId == hallId)
                .ToListAsync();
        }
    }
}
