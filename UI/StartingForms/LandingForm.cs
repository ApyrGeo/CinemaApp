using CinemaApp.Domain;
using CinemaApp.Repository;
using CinemaApp.Service;
using CinemaApp.UI.Manager;
using CinemaApp.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaApp.UI.Components;

namespace CinemaApp.UI;

public partial class LandingForm : Form
{
    private readonly IUserService _userService;
    private readonly FormManager _formManager;
    public LandingForm(IUserService userService, FormManager formManager)
    {
        _userService = userService;
        _formManager = formManager;
        InitializeComponent();

        this.FormClosing += CustomEvents.FormClosing!;

        LoadMovieCards();
    }

    private void LandingForm_Load(object sender, EventArgs e)
    {
        this.BackColor = Design.Colors.Secondary;
        btn_login.BackColor = Design.Colors.Primary;
        btn_login.ForeColor = Design.Colors.Tertiary;
        label1.ForeColor = Design.Colors.Primary;

        btn_login.MouseHover += CustomEvents.ButtonHoverEnter!;
        btn_login.MouseLeave += CustomEvents.ButtonHoverLeave!;
    }

    private void btn_login_Click(object sender, EventArgs e)
    {
        _formManager.SwitchToForm<LoginForm>(this, FormBehavior.HideAndShowNext);
    }

    private async void LoadMovieCards()
    {
        List<Movie> movies = await _userService.GetAllMovies();
        foreach (var movie in movies)
        {
            MovieCardControl card = new()
            {
                Name = movie.Name,
                Duration = movie.Duration.ToString(),
                Width = panelContainer.Width - 20,
                Margin = new Padding(10)

            };

            panelContainer.Controls.Add(card);
        }

    }

}
