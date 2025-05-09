using CinemaApp.Repository;
using CinemaApp.Service;
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

        this.FormClosing += CustomEvents.FormClosing;
    }

    private void LandingForm_Load(object sender, EventArgs e)
    {

    }

    private void btn_login_Click(object sender, EventArgs e)
    {
        _formManager.SwitchToForm<LoginForm>(this);
    }
}
