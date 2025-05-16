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
    public class AdminService(IAdminRepository adminRepository, IMovieRepository movieRepository, IHallRepository hallRepository, IProjectionRepository projectionRepository, ITicketRepository ticketRepository, Notifier notifier) : IAdminService
    {
        private readonly IAdminRepository _adminRepository = adminRepository;
        private readonly IMovieRepository _movieRepository = movieRepository;
        private readonly IHallRepository _hallRepository = hallRepository;
        private readonly IProjectionRepository _projectionRepository = projectionRepository;
        private readonly ITicketRepository _ticketRepository = ticketRepository;
        private readonly PasswordHasher<Admin> _passwordHasher = new();
        private readonly Notifier _notifier = notifier;

        public async Task AddHall(Hall hall)
        {
            if (hall == null)
                throw new ServiceException("Hall cannot be null");

            if (string.IsNullOrEmpty(hall.Name))
                throw new ServiceException("Hall name cannot be empty");

            if (hall.Capacity <= 0)
                throw new ServiceException("Hall capacity must be greater than 0");

            int id = await _hallRepository.AddWithReturnAsync(hall);
            hall.Id = id;
            _notifier.Notify(new ChangeEvent
            {
                Message = "Hall added",
                Entity = hall,
                EventType = EventType.ADD
            });
        }

        public async Task AddMovie(Movie movie)
        {
            if (movie == null)
                throw new ServiceException("Movie cannot be null");

            if (string.IsNullOrEmpty(movie.Name))
                throw new ServiceException("Movie name cannot be empty");

            if (movie.Duration <= 0)
                throw new ServiceException("Movie duration must be greater than 0");

            if (movie.Price <= 0)
                throw new ServiceException("Movie price must be greater than 0");

            await _movieRepository.AddAsync(movie);
            _notifier.Notify(new ChangeEvent {
                Message = "Movie added successfully",
                Entity = movie,
                EventType = EventType.ADD
            });

        }

        public async Task<List<Hall>> GetHalls(int cinemaId)
        {
            if (cinemaId <= 0)
                throw new ServiceException("Invalid cinema ID");

            var halls = await _hallRepository.GetHallsByCinemaId(cinemaId);
            return halls ?? throw new ServiceException("No halls found for the given cinema ID");
        }

        public Task<Ticket> GetTicket(int id)
        {
            if (id <= 0)
                throw new ServiceException("Invalid ticket ID");

            var ticket = _ticketRepository.GetByIdAsync(id);
            return ticket ?? throw new ServiceException("Ticket not found");
        }

        public async Task<Admin?> LoginAsync(string username, string password)
        {
            var admin = await _adminRepository.GetAdminByUsernameAsync(username) ?? throw new ServiceException("User not found");
            var result = _passwordHasher.VerifyHashedPassword(admin, admin.Password, password);

            if (result == PasswordVerificationResult.Failed)
                throw new ServiceException("Invalid password");

            return admin;
        }

        public async Task RemoveHall(Hall hall)
        {
            if (hall == null)
                throw new ServiceException("Hall cannot be null");

            var takenSeats = await _ticketRepository.GetTakenSeatsByHall(hall.Id);
            if (takenSeats.Any())
                throw new ServiceException("Cannot delete hall with existing tickets");

            var projections = await _projectionRepository.GetProjectionsByHallId(hall.Id);
            if (projections.Any())
                throw new ServiceException("Cannot delete hall with existing projections");

            await _hallRepository.DeleteAsync(hall.Id); 

            _notifier.Notify(new ChangeEvent
            {
                Message = "Hall deleted",
                Entity = hall,
                EventType = EventType.DELETE
            });
        }

    }
}
