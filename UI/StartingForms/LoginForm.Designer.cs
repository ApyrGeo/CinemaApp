namespace CinemaApp.UI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            label2 = new Label();
            tb_uname = new TextBox();
            tb_pass = new TextBox();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // tb_uname
            // 
            resources.ApplyResources(tb_uname, "tb_uname");
            tb_uname.Name = "tb_uname";
            // 
            // tb_pass
            // 
            resources.ApplyResources(tb_pass, "tb_pass");
            tb_pass.Name = "tb_pass";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Cursor = Cursors.Hand;
            label4.ForeColor = Color.Teal;
            label4.Name = "label4";
            label4.Click += label4_Click;
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(tb_pass);
            Controls.Add(label3);
            Controls.Add(tb_uname);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_uname;
        private TextBox tb_pass;
        private Label label3;
        private Button button1;
        private Label label4;
    }
}