namespace CinemaApp.UI.Components
{
    partial class TicketCardControl
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
            label_moviename = new Label();
            label_hallname = new Label();
            label_seatname = new Label();
            label_date = new Label();
            SuspendLayout();
            // 
            // label_moviename
            // 
            label_moviename.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label_moviename.AutoSize = true;
            label_moviename.Font = new Font("Century Schoolbook", 16.2F, FontStyle.Italic);
            label_moviename.Location = new Point(16, 13);
            label_moviename.Name = "label_moviename";
            label_moviename.Size = new Size(93, 34);
            label_moviename.TabIndex = 0;
            label_moviename.Text = "label1";
            // 
            // label_hallname
            // 
            label_hallname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label_hallname.AutoSize = true;
            label_hallname.Font = new Font("Century Schoolbook", 16.2F, FontStyle.Italic);
            label_hallname.Location = new Point(16, 65);
            label_hallname.Name = "label_hallname";
            label_hallname.Size = new Size(93, 34);
            label_hallname.TabIndex = 1;
            label_hallname.Text = "label1";
            // 
            // label_seatname
            // 
            label_seatname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label_seatname.AutoSize = true;
            label_seatname.Font = new Font("Century Schoolbook", 16.2F, FontStyle.Italic);
            label_seatname.Location = new Point(134, 65);
            label_seatname.Name = "label_seatname";
            label_seatname.Size = new Size(93, 34);
            label_seatname.TabIndex = 2;
            label_seatname.Text = "label1";
            // 
            // label_date
            // 
            label_date.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label_date.AutoSize = true;
            label_date.Font = new Font("Century Schoolbook", 16.2F, FontStyle.Italic);
            label_date.Location = new Point(418, 13);
            label_date.Name = "label_date";
            label_date.Size = new Size(93, 34);
            label_date.TabIndex = 3;
            label_date.Text = "label1";
            // 
            // TicketCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label_date);
            Controls.Add(label_seatname);
            Controls.Add(label_hallname);
            Controls.Add(label_moviename);
            Name = "TicketCardControl";
            Size = new Size(514, 100);
            Load += TicketCardControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_moviename;
        private Label label_hallname;
        private Label label_seatname;
        private Label label_date;
    }
}
