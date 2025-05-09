using CinemaApp.Domain;
using CinemaApp.Service;
using CinemaApp.Service.Observer;
using CinemaApp.UI.Components;
using CinemaApp.UI.Manager;
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

namespace CinemaApp.UI.UserForms
{
    public partial class BuyTicketForm : Form, IHasSessionContext, IScopedForm, Service.Observer.IObserver<ChangeEvent>
    {
        private SessionContext _sessionContext;
        private readonly IUserService _userService;
        private readonly CinemaContext _cinemaContext;
        private IServiceScope _scope;

        private Button _currentButton;

        public BuyTicketForm(IUserService userService, CinemaContext cinemaContext)
        {
            _userService = userService;
            _cinemaContext = cinemaContext;

            InitializeComponent();
            this.FormClosing += CustomEvents.FormClosing;
        }

        
        public void SetSessionContext(SessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }

        private void BuyTicketForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Design.Colors.Tertiary;
            button_buy.BackColor = Design.Colors.Primary;
            button_buy.ForeColor = Design.Colors.Tertiary;

            button_buy.MouseEnter += CustomEvents.ButtonHoverEnter;
            button_buy.MouseLeave += CustomEvents.ButtonHoverLeave;

            cb_projections.BackColor = Design.Colors.Primary;
            cb_projections.ForeColor = Design.Colors.Tertiary;
            cb_projections.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_projections.FlatStyle = FlatStyle.Flat;

            label1.ForeColor = Design.Colors.Primary;
            label2.ForeColor = Design.Colors.Primary;
            label3.ForeColor = Design.Colors.Primary;
            label4.ForeColor = Design.Colors.Primary;
            label5.ForeColor = Design.Colors.Primary;
            label6.ForeColor = Design.Colors.Primary;
            label7.ForeColor = Design.Colors.Primary;

            tb_hallname.BackColor = Design.Colors.Primary;
            tb_hallname.ForeColor = Design.Colors.Tertiary;

            tb_moviename.BackColor = Design.Colors.Primary;
            tb_moviename.ForeColor = Design.Colors.Tertiary;

            tb_price.BackColor = Design.Colors.Primary;
            tb_price.ForeColor = Design.Colors.Tertiary;

            tb_seatname.BackColor = Design.Colors.Primary;
            tb_seatname.ForeColor = Design.Colors.Tertiary;

            panelControls.BackColor = Design.Colors.Quaternary;
        }

        public void SetScope(IServiceScope scope)
        {
            _scope = scope;
        }

        private async void PopulateProjectionsComboBox()
        {
            var projections = await _userService.GetProjections(_cinemaContext.CinemaId);

            if (projections == null) return;

            Invoke(new Action(() =>
            {
                cb_projections.Items.Clear();
                foreach (var projection in projections)
                {
                    cb_projections.Items.Add(projection);
                }
            }));

            
        }

        private async void BuyTicketForm_Shown(object sender, EventArgs e)
        {
            await Task.Yield();
            PopulateProjectionsComboBox();
        }

        private void cb_projections_SelectedIndexChanged(object sender, EventArgs e)
        {
            Projection? p = cb_projections.SelectedItem as Projection;

            tb_hallname.Text = p?.Hall.Name;
            tb_moviename.Text = p?.Movie.Name;
            tb_price.Text = p?.Movie.Price.ToString();

            PopulateSeatsPanel(p.Hall.Id);
        }

        private async void PopulateSeatsPanel(int hallId)
        { 
            int projectionId = ((Projection)cb_projections.SelectedItem).Id;

            List<Seat> seats = await _userService.GetAllSeatsFromHall(hallId);

            List<Seat> taken_seats = await _userService.GetAllTakenSeatsFromProjection(projectionId);
 
            if (seats == null) return;

            int length = CalculateLength(seats.Count);

            Invoke(new Action(() =>
            {
                foreach (var seat in seats)
                {
                    Button button = new()
                    {
                        Text = seat.Name,
                        BackColor = Design.Colors.Primary,
                        ForeColor = Design.Colors.Tertiary,
                        FlatStyle = FlatStyle.Flat,
                        Width = length,
                        Height = length,
                        Tag = seat
                    };

                    if(taken_seats != null && taken_seats.Contains(seat))
                    {
                        button.BackColor = Design.Colors.Tertiary;
                        button.ForeColor = Design.Colors.Quinary;
                        button.Enabled = false;

                    }

                    button.Click += HandleChangedSeatEvent;

                    panelControls.Controls.Add(button);
                }
            }));
        }

        private int CalculateLength(int noSeats)
        {
            float width = panelControls.Width;
            float sqrt = (float)Math.Sqrt(noSeats);


            float length = (float)Math.Ceiling(width / sqrt);
            length -= 1.5f/10f * length;

            return (int)length;
        }

        private void HandleChangedSeatEvent(object sender, EventArgs e)
        {
            Button? button = sender as Button;

            if (_currentButton != null)
            {
                _currentButton.BackColor = Design.Colors.Primary;
                _currentButton.ForeColor = Design.Colors.Tertiary;
            }

            button.BackColor = Design.Colors.Tertiary;
            button.ForeColor = Design.Colors.Primary;

            _currentButton = button;

            tb_seatname.Text = button.Text;
            tb_seatname.Tag = button.Tag;
        }

        private async void HandleBuyTicket(object sender, EventArgs e)
        {
            try
            {
                if (cb_projections.SelectedIndex < 0) 
                   throw new Exception("Projection not selected!");

                if (_currentButton == null)
                    throw new Exception("Seat not selected!");

                if (tb_seatname.Tag == null)
                    throw new Exception("Seat not selected!");

                await _userService.AddTicket(
                        DateTime.Now,
                        ((Projection)cb_projections.SelectedItem).Id,
                        ((Seat)tb_seatname.Tag).Id,
                        _sessionContext.LoggedInUser!.Id
                    );

                MessageBox.Show("Ticket bought");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
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
                    if (data.EventType == EventType.DELETE || data.EventType == EventType.ADD)
                    {
                        Projection? p = cb_projections.SelectedItem as Projection;
                        if (p == null) break;
                        ChangeSeatStatus(ticket.Seat.Id);
                    }
                    
                    
                    break;
            }
        }

        private void ChangeSeatStatus(int id)
        {
            Button? wanted = panelControls.Controls
                .OfType<Button>()
                .FirstOrDefault(b => ((Seat)b.Tag).Id == id);



            Invoke(new Action(() =>
            {
                if (wanted != null)
                {
                    if (wanted.Enabled == false)
                    {
                        wanted.BackColor = Design.Colors.Primary;
                        wanted.ForeColor = Design.Colors.Tertiary;
                        wanted.Enabled = true;
                    }
                    else
                    {
                        wanted.BackColor = Design.Colors.Tertiary;
                        wanted.ForeColor = Design.Colors.Quinary;
                        wanted.Enabled = false;
                    }
                }
            }));
        }
    }
}
