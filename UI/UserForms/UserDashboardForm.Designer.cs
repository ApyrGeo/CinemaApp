namespace CinemaApp.UI.UserForms;

partial class UserDashboardForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panelContainer = new FlowLayoutPanel();
        panel = new Panel();
        label1 = new Label();
        button_logout = new Button();
        button_view = new Button();
        button_buy = new Button();
        panel.SuspendLayout();
        SuspendLayout();
        // 
        // panelContainer
        // 
        panelContainer.Dock = DockStyle.Bottom;
        panelContainer.FlowDirection = FlowDirection.TopDown;
        panelContainer.Location = new Point(0, 84);
        panelContainer.Name = "panelContainer";
        panelContainer.Size = new Size(688, 519);
        panelContainer.TabIndex = 0;
        // 
        // panel
        // 
        panel.Controls.Add(label1);
        panel.Controls.Add(panelContainer);
        panel.Dock = DockStyle.Left;
        panel.Location = new Point(0, 0);
        panel.Name = "panel";
        panel.Size = new Size(688, 603);
        panel.TabIndex = 5;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
        label1.Location = new Point(232, 20);
        label1.Name = "label1";
        label1.Size = new Size(201, 41);
        label1.TabIndex = 1;
        label1.Text = "Active Tickets";
        // 
        // button_logout
        // 
        button_logout.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
        button_logout.Location = new Point(752, 355);
        button_logout.Name = "button_logout";
        button_logout.Size = new Size(214, 60);
        button_logout.TabIndex = 8;
        button_logout.Text = "Logout";
        button_logout.UseVisualStyleBackColor = true;
        button_logout.Click += HandleLogout;
        // 
        // button_view
        // 
        button_view.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
        button_view.Location = new Point(752, 249);
        button_view.Name = "button_view";
        button_view.Size = new Size(214, 60);
        button_view.TabIndex = 7;
        button_view.Text = "View Movies";
        button_view.UseVisualStyleBackColor = true;
        button_view.Click += HandleViewMovies;
        // 
        // button_buy
        // 
        button_buy.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
        button_buy.Location = new Point(752, 145);
        button_buy.Name = "button_buy";
        button_buy.Size = new Size(214, 60);
        button_buy.TabIndex = 6;
        button_buy.Text = "Buy Ticket";
        button_buy.UseVisualStyleBackColor = true;
        button_buy.Click += HandleBuyTicket;
        // 
        // UserDashboardForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1013, 603);
        Controls.Add(panel);
        Controls.Add(button_logout);
        Controls.Add(button_view);
        Controls.Add(button_buy);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "UserDashboardForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "UserDashboardForm";
        Load += UserDashboardForm_Load;
        Shown += UserDashboardForm_Shown;
        panel.ResumeLayout(false);
        panel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private FlowLayoutPanel panelContainer;
    private Panel panel;
    private Label label1;
    private Button button_logout;
    private Button button_view;
    private Button button_buy;
}