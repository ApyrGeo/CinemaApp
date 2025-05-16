using CinemaApp.Domain;
using CinemaApp.Service;
using CinemaApp.Service.Observer;
using CinemaApp.UI.Manager;
using CinemaApp.UI.Utils;
using CinemaAPp.UI.Utils;
using Microsoft.Extensions.DependencyInjection;
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

public partial class AdminDashboardForm : Form, IHasSessionContext, IScopedForm
{
    private readonly FormManager _formManager;
    private readonly Notifier _notifier;
    private readonly IAdminService _service;
    private SessionContext _sessionContext;
    private readonly CinemaContext _cinemaContext;
    private IServiceScope _scope;

    public AdminDashboardForm(IAdminService service, FormManager formManager, Notifier notifier, CinemaContext cinemaContext)
    {
        InitializeComponent();
        _formManager = formManager;
        _notifier = notifier;
        _service = service;
        _cinemaContext = cinemaContext;

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
        _formManager.SwitchToForm<ManageMoviesForm>(this, FormBehavior.HideAndShowNext, false, _scope);
    }

    private void HandleManageHalls(object sender, EventArgs e)
    {
        _formManager.SwitchToForm<ManageHallsForm>(this, FormBehavior.HideAndShowNext, false, _scope);
    }

    private void HandleManageProjections(object sender, EventArgs e)
    {

    }

    public void SetScope(IServiceScope scope)
    {
        this._scope = scope;
    }

    private async void HandleScanCode(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new()
        {
            Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
            Title = "Select a QR Code Image"
        };
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;
            Bitmap qrCodeImage = new Bitmap(filePath);

            try
            {
                string decodedText = QRCodeHelper.DecodeQRCode(qrCodeImage);

                Ticket ticket = JsonParser.DeserializeTicket(decodedText);

                Ticket real = await _service.GetTicket(ticket.Id);

                if (real.Code != ticket.Code)
                {
                    throw new Exception("Invalid ticket");
                }

                MessageBox.Show(real.ToString(), "Ticket is valid!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decoding QR code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async Task ValidateTicket(Ticket ticket)
    {
        Ticket real = await _service.GetTicket(ticket.Id);

        if(real.Code != ticket.Code)
        {
            throw new Exception("Invalid ticket");
        }

    }
}
