using CinemaApp.EFData;
using CinemaApp.Repository;
using CinemaApp.Repository.DB;
using CinemaApp.Service;
using CinemaApp.UI.AdminForms;
using CinemaApp.UI.UserForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CinemaApp.UI.Manager;
using Service;
using CinemaApp.Service.Observer;

namespace CinemaApp.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName)
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();

            // Repositories
            services.AddScoped<IUserRepository, UserDBRepository>();
            services.AddScoped<IAdminRepository, AdminDBRepository>();
            services.AddScoped<IMovieRepository, MovieDBRepository>();
            services.AddScoped<ITicketRepository, TicketDBRepository>();
            services.AddScoped<IProjectionRepository, ProjectionDBRepository>();
            services.AddScoped<ICinemaRepository, CinemaDBRepository>();
            services.AddScoped<ISeatRepository, SeatDBRepository>();
            services.AddScoped<IHallRepository, HallDBRepository>();
            services.AddScoped<SessionContext>();

            // Forms
            services.AddScoped<LoginForm>();
            //services.AddScoped<UserDashboardForm>();
            //services.AddScoped<AdminDashboardForm>();
            services.AddTransient<UserDashboardForm>();
            services.AddTransient<AdminDashboardForm>();
            services.AddScoped<ViewMoviesForm>();
            services.AddScoped<BuyTicketForm>();
            services.AddScoped<LandingForm>();
            services.AddScoped<RegisterForm>();
            services.AddScoped<ManageMoviesForm>();
            services.AddScoped<ManageHallsForm>();
            ///Add future forms

            // Singleton FormManager
            services.AddSingleton<Notifier>();
            services.AddSingleton<FormManager>();

            int cinemaId = 1;
            services.AddSingleton<CinemaContext>(new CinemaContext(cinemaId));

            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            var landingForm = provider.GetRequiredService<LandingForm>();
            Application.Run(landingForm);
        }
    }
}