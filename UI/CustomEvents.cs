using CinemaApp.UI.UserForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.UI
{
    public class CustomEvents
    {
        public static void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender.GetType() == typeof(LandingForm))
            {
                Application.Exit();
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide();
            }
        }

        public static void ButtonHoverEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Design.Colors.Tertiary;
                button.ForeColor = Design.Colors.Primary;
                button.Cursor = Cursors.Hand;
            }
        }

        public static void ButtonHoverLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Design.Colors.Primary;
                button.ForeColor = Design.Colors.Tertiary;
                button.Cursor = Cursors.Default;
            }
        }
    }
}
