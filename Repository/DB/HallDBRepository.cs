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
    public class HallDBRepository : IHallRepository
    {
        private readonly AppDbContext _context;

        public HallDBRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Hall entity)
        {
            await _context.Halls.AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task<int> AddWithReturnAsync(Hall entity)
        {
            await _context.Halls.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<Hall>> GetAllAsync()
        {
            return await _context.Halls.ToListAsync();
        }

        public async Task<Hall?> GetByIdAsync(int id)
        {
            return await _context.Halls.FindAsync(id);
        }

        public async Task UpdateAsync(Hall entity)
        {
            _context.Halls.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hall = await GetByIdAsync(id);
            if (hall != null)
            {
                _context.Halls.Remove(hall);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Hall>> GetHallsByCinemaId(int cinemaId)
        {
            var halls = _context.Halls.Where(h => h.CinemaId == cinemaId).ToListAsync();
            
            return halls;
        }
    }
   
}
