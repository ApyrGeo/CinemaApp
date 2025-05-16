using CinemaApp.Domain;
using CinemaApp.Repository;
using CinemaApp.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Service.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService(IUserRepository userRepository, IMovieRepository movieRepository, ITicketRepository ticketRepository, IProjectionRepository projectionRepository, ISeatRepository seatRepository, Notifier notify) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMovieRepository _movieRepository = movieRepository;
        private readonly ITicketRepository _ticketRepository = ticketRepository;
        private readonly IProjectionRepository _projectionRepository = projectionRepository;
        private readonly ISeatRepository _seatRepository = seatRepository;
        private readonly PasswordHasher<User> _passwordHasher = new();
        private readonly Notifier _notifier = notify;

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


        public async Task<List<Movie>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllAsync();

            return movies == null ? throw new ServiceException("No movies found") : (List<Movie>) movies;
        }

        public async Task<List<Ticket>> GetUserTickets(int id)
        {
            return (List<Ticket>)(await _ticketRepository.GetUserTickets(id) ?? throw new ServiceException("No tickets found"));
        }

        public async Task DeleteTicket(Ticket ticket)
        {
            await _ticketRepository.DeleteAsync(ticket.Id);
            _notifier.Notify(new ChangeEvent()
            {
                Entity = ticket,
                EventType = EventType.DELETE,
                Message = "Ticket deleted"
            });
        }

        public async Task<List<Projection>> GetProjections(int cinemaId)
        {
            return await _projectionRepository.GetProjectionsByCinemaIdAsync(cinemaId);
        }

        public async Task<List<Seat>> GetAllSeatsFromHall(int hallId)
        {
            return (List<Seat>)(await _seatRepository.GetByHallAsync(hallId) ?? throw new ServiceException("No seats found"));
        }

        public async Task<Ticket> AddTicket(DateTime date, int? id_proj, int? id_seat, int? id_user)
        {
            if (id_proj == null)
                throw new ServiceException("Projection not found");

            if (id_seat == null)
                throw new ServiceException("Seat not found");

            if (id_user == null)
                throw new ServiceException("User not found");

            var ticket = new Ticket
            {
                BuyDate = date,
                ProjectionId = (int)id_proj,
                SeatId = (int)id_seat,
                UserId = (int)id_user,
                Code = Guid.NewGuid().ToString()
            };


            Ticket t = await _ticketRepository.AddWithReturnAsync(ticket);

           

            _notifier.Notify(new ChangeEvent()
            {
                Entity = ticket,
                EventType = EventType.ADD,
                Message = "Ticket added"
            }) ;

            return t;
        }

        public async Task<List<Seat>?> GetAllTakenSeatsFromProjection(int? projectionId)
        {
            if (projectionId == null)
                throw new ServiceException("Projection not found");

            return (await _projectionRepository.GetAllTakenSeatsFromProjection(projectionId) ?? null) as List<Seat>;
        }

        public async Task<List<Movie>> GetAllMovies(int cinemaId)
        {
            var movies = await _projectionRepository.GetAllMoviesByCinemaId(cinemaId);

            if (movies == null)
                throw new ServiceException("No movies found");

            return movies;
        }

        public async Task AddProjection(Projection projection)
        {
            await _projectionRepository.AddAsync(projection);
            _notifier.Notify(new ChangeEvent()
            {
                Entity = projection,
                EventType = EventType.ADD,
                Message = "Projection added"
            });
        }
    }
}
