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

namespace CinemaApp.UI.Components
{
    public partial class MovieCardControl : UserControl
    {
        public new string Name
        {
            get => labelMovieName.Text;
            set => labelMovieName.Text = value;
        }
        public string Duration
        {
            get => labelMovieDuration.Text;
            set => labelMovieDuration.Text = value + " minutes";
        }
        public string Price
        {
            get => labelMoviePrice.Text;
            set => labelMoviePrice.Text = "Price " + value + " RON";
        }
        public MovieCardControl()
        {
            InitializeComponent();
        }

        private void MovieCardControl_Load(object sender, EventArgs e)
        {
            this.BackColor = Design.Colors.Primary;
            this.ForeColor = Design.Colors.Tertiary;
        }
    }
}
