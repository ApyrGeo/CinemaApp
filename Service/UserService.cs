using CinemaApp.Domain;
using CinemaApp.Repository;
using CinemaApp.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly PasswordHasher<User> _passwordHasher = new();

        public async Task<User?> LoginAsync(string username, string password)
        {

            var user = await _userRepository.GetUserByUsernameAsync(username) ?? throw new ServiceException("User not found");
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (result == PasswordVerificationResult.Failed)
                throw new ServiceException("Invalid password");


            return user;
        }
        public async Task RegisterAsync(string username, string password)
        {
            var user = new User { Name = username };

            user.Password = _passwordHasher.HashPassword(user, password);

            await _userRepository.AddAsync(user);

        }
    }
}
