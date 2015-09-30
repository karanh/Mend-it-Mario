namespace Mend_It_Mario
{
    partial class HighScoreForm
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
            this.lstHighscores = new System.Windows.Forms.ListBox();
            this.btnReturnToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstHighscores
            // 
            this.lstHighscores.FormattingEnabled = true;
            this.lstHighscores.Location = new System.Drawing.Point(72, 27);
            this.lstHighscores.Name = "lstHighscores";
            this.lstHighscores.Size = new System.Drawing.Size(158, 160);
            this.lstHighscores.TabIndex = 0;
            // 
            // btnReturnToMenu
            // 
            this.btnReturnToMenu.Location = new System.Drawing.Point(97, 217);
            this.btnReturnToMenu.Name = "btnReturnToMenu";
            this.btnReturnToMenu.Size = new System.Drawing.Size(111, 23);
            this.btnReturnToMenu.TabIndex = 1;
            this.btnReturnToMenu.Text = "Return To Menu";
            this.btnReturnToMenu.UseVisualStyleBackColor = true;
            this.btnReturnToMenu.Click += new System.EventHandler(this.btnReturnToMenu_Click);
            // 
            // HighScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnReturnToMenu);
            this.Controls.Add(this.lstHighscores);
            this.Name = "HighScoreForm";
            this.Text = "HighScoreForm";
            this.Load += new System.EventHandler(this.HighScoreForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstHighscores;
        private System.Windows.Forms.Button btnReturnToMenu;
    }
}