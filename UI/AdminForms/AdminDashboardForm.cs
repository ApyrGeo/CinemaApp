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

namespace CinemaApp.UI.AdminForms;

public partial class AdminDashboardForm : Form
{
    private readonly FormManager _formManager;
    public AdminDashboardForm(FormManager formManager)
    {
        _formManager = formManager;
        InitializeComponent();

    }
}
