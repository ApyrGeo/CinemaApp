namespace CinemaApp.UI.UserForms
{
    partial class ViewMoviesForm
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
            panelComponents = new FlowLayoutPanel();
            panel1 = new Panel();
            button1 = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelComponents
            // 
            panelComponents.Dock = DockStyle.Bottom;
            panelComponents.Location = new Point(0, 67);
            panelComponents.Name = "panelComponents";
            panelComponents.Size = new Size(1098, 461);
            panelComponents.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1098, 528);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(735, 31);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label1.Location = new Point(413, 9);
            label1.Name = "label1";
            label1.Size = new Size(262, 41);
            label1.TabIndex = 0;
            label1.Text = "Available movies";
            // 
            // ViewMoviesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 528);
            Controls.Add(panelComponents);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ViewMoviesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewMoviesForm";
            Load += ViewMoviesForm_Load;
            Shown += ViewMoviesForm_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel panelComponents;
        private Panel panel1;
        private Label label1;
        private Button button1;
    }
}