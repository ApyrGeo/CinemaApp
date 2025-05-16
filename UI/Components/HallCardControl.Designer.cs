namespace CinemaApp.UI.Components
{
    partial class HallCardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_hall_cap = new Label();
            lbl_hall_name = new Label();
            SuspendLayout();
            // 
            // lbl_hall_cap
            // 
            lbl_hall_cap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_hall_cap.AutoSize = true;
            lbl_hall_cap.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            lbl_hall_cap.Location = new Point(292, 41);
            lbl_hall_cap.Name = "lbl_hall_cap";
            lbl_hall_cap.Size = new Size(92, 25);
            lbl_hall_cap.TabIndex = 5;
            lbl_hall_cap.Text = "sdasdas";
            // 
            // lbl_hall_name
            // 
            lbl_hall_name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_hall_name.AutoSize = true;
            lbl_hall_name.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            lbl_hall_name.Location = new Point(32, 41);
            lbl_hall_name.Name = "lbl_hall_name";
            lbl_hall_name.Size = new Size(92, 25);
            lbl_hall_name.TabIndex = 4;
            lbl_hall_name.Text = "sdasdas";
            // 
            // HallCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbl_hall_cap);
            Controls.Add(lbl_hall_name);
            Name = "HallCardControl";
            Size = new Size(419, 104);
            Load += HallCardControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_hall_cap;
        private Label lbl_hall_name;
    }
}
