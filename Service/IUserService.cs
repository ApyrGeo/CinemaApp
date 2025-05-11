using CinemaApp.Domain;

namespace CinemaApp.Service;

public interface IUserService
{
    Task AddProjection(Projection projection);
    Task AddTicket(DateTime date, int? id_proj, int? id_seat, int? id_user);
    Task DeleteTicket(Ticket ticket);
    Task<List<Movie>> GetAllMovies();
    Task<List<Movie>> GetAllMovies(int cinemaId);
    Task<List<Seat>> GetAllSeatsFromHall(int hallId);
    Task<List<Seat>> GetAllTakenSeatsFromProjection(int? projectionId);
    Task<List<Projection>> GetProjections(int cinemaId);
    Task<List<Ticket>> GetUserTickets(int id);
    Task<User?> LoginAsync(string username, string password);
    Task RegisterAsync(string username, string password);

}