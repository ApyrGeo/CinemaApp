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
        panelContainer = new FlowLayoutPanel();
        label1 = new Label();
        SuspendLayout();
        // 
        // btn_login
        // 
        btn_login.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        btn_login.Font = new Font("Century Schoolbook", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
        btn_login.Location = new Point(339, 520);
        btn_login.Name = "btn_login";
        btn_login.Size = new Size(137, 38);
        btn_login.TabIndex = 0;
        btn_login.Text = "Login";
        btn_login.UseVisualStyleBackColor = true;
        btn_login.Click += btn_login_Click;
        // 
        // panelContainer
        // 
        panelContainer.AutoScroll = true;
        panelContainer.FlowDirection = FlowDirection.TopDown;
        panelContainer.Location = new Point(12, 54);
        panelContainer.Name = "panelContainer";
        panelContainer.Size = new Size(822, 425);
        panelContainer.TabIndex = 1;
        panelContainer.WrapContents = false;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Font = new Font("Century Schoolbook", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        label1.Location = new Point(224, 9);
        label1.Name = "label1";
        label1.Size = new Size(369, 33);
        label1.TabIndex = 2;
        label1.Text = "Current Running Movies";
        // 
        // LandingForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(846, 570);
        Controls.Add(label1);
        Controls.Add(panelContainer);
        Controls.Add(btn_login);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "LandingForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LandingForm";
        Load += LandingForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btn_login;
    private FlowLayoutPanel panelContainer;
    private Label label1;
}