using CinemaApp.Domain;
using CinemaApp.Repository;
using CinemaApp.Service;
using CinemaApp.UI.AdminForms;
using CinemaApp.UI.Manager;
using CinemaApp.UI.UserForms;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
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
    private readonly IServiceProvider _serviceProvider;

    public LoginForm(IUserService userService, IAdminService adminService, FormManager formManager, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _userService = userService;
        _adminService = adminService;
        _formManager = formManager;
        _serviceProvider = serviceProvider;


        this.FormClosing += CustomEvents.FormClosing;
    }


    private void LoginForm_Load(object sender, EventArgs e)
    {
        this.BackColor = Design.Colors.Tertiary;
        button1.BackColor = Design.Colors.Primary;
        button1.ForeColor = Design.Colors.Tertiary;
        button1.MouseHover += CustomEvents.ButtonHoverEnter!;
        button1.MouseLeave += CustomEvents.ButtonHoverLeave!;

        label4.BackColor = Design.Colors.Tertiary;
        label4.ForeColor = Design.Colors.Primary;
        label4.MouseHover += CustomEvents.ButtonHoverEnter!;
        label4.MouseLeave += CustomEvents.ButtonHoverLeave!;

        tb_uname.BackColor = Design.Colors.Tertiary;
        tb_uname.ForeColor = Design.Colors.Primary;
       
        tb_pass.BackColor = Design.Colors.Tertiary;
        tb_pass.ForeColor = Design.Colors.Primary;

        label1.ForeColor = Design.Colors.Primary;
        label2.ForeColor = Design.Colors.Primary;
        label3.ForeColor = Design.Colors.Primary;



    }

    private async void button1_Click(object sender, EventArgs e)
    {
        string name = tb_uname.Text;
        string password = tb_pass.Text;

        try
        {
            var user = await _userService.LoginAsync(name, password);

            var scope = _serviceProvider.CreateScope();
            var sessionContext = scope.ServiceProvider.GetRequiredService<SessionContext>();
            sessionContext.SetUser(user);
            _formManager.SwitchToForm<UserDashboardForm>(this, FormBehavior.StayAndShowNext, true, scope);

            return;
        }
        catch (ServiceException ex)
        {
            try
            {
                var admin = await _adminService.LoginAsync(name, password);

                var scope = _serviceProvider.CreateScope();
                var sessionContext = scope.ServiceProvider.GetRequiredService<SessionContext>();
                sessionContext.SetAdmin(admin);
                _formManager.SwitchToForm<AdminDashboardForm>(this, FormBehavior.StayAndShowNext, true, scope);
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
        _formManager.SwitchToForm<RegisterForm>(this, FormBehavior.HideAndShowNext);
    }
}
