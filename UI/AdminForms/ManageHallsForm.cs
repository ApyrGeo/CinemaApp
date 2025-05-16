using CinemaApp.Domain;
using CinemaApp.Service;
using CinemaApp.Service.Observer;
using CinemaApp.UI.Components;
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

public partial class ManageHallsForm : Form, Service.Observer.IObserver<ChangeEvent>
{
    private readonly IAdminService _adminService;
    private readonly CinemaContext _cinemaContext;
    public ManageHallsForm(IAdminService adminService, CinemaContext cinemaContext)
    {
        _adminService = adminService;
        _cinemaContext = cinemaContext;
        InitializeComponent();
    }

    private void ManageHallsForm_Load(object sender, EventArgs e)
    {
        label1.ForeColor = Design.Colors.Tertiary;

        btn_add_hall.BackColor = Design.Colors.Primary;
        btn_add_hall.ForeColor = Design.Colors.Tertiary;

        btn_add_hall.MouseEnter += CustomEvents.ButtonHoverEnter;
        btn_add_hall.MouseLeave += CustomEvents.ButtonHoverLeave;

        panelComponents.BackColor = Design.Colors.Secondary;

        this.BackColor = Design.Colors.Primary;
    }

    private async void ManageHallsForm_Shown(object sender, EventArgs e)
    {
        await Task.Yield();
        PopulateHalls();
    }

    private async void PopulateHalls()
    {
        List<Hall> halls = await _adminService.GetHalls(_cinemaContext.CinemaId);
        Invoke(new Action(() =>
        {

            panelComponents.Controls.Clear();
            foreach (Hall hall in halls)
            {
                HallCardControl hallCardControl = new()
                {
                    Id = hall.Id,
                    Name = hall.Name,
                    Capacity = hall.Capacity.ToString(),
                    Width = (int)(49f / 100f * (float)panelComponents.Width)
                };
                hallCardControl.MouseClick += HandleDelete;

                panelComponents.Controls.Add(hallCardControl);
            }

        }));
    }

    private async void HandleAddHall(object sender, EventArgs e)
    {
        string name = Microsoft.VisualBasic.Interaction.InputBox("Enter hall name", "Add Hall", "Hall 1");
        string capacityStr = Microsoft.VisualBasic.Interaction.InputBox("Enter hall capacity", "Add Hall", "100");
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(capacityStr))
        {
            MessageBox.Show("Please enter valid values for hall name and capacity.");
            return;
        }

        if (!int.TryParse(capacityStr, out int capacity))
        {
            MessageBox.Show("Please enter a valid number for hall capacity.");
            return;
        }

        Hall hall = new()
        {
            Name = name,
            Capacity = capacity,
            CinemaId = _cinemaContext.CinemaId
        };

        try
        {
            await _adminService.AddHall(hall);
            MessageBox.Show("Hall added successfully.");
        }
        catch (ServiceException ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        
    }

    public void Update(ChangeEvent data)
    {
        if(InvokeRequired)
        {
            Invoke(new Action(() => Update(data)));
            return;
        }

        switch (data.Entity)
        {
            case Hall hall:
                if (data.EventType == EventType.ADD)
                {
                    HallCardControl hallCardControl = new()
                    {
                        Id = hall.Id,
                        Name = hall.Name,
                        Capacity = hall.Capacity.ToString(),
                        Width = (int)(49f / 100f * (float)panelComponents.Width)
                        
                    };
                    hallCardControl.MouseClick += HandleDelete;

                    Invoke(new Action(() =>
                    {
                        panelComponents.Controls.Add(hallCardControl);
                    }));
                    break;
                }
                else if (data.EventType == EventType.DELETE)
                {
                    foreach (Control control in panelComponents.Controls)
                    {
                        if (control is HallCardControl hallCard && hallCard.Id == hall.Id)
                        {
                            Invoke(new Action(() =>
                            {
                                panelComponents.Controls.Remove(control);
                            }));
                            break;
                        }
                    }
                }
                break;
        }
    }

    public async void HandleDelete(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right)
            return;

        DialogResult result = MessageBox.Show("Are you sure you want to delete this hall?", "Delete Hall", MessageBoxButtons.YesNo);
        if (result != DialogResult.Yes)
            return;

        int Id = (sender as HallCardControl).Id;
        try
        {
            await _adminService.RemoveHall(new Hall() { Id = Id });

            MessageBox.Show("Hall deleted successfully!");
        }catch (ServiceException ex)
        {
            MessageBox.Show(ex.Message);
        }
       

    }
}
