using CinemaApp.Domain;
using CinemaApp.Repository;
using Microsoft.AspNetCore.Identity;
using CinemaApp.Service.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Service
{
    public class AdminService(IAdminRepository adminRepository, Notifier notifier) : IAdminService
    {
        private readonly IAdminRepository _adminRepository = adminRepository;
        private readonly PasswordHasher<Admin> _passwordHasher = new();
        private readonly Notifier _notifier = notifier;

        public async Task<Admin?> LoginAsync(string username, string password)
        {
            var admin = await _adminRepository.GetAdminByUsernameAsync(username) ?? throw new ServiceException("User not found");
            var result = _passwordHasher.VerifyHashedPassword(admin, admin.Password, password);

            if (result == PasswordVerificationResult.Failed)
                throw new ServiceException("Invalid password");

            return admin;
        }

        public Task RegisterAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateX(User u)
        {
            _notifier.Notify(u);
        }
    }
}
