namespace CinemaApp.UI.Components
{
    partial class MovieCardControl
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
            labelMovieName = new Label();
            labelMovieDuration = new Label();
            labelMoviePrice = new Label();
            SuspendLayout();
            // 
            // labelMovieName
            // 
            labelMovieName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelMovieName.AutoSize = true;
            labelMovieName.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            labelMovieName.Location = new Point(20, 26);
            labelMovieName.Name = "labelMovieName";
            labelMovieName.Size = new Size(22, 25);
            labelMovieName.TabIndex = 0;
            labelMovieName.Text = "s";
            // 
            // labelMovieDuration
            // 
            labelMovieDuration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            labelMovieDuration.AutoSize = true;
            labelMovieDuration.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            labelMovieDuration.Location = new Point(291, 26);
            labelMovieDuration.Name = "labelMovieDuration";
            labelMovieDuration.Size = new Size(22, 25);
            labelMovieDuration.TabIndex = 1;
            labelMovieDuration.Text = "s";
            // 
            // labelMoviePrice
            // 
            labelMoviePrice.AutoSize = true;
            labelMoviePrice.Font = new Font("Century Schoolbook", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelMoviePrice.Location = new Point(291, 62);
            labelMoviePrice.Name = "labelMoviePrice";
            labelMoviePrice.Size = new Size(0, 21);
            labelMoviePrice.TabIndex = 2;
            // 
            // MovieCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGoldenrodYellow;
            Controls.Add(labelMoviePrice);
            Controls.Add(labelMovieDuration);
            Controls.Add(labelMovieName);
            Name = "MovieCardControl";
            Size = new Size(369, 93);
            Load += MovieCardControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMovieName;
        private Label labelMovieDuration;
        private Label labelMoviePrice;
    }
}
