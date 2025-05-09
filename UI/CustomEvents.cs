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
                // Exit the application when LandingForm is closed
                Application.Exit();
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                // Cancel close event and hide the form instead of closing it
                e.Cancel = true;
                // Hide the current form
                ((Form)sender).Hide();
            }
        }
    }
}
