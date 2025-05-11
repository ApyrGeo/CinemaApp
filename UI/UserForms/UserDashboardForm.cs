using CinemaApp.Domain;
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
using CinemaApp.Service.Observer;
using CinemaApp.Service;
using CinemaApp.UI.Components;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaApp.UI.UserForms;

public partial class UserDashboardForm : Form, Service.Observer.IObserver<ChangeEvent>, IHasSessionContext, IScopedForm
{
    private readonly FormManager _formManager;
    private readonly Notifier _notifier;
    private readonly IUserService _service;
    private readonly CinemaContext _cinemaContext;
    private IServiceScope _scope;
    private SessionContext _sessionContext;

    public UserDashboardForm(IUserService service, FormManager formManager, Notifier notifier, CinemaContext cinemaContext, SessionContext sessionContext)
    {
        InitializeComponent();

        this._formManager = formManager;
        this._notifier = notifier;
        this._service = service;
        this._sessionContext = sessionContext;

        this._cinemaContext = cinemaContext;

        _notifier.Subscribe(this);

        this.FormClosing += (s,e) => { _sessionContext.Clear(); };
    }

    public void Update(ChangeEvent data)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => Update(data)));
            return;
        }

        switch (data.Entity)
        {
            case Ticket ticket:
                if (data.EventType == EventType.ADD)
                {
                    if (ticket.UserId == _sessionContext.LoggedInUser.Id)
                    {
                        AddTicketToList(ticket);
                    }
                }


                break;
        }
    }

    private void AddTicketToList(Ticket ticket)
    {
        Invoke(new Action(() =>
        {
            var ticketControl = new TicketCardControl
            {
                Id = ticket.Id,
                Width = panelContainer.Width - 20,
                Margin = new Padding(10),
                MovieName = ticket.Projection.Movie.Name,
                ProjectionDate = ticket.Projection.Date.ToString("dd/MM/yyyy"),
                SeatName = ticket.Seat.Name,
                SeatId = ticket.Seat.Id,
                HallName = ticket.Projection.Hall.Name,
                ProjectionId = ticket.Projection.Id
            };

            ticketControl.MouseClick += TicketClicked;
            panelContainer.Controls.Add(ticketControl);
        }));
    }

    private void UserDashboardForm_Load(object sender, EventArgs e)
    {
        this.BackColor = Design.Colors.Tertiary;
        button_buy.BackColor = Design.Colors.Primary;
        button_buy.ForeColor = Design.Colors.Tertiary;
        button_buy.MouseHover += CustomEvents.ButtonHoverEnter!;
        button_buy.MouseLeave += CustomEvents.ButtonHoverLeave!;

        button_logout.BackColor = Design.Colors.Primary;
        button_logout.ForeColor = Design.Colors.Tertiary;
        button_logout.MouseHover += CustomEvents.ButtonHoverEnter!;
        button_logout.MouseLeave += CustomEvents.ButtonHoverLeave!;

        button_view.BackColor = Design.Colors.Primary;
        button_view.ForeColor = Design.Colors.Tertiary;
        button_view.MouseHover += CustomEvents.ButtonHoverEnter!;
        button_view.MouseLeave += CustomEvents.ButtonHoverLeave!;

        label1.ForeColor = Design.Colors.Tertiary;
        panel.BackColor = Design.Colors.Primary;
        panelContainer.BackColor = Design.Colors.Secondary;
    }

    private async void PopulateUserTickets()
    {

        var userTickets = await _service.GetUserTickets(_sessionContext.LoggedInUser.Id);
        if (userTickets == null || userTickets.Count == 0)
            return;

        Invoke(new Action(() =>
        {
            panelContainer.Controls.Clear();
            foreach (var ticket in userTickets)
            {
                var ticketControl = new TicketCardControl
                {
                    Id = ticket.Id,
                    Width = panelContainer.Width - 20,
                    Margin = new Padding(10),
                    MovieName = ticket.Projection.Movie.Name,
                    ProjectionDate = ticket.Projection.Date.ToString("dd/MM/yyyy"),
                    SeatName = ticket.Seat.Name,
                    SeatId = ticket.Seat.Id,
                    HallName = ticket.Projection.Hall.Name,
                    ProjectionId = ticket.Projection.Id
                };

                ticketControl.MouseClick += TicketClicked;
                panelContainer.Controls.Add(ticketControl);
            }
        }));

    }
    public async void TicketClicked(object? sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        if (!_sessionContext.IsUser) return;

        DialogResult result = MessageBox.Show("Do you want to delete this ticket?", "Delete Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            TicketCardControl? ticketControl = sender as TicketCardControl;
            if (ticketControl != null)
            {
                var ticketId = ticketControl.Id;
                var seatId = ticketControl.SeatId;
                var projectionId = ticketControl.ProjectionId;
                await _service.DeleteTicket(new Ticket()
                {
                    Id = ticketId,
                    SeatId = seatId,
                    ProjectionId = projectionId
                });
                

                Invoke(new Action(() =>
                {
                    panelContainer.Controls.Remove(ticketControl);
                }));

                MessageBox.Show("Ticket deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private async void UserDashboardForm_Shown(object sender, EventArgs e)
    {
        await Task.Yield();
        PopulateUserTickets();
    }

    public void SetSessionContext(SessionContext sessionContext)
    {
        _sessionContext = sessionContext;
    }

    private void HandleLogout(object sender, EventArgs e)
    {
        _sessionContext.Clear();
        Invoke(new Action(() =>
        {
            this.Close();
        }));
        
    }

    private void HandleBuyTicket(object sender, EventArgs e)
    {
        _formManager.SwitchToForm<BuyTicketForm>(this, FormBehavior.HideAndShowNext, false, _scope);
    }

    public void SetScope(IServiceScope scope)
    {
        _scope = scope;
    }

    private void HandleViewMovies(object sender, EventArgs e)
    {
        _formManager.SwitchToForm<ViewMoviesForm>(this, FormBehavior.HideAndShowNext, false, _scope);
    }
}
