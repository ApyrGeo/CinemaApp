namespace CinemaApp.UI.AdminForms;

partial class AdminDashboardForm
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
        button_managemovies = new Button();
        button_managehalls = new Button();
        button_manageprojections = new Button();
        btn_validate = new Button();
        SuspendLayout();
        // 
        // button_managemovies
        // 
        button_managemovies.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        button_managemovies.Location = new Point(137, 61);
        button_managemovies.Name = "button_managemovies";
        button_managemovies.Size = new Size(199, 67);
        button_managemovies.TabIndex = 0;
        button_managemovies.Text = "Manage Movies";
        button_managemovies.UseVisualStyleBackColor = true;
        button_managemovies.Click += HandleManageMovies;
        // 
        // button_managehalls
        // 
        button_managehalls.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        button_managehalls.Location = new Point(137, 183);
        button_managehalls.Name = "button_managehalls";
        button_managehalls.Size = new Size(199, 67);
        button_managehalls.TabIndex = 1;
        button_managehalls.Text = "Manage Halls";
        button_managehalls.UseVisualStyleBackColor = true;
        button_managehalls.Click += HandleManageHalls;
        // 
        // button_manageprojections
        // 
        button_manageprojections.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        button_manageprojections.Location = new Point(137, 308);
        button_manageprojections.Name = "button_manageprojections";
        button_manageprojections.Size = new Size(199, 67);
        button_manageprojections.TabIndex = 2;
        button_manageprojections.Text = "Manage Projections";
        button_manageprojections.UseVisualStyleBackColor = true;
        button_manageprojections.Click += HandleManageProjections;
        // 
        // btn_validate
        // 
        btn_validate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btn_validate.Location = new Point(137, 420);
        btn_validate.Name = "btn_validate";
        btn_validate.Size = new Size(199, 67);
        btn_validate.TabIndex = 3;
        btn_validate.Text = "Validate Code";
        btn_validate.UseVisualStyleBackColor = true;
        btn_validate.Click += HandleScanCode;
        // 
        // AdminDashboardForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(482, 499);
        Controls.Add(btn_validate);
        Controls.Add(button_manageprojections);
        Controls.Add(button_managehalls);
        Controls.Add(button_managemovies);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "AdminDashboardForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "AdminLandingForm";
        Load += AdminDashboardForm_Load;
        ResumeLayout(false);
    }

    #endregion

    private Button button_managemovies;
    private Button button_managehalls;
    private Button button_manageprojections;
    private Button btn_validate;
}