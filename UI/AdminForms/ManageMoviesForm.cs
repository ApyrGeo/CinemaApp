using CinemaApp.Domain;
using CinemaApp.Service;
using CinemaApp.Service.Observer;
using CinemaApp.UI.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaApp.UI.AdminForms
{
    public partial class ManageMoviesForm : Form
    {
        private IServiceScope _scope;
        private SessionContext _sessionContext;
        private readonly CinemaContext _cinemaContext;
        private readonly IAdminService _adminService;
        public ManageMoviesForm(IAdminService adminService, SessionContext sessionContext, CinemaContext cinemaContext)
        {
            _adminService = adminService;
            _cinemaContext = cinemaContext;
            _sessionContext = sessionContext;
            InitializeComponent();
            this.FormClosing += CustomEvents.FormClosing;
        }

        public void SetScope(IServiceScope scope)
        {
            _scope = scope;
        }


        private void ManageMoviesForm_Load(object sender, EventArgs e)
        {
            label1.ForeColor = Design.Colors.Tertiary;
            label1.BackColor = Design.Colors.Primary;

            label3.ForeColor = Design.Colors.Tertiary;
            label3.BackColor = Design.Colors.Primary;

            label2.ForeColor = Design.Colors.Tertiary;
            label2.BackColor = Design.Colors.Primary;

            label4.ForeColor = Design.Colors.Tertiary;
            label4.BackColor = Design.Colors.Primary;

            tb_mv_name.BackColor = Design.Colors.Tertiary;
            tb_mv_name.ForeColor = Design.Colors.Primary;

            nrud_duration.BackColor = Design.Colors.Tertiary;
            nrud_duration.ForeColor = Design.Colors.Primary;

            nrud_price.BackColor = Design.Colors.Tertiary;
            nrud_price.ForeColor = Design.Colors.Primary;

            this.BackColor = Design.Colors.Secondary;

            btd_add_movie.BackColor = Design.Colors.Primary;
            btd_add_movie.ForeColor = Design.Colors.Tertiary;
        }

        private async void HandleAddMovie(object sender, EventArgs e)
        {
            Movie movie = new()
            {
                Name = tb_mv_name.Text,
                Duration = (int)nrud_duration.Value,
                Price = (decimal)nrud_price.Value
            };

            try
            {
                await _adminService.AddMovie(movie);
                MessageBox.Show("Movie added successfully");

                tb_mv_name.Text = string.Empty;
                nrud_duration.Value = nrud_duration.Minimum;
                nrud_price.Value = nrud_price.Minimum;

            } catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
