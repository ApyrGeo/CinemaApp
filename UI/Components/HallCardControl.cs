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
    public partial class HallCardControl : UserControl
    {
        public int Id { get; set; }
        public new string Name
        {
            get => lbl_hall_name.Text;
            set => lbl_hall_name.Text = "Hall: " + value;
        }

        public string Capacity
        {
            get => lbl_hall_cap.Text;
            set => lbl_hall_cap.Text = value + " seats";
        }
        public HallCardControl()
        {
            InitializeComponent();
        }

        private void HallCardControl_Load(object sender, EventArgs e)
        {
            this.BackColor = Design.Colors.Primary;
            lbl_hall_cap.ForeColor = Design.Colors.Tertiary;
            lbl_hall_name.ForeColor = Design.Colors.Tertiary;
        }
    }
}
