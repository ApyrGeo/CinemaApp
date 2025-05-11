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
    public partial class TicketCardControl : UserControl
    {
        public string MovieName
        {
            get => label_moviename.Text;
            set => label_moviename.Text = value;
        }
        public string HallName
        {
            get => label_hallname.Text;
            set => label_hallname.Text = "Hall: " + value;
        }
        public string SeatName
        {
            get => label_seatname.Text;
            set => label_seatname.Text = "Seat: " + value;
        }
        public string ProjectionDate
        {
            get => label_date.Text;
            set => label_date.Text = "Projection at: " + value;
        }
        public int Id { get; internal set; }
        public int SeatId { get; internal set; }
        public int ProjectionId { get; internal set; }

        public TicketCardControl()
        {
            InitializeComponent();
        }

        private void TicketCardControl_Load(object sender, EventArgs e)
        {
            this.BackColor = Design.Colors.Primary;
            this.ForeColor = Design.Colors.Tertiary;
        }
    }
}
