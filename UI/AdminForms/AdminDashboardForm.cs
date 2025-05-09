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

    }

    private void button1_Click(object sender, EventArgs e)
    {
        _notifier.Notify(new ChangeEvent { Message = "Works from admin" } );
    }
}
