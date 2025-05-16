namespace CinemaApp.UI.AdminForms
{
    partial class ManageMoviesForm
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
            label3 = new Label();
            tb_mv_name = new TextBox();
            label2 = new Label();
            nrud_duration = new NumericUpDown();
            nrud_price = new NumericUpDown();
            label4 = new Label();
            btd_add_movie = new Button();
            ((System.ComponentModel.ISupportInitialize)nrud_duration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nrud_price).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(226, 9);
            label1.Name = "label1";
            label1.Size = new Size(173, 41);
            label1.TabIndex = 0;
            label1.Text = "Add Movie";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F);
            label3.Location = new Point(22, 108);
            label3.Name = "label3";
            label3.Size = new Size(175, 38);
            label3.TabIndex = 1;
            label3.Text = "Movie Name";
            // 
            // tb_mv_name
            // 
            tb_mv_name.Font = new Font("Segoe UI", 16.2F);
            tb_mv_name.Location = new Point(244, 105);
            tb_mv_name.Name = "tb_mv_name";
            tb_mv_name.Size = new Size(359, 43);
            tb_mv_name.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F);
            label2.Location = new Point(22, 179);
            label2.Name = "label2";
            label2.Size = new Size(125, 38);
            label2.TabIndex = 3;
            label2.Text = "Duration";
            // 
            // nrud_duration
            // 
            nrud_duration.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            nrud_duration.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            nrud_duration.Location = new Point(244, 179);
            nrud_duration.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            nrud_duration.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            nrud_duration.Name = "nrud_duration";
            nrud_duration.Size = new Size(359, 38);
            nrud_duration.TabIndex = 5;
            nrud_duration.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // nrud_price
            // 
            nrud_price.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            nrud_price.Location = new Point(244, 249);
            nrud_price.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nrud_price.Name = "nrud_price";
            nrud_price.Size = new Size(359, 38);
            nrud_price.TabIndex = 7;
            nrud_price.ThousandsSeparator = true;
            nrud_price.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F);
            label4.Location = new Point(22, 249);
            label4.Name = "label4";
            label4.Size = new Size(78, 38);
            label4.TabIndex = 6;
            label4.Text = "Price";
            // 
            // btd_add_movie
            // 
            btd_add_movie.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btd_add_movie.Location = new Point(207, 316);
            btd_add_movie.Name = "btd_add_movie";
            btd_add_movie.Size = new Size(212, 49);
            btd_add_movie.TabIndex = 8;
            btd_add_movie.Text = "Add Movie";
            btd_add_movie.UseVisualStyleBackColor = true;
            btd_add_movie.Click += HandleAddMovie;
            // 
            // ManageMoviesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 377);
            Controls.Add(btd_add_movie);
            Controls.Add(nrud_price);
            Controls.Add(label4);
            Controls.Add(nrud_duration);
            Controls.Add(label2);
            Controls.Add(tb_mv_name);
            Controls.Add(label3);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ManageMoviesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageMoviesForm";
            Load += ManageMoviesForm_Load;
            ((System.ComponentModel.ISupportInitialize)nrud_duration).EndInit();
            ((System.ComponentModel.ISupportInitialize)nrud_price).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox tb_mv_name;
        private Label label2;
        private NumericUpDown nrud_duration;
        private NumericUpDown nrud_price;
        private Label label4;
        private Button btd_add_movie;
    }
}