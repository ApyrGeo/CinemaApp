using CinemaApp.Domain;
using CinemaApp.Repository;
using CinemaApp.Service;
using CinemaApp.UI.AdminForms;
using CinemaApp.UI.Manager;
using CinemaApp.UI.UserForms;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Service;
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

public partial class LoginForm : Form
{
    private readonly IUserService _userService;
    private readonly IAdminService _adminService;
    private readonly FormManager _formManager;
    private readonly SessionContext _sessionContext;
    public LoginForm(IUserService userService, IAdminService adminService, FormManager formManager, SessionContext sessionContext)
    {
        _userService = userService;
        _adminService = adminService;
        _formManager = formManager;
        _sessionContext = sessionContext;
        InitializeComponent();

        this.FormClosing += CustomEvents.FormClosing;
    }


    private void LoginForm_Load(object sender, EventArgs e)
    {
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        string name = tb_uname.Text;
        string password = tb_pass.Text;

        try
        {
            var user = await _userService.LoginAsync(name, password);
            _sessionContext.SetUser(user);
            _formManager.SwitchToForm<UserDashboardForm>(this);
            return;
        }
        catch (ServiceException ex)
        {
            try
            {
                var admin = await _adminService.LoginAsync(name, password);
                _sessionContext.SetAdmin(admin);
                _formManager.SwitchToForm<AdminDashboardForm>(this);
                return;

            }
            catch (ServiceException?)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        finally
        {
            tb_uname.Clear();
            tb_pass.Clear();
        }
    }

    private void label4_Click(object sender, EventArgs e)
    {
        _formManager.SwitchToForm<RegisterForm>(this);
    }
}
