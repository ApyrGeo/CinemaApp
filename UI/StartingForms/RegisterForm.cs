using CinemaApp.Service;
using CinemaApp.UI.Manager;
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

public partial class RegisterForm : Form
{
    private readonly IUserService _userService;
    public RegisterForm(IUserService userService)
    {
        _userService = userService;
        InitializeComponent();
        this.FormClosing += CustomEvents.FormClosing;
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        string uname = tb_uname.Text;
        string password = tb_pass.Text;
        string cpassword = tb_cpass.Text;

        if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cpassword))
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }
        if (password != cpassword)
        {
            MessageBox.Show("Passwords do not match.");
            return;
        }

        try
        {
            await _userService.RegisterAsync(uname, password);
            MessageBox.Show("Registration successful. You can now log in.");
            this.Close();
        }
        catch (ServiceException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void RegisterForm_Load(object sender, EventArgs e)
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

        tb_cpass.BackColor = Design.Colors.Tertiary;
        tb_cpass.ForeColor = Design.Colors.Primary;

        label1.ForeColor = Design.Colors.Primary;
        label2.ForeColor = Design.Colors.Primary;
        label3.ForeColor = Design.Colors.Primary;
        label4.ForeColor = Design.Colors.Primary;
    }
}
