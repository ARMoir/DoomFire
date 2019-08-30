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
            this.Stage = new System.Windows.Forms.PictureBox();
            this.Ticker = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Stage)).BeginInit();
            this.SuspendLayout();
            // 
            // Stage
            // 
            this.Stage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Stage.Location = new System.Drawing.Point(12, 12);
            this.Stage.Name = "Stage";
            this.Stage.Size = new System.Drawing.Size(504, 552);
            this.Stage.TabIndex = 0;
            this.Stage.TabStop = false;
            // 
            // Ticker
            // 
            this.Ticker.Enabled = true;
            this.Ticker.Interval = 27;
            this.Ticker.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // DoomFire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 576);
            this.Controls.Add(this.Stage);
            this.Name = "DoomFire";
            this.Text = "DoomFire";
            ((System.ComponentModel.ISupportInitialize)(this.Stage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Stage;
        private System.Windows.Forms.Timer Ticker;
    }
}

