using CinemaApp.Domain;
using CinemaApp.EFData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository.DB;

public class AdminDBRepository(AppDbContext dbContext) : IAdminRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<Admin?> GetByIdAsync(int id)
    {
        return await _dbContext.Admins
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Admin>> GetAllAsync()
    {
        return await _dbContext.Admins
            .ToListAsync();
    }

    public async Task<Admin?> GetAdminByUsernameAsync(string username)
    {
        return await _dbContext.Admins
            .FirstOrDefaultAsync(a => a.Name == username);
    }

    public async Task AddAsync(Admin entity)
    {
        await _dbContext.Admins.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Admin entity)
    {
        _dbContext.Admins.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var admin = await GetByIdAsync(id);
        if (admin != null)
        {
            _dbContext.Admins.Remove(admin);
            await _dbContext.SaveChangesAsync();
        }
    }
}

