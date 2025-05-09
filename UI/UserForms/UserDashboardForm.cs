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

namespace CinemaApp.UI.UserForms;

public partial class UserDashboardForm : Form
{
    private readonly FormManager _formManager;

    public UserDashboardForm(FormManager formManager)
    {
        this._formManager = formManager;

        InitializeComponent();
        this.FormClosing += CustomEvents.FormClosing;
    }
}
