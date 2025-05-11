using CinemaApp.Domain;
using CinemaApp.EFData;
using CinemaApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository.DB;

public class MovieDBRepository : IMovieRepository
{
    private readonly AppDbContext _dbContext;

    public MovieDBRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _dbContext.Movies
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _dbContext.Movies.ToListAsync();
    }

    public async Task AddAsync(Movie entity)
    {
        await _dbContext.Movies.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Movie entity)
    {
        _dbContext.Movies.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var movie = await GetByIdAsync(id);
        if (movie != null)
        {
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }

    
}
