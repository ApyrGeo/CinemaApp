using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<Admin?> GetAdminByUsernameAsync(string username);
    }
}
