using CinemaApp.Domain;
using CinemaApp.EFData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository.DB;
public class CinemaDBRepository : ICinemaRepository
{
    private readonly AppDbContext _dbContext;

    public CinemaDBRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Cinema?> GetByIdAsync(int id)
    {
        return await _dbContext.Cinemas
            .Include(c => c.Halls)  // Include related halls
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Cinema>> GetAllAsync()
    {
        return await _dbContext.Cinemas.ToListAsync();
    }

    public async Task AddAsync(Cinema entity)
    {
        await _dbContext.Cinemas.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cinema entity)
    {
        _dbContext.Cinemas.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var cinema = await GetByIdAsync(id);
        if (cinema != null)
        {
            _dbContext.Cinemas.Remove(cinema);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}

