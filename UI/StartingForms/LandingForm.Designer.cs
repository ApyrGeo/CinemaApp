namespace CinemaApp.UI;

partial class LandingForm
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
        btn_login = new Button();
        SuspendLayout();
        // 
        // btn_login
        // 
        btn_login.Location = new Point(694, 12);
        btn_login.Name = "btn_login";
        btn_login.Size = new Size(94, 29);
        btn_login.TabIndex = 0;
        btn_login.Text = "Login";
        btn_login.UseVisualStyleBackColor = true;
        btn_login.Click += btn_login_Click;
        // 
        // LandingForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btn_login);
        Name = "LandingForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LandingForm";
        Load += LandingForm_Load;
        ResumeLayout(false);
    }

    #endregion

    private Button btn_login;
}