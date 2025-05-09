using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Service
{
    public interface IAdminService
    {
        Task<Admin?> LoginAsync(string username, string password);
    }
}
