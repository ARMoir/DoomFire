namespace DoomFire
{
    partial class DoomFire
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
            this.components = new System.ComponentModel.Container();
            this.STAGE = new System.Windows.Forms.PictureBox();
            this.TICKER = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.STAGE)).BeginInit();
            this.SuspendLayout();
            // 
            // STAGE
            // 
            this.STAGE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.STAGE.Location = new System.Drawing.Point(16, 15);
            this.STAGE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.STAGE.Name = "STAGE";
            this.STAGE.Size = new System.Drawing.Size(672, 679);
            this.STAGE.TabIndex = 0;
            this.STAGE.TabStop = false;
            // 
            // TICKER
            // 
            this.TICKER.Enabled = true;
            this.TICKER.Interval = 27;
            this.TICKER.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // DoomFire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 709);
            this.Controls.Add(this.STAGE);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DoomFire";
            this.Text = "DoomFire";
            ((System.ComponentModel.ISupportInitialize)(this.STAGE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox STAGE;
        private System.Windows.Forms.Timer TICKER;
    }
}

