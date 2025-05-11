namespace CinemaApp.UI;

partial class RegisterForm
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
        button1 = new Button();
        tb_pass = new TextBox();
        label3 = new Label();
        tb_uname = new TextBox();
        label2 = new Label();
        label1 = new Label();
        tb_cpass = new TextBox();
        label4 = new Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
        button1.ImeMode = ImeMode.NoControl;
        button1.Location = new Point(150, 323);
        button1.Margin = new Padding(4, 3, 4, 3);
        button1.Name = "button1";
        button1.Size = new Size(186, 64);
        button1.TabIndex = 13;
        button1.Text = "Register";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // tb_pass
        // 
        tb_pass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        tb_pass.Font = new Font("Century Gothic", 12F);
        tb_pass.Location = new Point(196, 188);
        tb_pass.Margin = new Padding(4, 3, 4, 3);
        tb_pass.Name = "tb_pass";
        tb_pass.Size = new Size(256, 32);
        tb_pass.TabIndex = 10;
        // 
        // label3
        // 
        label3.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
        label3.ImeMode = ImeMode.NoControl;
        label3.Location = new Point(30, 191);
        label3.Margin = new Padding(4, 0, 4, 0);
        label3.Name = "label3";
        label3.Size = new Size(130, 26);
        label3.TabIndex = 9;
        label3.Text = "Password";
        // 
        // tb_uname
        // 
        tb_uname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        tb_uname.Font = new Font("Century Gothic", 12F);
        tb_uname.Location = new Point(196, 125);
        tb_uname.Margin = new Padding(4, 3, 4, 3);
        tb_uname.Name = "tb_uname";
        tb_uname.Size = new Size(256, 32);
        tb_uname.TabIndex = 8;
        // 
        // label2
        // 
        label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
        label2.ImeMode = ImeMode.NoControl;
        label2.Location = new Point(30, 128);
        label2.Margin = new Padding(4, 0, 4, 0);
        label2.Name = "label2";
        label2.Size = new Size(130, 26);
        label2.TabIndex = 7;
        label2.Text = "Username";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 18F);
        label1.ImeMode = ImeMode.NoControl;
        label1.Location = new Point(171, 9);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(125, 41);
        label1.TabIndex = 6;
        label1.Text = "Register";
        // 
        // tb_cpass
        // 
        tb_cpass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        tb_cpass.Font = new Font("Century Gothic", 12F);
        tb_cpass.Location = new Point(196, 264);
        tb_cpass.Margin = new Padding(4, 3, 4, 3);
        tb_cpass.Name = "tb_cpass";
        tb_cpass.Size = new Size(256, 32);
        tb_cpass.TabIndex = 11;
        // 
        // label4
        // 
        label4.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
        label4.ImeMode = ImeMode.NoControl;
        label4.Location = new Point(30, 249);
        label4.Margin = new Padding(4, 0, 4, 0);
        label4.Name = "label4";
        label4.Size = new Size(130, 47);
        label4.TabIndex = 12;
        label4.Text = "Confirm Password";
        // 
        // RegisterForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(482, 403);
        Controls.Add(tb_cpass);
        Controls.Add(label4);
        Controls.Add(button1);
        Controls.Add(tb_pass);
        Controls.Add(label3);
        Controls.Add(tb_uname);
        Controls.Add(label2);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "RegisterForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "RegisterForm";
        Load += RegisterForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private TextBox tb_pass;
    private Label label3;
    private TextBox tb_uname;
    private Label label2;
    private Label label1;
    private TextBox tb_cpass;
    private Label label4;
}