using CinemaApp.Domain;

namespace CinemaApp.Service;

public interface IUserService
{
    Task<User?> LoginAsync(string username, string password);
    Task RegisterAsync(string username, string password);
}
