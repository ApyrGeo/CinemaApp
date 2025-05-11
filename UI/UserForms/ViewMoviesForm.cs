using CinemaApp.Domain;
using CinemaApp.Service;
using CinemaApp.Service.Observer;
using CinemaApp.UI.Components;
using CinemaApp.UI.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaApp.UI.UserForms
{
    public partial class ViewMoviesForm : Form, Service.Observer.IObserver<ChangeEvent>
    {
        private readonly IUserService _userService;
        private readonly Notifier _notifier;
        private SessionContext _sessionContext;
        private CinemaContext _cinemaContext;
        public ViewMoviesForm(IUserService userService, CinemaContext cinemaContext, Notifier notifier)
        {
            InitializeComponent();

            _userService = userService;
            _cinemaContext = cinemaContext;
            _notifier = notifier;
            this.FormClosing += CustomEvents.FormClosing;
            _notifier.Subscribe(this);
        }

        private void ViewMoviesForm_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Design.Colors.Primary;
            panelComponents.BackColor = Design.Colors.Secondary;

            label1.ForeColor = Design.Colors.Tertiary;
        }

        private void ViewMoviesForm_Shown(object sender, EventArgs e)
        {
            PopulateMoviePanel();
        }

        private async void PopulateMoviePanel()
        {
            List<Projection> movies = await _userService.GetProjections(_cinemaContext.CinemaId);
            Invoke(new Action(() =>
            {

                panelComponents.Controls.Clear();
                foreach (Projection movie in movies)
                {
                    MovieCardControl movieCardControl = new()
                    {
                        Name = movie.Movie.Name,
                        Duration = movie.Movie.Duration.ToString(),
                        Price = movie.Movie.Price.ToString(),
                        Date = movie.Date.ToString("dd/MM/yyyy"),
                        Width = (int) (49.5f / 100f * (float)panelComponents.Width)
                    };

                    panelComponents.Controls.Add(movieCardControl);
                }

            }));
        }

        public void Update(ChangeEvent data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Update(data)));
                return;
            }
            switch (data.Entity)
            {
                case Projection projection:
                    if (data.EventType == EventType.ADD)
                    {
                        AddProjectionToList(projection);
                    }
                    else if (data.EventType == EventType.DELETE)
                    {
                        RemoveProjectionFromList(projection);
                    }

                    break;
            }
        }

        private void RemoveProjectionFromList(Projection projection)
        {
            Invoke(new Action(() =>
            {
                foreach (Control control in panelComponents.Controls)
                {
                    if (control is MovieCardControl movieCardControl && movieCardControl.Name == projection.Movie.Name)
                    {
                        panelComponents.Controls.Remove(control);
                        break;
                    }
                }
            }));
        }

        private void AddProjectionToList(Projection projection)
        {
            Invoke(new Action(() =>
            {
                MovieCardControl movieCardControl = new()
                {
                    Name = projection.Movie.Name,
                    Duration = projection.Movie.Duration.ToString(),
                    Price = projection.Movie.Price.ToString(),
                    Date = projection.Date.ToString("dd/MM/yyyy"),
                };

                panelComponents.Controls.Add(movieCardControl);
            }));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await _userService.AddProjection(new Projection()
            {
                Date = DateTime.Now,
                MovieId = 1,
                HallId = 1,
            });
        }
    }
}
