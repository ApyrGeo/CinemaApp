using CinemaApp.Service;
using CinemaApp.Service.Observer;
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

public partial class AdminDashboardForm : Form, Service.Observer.IObserver<ChangeEvent>, IHasSessionContext
{
    private readonly FormManager _formManager;
    private readonly Notifier _notifier;
    private readonly IAdminService _service;
    private SessionContext _sessionContext;
    private readonly CinemaContext _cinemaContext;

    public AdminDashboardForm(IAdminService service, FormManager formManager, Notifier notifier, CinemaContext cinemaContext)
    {
        InitializeComponent();
        _formManager = formManager;
        _notifier = notifier;
        _service = service;
        _cinemaContext = cinemaContext;

        _notifier.Subscribe(this);
    }

    public void Update(ChangeEvent data)
    {
        MessageBox.Show(data.Message);
    }

    public void SetSessionContext(SessionContext sessionContext)
    {
        _sessionContext = sessionContext;
    }

    private void AdminDashboardForm_Load(object sender, EventArgs e)
    {
        this.BackColor = Design.Colors.Tertiary;

        button_managehalls.BackColor = Design.Colors.Primary;
        button_managehalls.ForeColor = Design.Colors.Tertiary;
        button_managehalls.MouseEnter += CustomEvents.ButtonHoverEnter;
        button_managehalls.MouseLeave += CustomEvents.ButtonHoverLeave;

        button_managemovies.BackColor = Design.Colors.Primary;
        button_managemovies.ForeColor = Design.Colors.Tertiary;
        button_managemovies.MouseEnter += CustomEvents.ButtonHoverEnter;
        button_managemovies.MouseLeave += CustomEvents.ButtonHoverLeave;

        button_manageprojections.BackColor = Design.Colors.Primary;
        button_manageprojections.ForeColor = Design.Colors.Tertiary;
        button_manageprojections.MouseEnter += CustomEvents.ButtonHoverEnter;
        button_manageprojections.MouseLeave += CustomEvents.ButtonHoverLeave;


    }


    private void HandleManageMovies(object sender, EventArgs e)
    {

    }

    private void HandleManageHalls(object sender, EventArgs e)
    {

    }

    private void HandleManageProjections(object sender, EventArgs e)
    {

    }
}
