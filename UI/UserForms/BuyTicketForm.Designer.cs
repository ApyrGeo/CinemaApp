namespace CinemaApp.UI.UserForms
{
    partial class BuyTicketForm
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
            label1 = new Label();
            cb_projections = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            panelControls = new FlowLayoutPanel();
            label4 = new Label();
            tb_moviename = new TextBox();
            tb_hallname = new TextBox();
            label5 = new Label();
            tb_seatname = new TextBox();
            label6 = new Label();
            tb_price = new TextBox();
            label7 = new Label();
            button_buy = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label1.Location = new Point(88, 9);
            label1.Name = "label1";
            label1.Size = new Size(247, 41);
            label1.TabIndex = 0;
            label1.Text = "Select Projection";
            // 
            // cb_projections
            // 
            cb_projections.FormattingEnabled = true;
            cb_projections.Location = new Point(12, 61);
            cb_projections.Name = "cb_projections";
            cb_projections.Size = new Size(394, 28);
            cb_projections.TabIndex = 1;
            cb_projections.SelectedIndexChanged += cb_projections_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label2.Location = new Point(142, 177);
            label2.Name = "label2";
            label2.Size = new Size(112, 41);
            label2.TabIndex = 2;
            label2.Text = "Details";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label3.Location = new Point(603, 5);
            label3.Name = "label3";
            label3.Size = new Size(166, 41);
            label3.TabIndex = 3;
            label3.Text = "Select Seat";
            // 
            // panelControls
            // 
            panelControls.AutoScroll = true;
            panelControls.Location = new Point(426, 49);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(533, 526);
            panelControls.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(12, 242);
            label4.Name = "label4";
            label4.Size = new Size(82, 28);
            label4.TabIndex = 5;
            label4.Text = "Movie: ";
            // 
            // tb_moviename
            // 
            tb_moviename.Enabled = false;
            tb_moviename.Font = new Font("Segoe UI", 12F);
            tb_moviename.Location = new Point(88, 239);
            tb_moviename.Name = "tb_moviename";
            tb_moviename.Size = new Size(327, 34);
            tb_moviename.TabIndex = 6;
            // 
            // tb_hallname
            // 
            tb_hallname.Enabled = false;
            tb_hallname.Font = new Font("Segoe UI", 12F);
            tb_hallname.Location = new Point(88, 279);
            tb_hallname.Name = "tb_hallname";
            tb_hallname.Size = new Size(327, 34);
            tb_hallname.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(12, 282);
            label5.Name = "label5";
            label5.Size = new Size(61, 28);
            label5.TabIndex = 7;
            label5.Text = "Hall: ";
            // 
            // tb_seatname
            // 
            tb_seatname.Enabled = false;
            tb_seatname.Font = new Font("Segoe UI", 12F);
            tb_seatname.Location = new Point(88, 319);
            tb_seatname.Name = "tb_seatname";
            tb_seatname.Size = new Size(327, 34);
            tb_seatname.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(12, 322);
            label6.Name = "label6";
            label6.Size = new Size(64, 28);
            label6.TabIndex = 9;
            label6.Text = "Seat: ";
            // 
            // tb_price
            // 
            tb_price.Enabled = false;
            tb_price.Font = new Font("Segoe UI", 12F);
            tb_price.Location = new Point(88, 359);
            tb_price.Name = "tb_price";
            tb_price.Size = new Size(327, 34);
            tb_price.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(12, 362);
            label7.Name = "label7";
            label7.Size = new Size(70, 28);
            label7.TabIndex = 11;
            label7.Text = "Price: ";
            // 
            // button_buy
            // 
            button_buy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_buy.Location = new Point(117, 486);
            button_buy.Name = "button_buy";
            button_buy.Size = new Size(164, 39);
            button_buy.TabIndex = 13;
            button_buy.Text = "Buy Ticket";
            button_buy.UseVisualStyleBackColor = true;
            button_buy.Click += HandleBuyTicket;
            // 
            // BuyTicketForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 587);
            Controls.Add(button_buy);
            Controls.Add(tb_price);
            Controls.Add(label7);
            Controls.Add(tb_seatname);
            Controls.Add(label6);
            Controls.Add(tb_hallname);
            Controls.Add(label5);
            Controls.Add(tb_moviename);
            Controls.Add(label4);
            Controls.Add(panelControls);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cb_projections);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BuyTicketForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuyTicketForm";
            Load += BuyTicketForm_Load;
            Shown += BuyTicketForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cb_projections;
        private Label label2;
        private Label label3;
        private FlowLayoutPanel panelControls;
        private Label label4;
        private TextBox tb_moviename;
        private TextBox tb_hallname;
        private Label label5;
        private TextBox tb_seatname;
        private Label label6;
        private TextBox tb_price;
        private Label label7;
        private Button button_buy;
    }
}