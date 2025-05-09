using CinemaApp.Domain;
using CinemaApp.EFData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository.DB;

public class UserDBRepository(AppDbContext dbContext) : IUserRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users
            .ToListAsync();
    }
    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Name == username);
    }
    public async Task AddAsync(User entity)
    {
        await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

    }
    public async Task UpdateAsync(User entity)
    {
        _dbContext.Users.Update(entity);
    }
    public async Task DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
