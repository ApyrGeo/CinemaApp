namespace CinemaApp.UI.AdminForms
{
    partial class ManageHallsForm
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
            label1 = new Label();
            btn_add_hall = new Button();
            SuspendLayout();
            // 
            // panelComponents
            // 
            panelComponents.Dock = DockStyle.Bottom;
            panelComponents.Location = new Point(0, 95);
            panelComponents.Name = "panelComponents";
            panelComponents.Size = new Size(816, 415);
            panelComponents.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(312, 9);
            label1.Name = "label1";
            label1.Size = new Size(202, 41);
            label1.TabIndex = 1;
            label1.Text = "ManageHalls";
            // 
            // btn_add_hall
            // 
            btn_add_hall.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_add_hall.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btn_add_hall.Location = new Point(689, 9);
            btn_add_hall.Name = "btn_add_hall";
            btn_add_hall.Size = new Size(115, 67);
            btn_add_hall.TabIndex = 2;
            btn_add_hall.Text = "Add new hall";
            btn_add_hall.UseVisualStyleBackColor = true;
            btn_add_hall.Click += HandleAddHall;
            // 
            // ManageHallsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 510);
            Controls.Add(btn_add_hall);
            Controls.Add(label1);
            Controls.Add(panelComponents);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ManageHallsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageHallsForm";
            Load += ManageHallsForm_Load;
            Shown += ManageHallsForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel panelComponents;
        private Label label1;
        private Button btn_add_hall;
    }
}