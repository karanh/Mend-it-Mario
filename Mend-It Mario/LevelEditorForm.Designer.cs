namespace Mend_It_Mario
{
    partial class LevelEditorForm
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
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblNumWalls = new System.Windows.Forms.Label();
            this.lblNumMushrooms = new System.Windows.Forms.Label();
            this.lblNumBirds = new System.Windows.Forms.Label();
            this.lblBirdSpeed = new System.Windows.Forms.Label();
            this.txtDifficulty = new System.Windows.Forms.TextBox();
            this.txtNumWalls = new System.Windows.Forms.TextBox();
            this.txtNumMushrooms = new System.Windows.Forms.TextBox();
            this.txtNumBirds = new System.Windows.Forms.TextBox();
            this.txtBirdSpeed = new System.Windows.Forms.TextBox();
            this.lblLevelEditorName = new System.Windows.Forms.Label();
            this.lblDisplayMessage = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulty.Location = new System.Drawing.Point(17, 120);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(67, 18);
            this.lblDifficulty.TabIndex = 0;
            this.lblDifficulty.Text = "Difficulty:";
            // 
            // lblNumWalls
            // 
            this.lblNumWalls.AutoSize = true;
            this.lblNumWalls.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumWalls.Location = new System.Drawing.Point(17, 150);
            this.lblNumWalls.Name = "lblNumWalls";
            this.lblNumWalls.Size = new System.Drawing.Size(121, 18);
            this.lblNumWalls.TabIndex = 1;
            this.lblNumWalls.Text = "Number of Walls:";
            // 
            // lblNumMushrooms
            // 
            this.lblNumMushrooms.AutoSize = true;
            this.lblNumMushrooms.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumMushrooms.Location = new System.Drawing.Point(17, 182);
            this.lblNumMushrooms.Name = "lblNumMushrooms";
            this.lblNumMushrooms.Size = new System.Drawing.Size(164, 18);
            this.lblNumMushrooms.TabIndex = 2;
            this.lblNumMushrooms.Text = "Number of Mushrooms:";
            // 
            // lblNumBirds
            // 
            this.lblNumBirds.AutoSize = true;
            this.lblNumBirds.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumBirds.Location = new System.Drawing.Point(17, 212);
            this.lblNumBirds.Name = "lblNumBirds";
            this.lblNumBirds.Size = new System.Drawing.Size(119, 18);
            this.lblNumBirds.TabIndex = 3;
            this.lblNumBirds.Text = "Number of Birds:";
            // 
            // lblBirdSpeed
            // 
            this.lblBirdSpeed.AutoSize = true;
            this.lblBirdSpeed.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirdSpeed.Location = new System.Drawing.Point(17, 247);
            this.lblBirdSpeed.Name = "lblBirdSpeed";
            this.lblBirdSpeed.Size = new System.Drawing.Size(82, 18);
            this.lblBirdSpeed.TabIndex = 4;
            this.lblBirdSpeed.Text = "Bird Speed:";
            // 
            // txtDifficulty
            // 
            this.txtDifficulty.Location = new System.Drawing.Point(187, 118);
            this.txtDifficulty.Name = "txtDifficulty";
            this.txtDifficulty.Size = new System.Drawing.Size(137, 20);
            this.txtDifficulty.TabIndex = 5;
            this.txtDifficulty.TextChanged += new System.EventHandler(this.txtDifficulty_TextChanged_1);
            // 
            // txtNumWalls
            // 
            this.txtNumWalls.Location = new System.Drawing.Point(187, 148);
            this.txtNumWalls.Name = "txtNumWalls";
            this.txtNumWalls.Size = new System.Drawing.Size(137, 20);
            this.txtNumWalls.TabIndex = 6;
            this.txtNumWalls.TextChanged += new System.EventHandler(this.txtNumWalls_TextChanged_1);
            // 
            // txtNumMushrooms
            // 
            this.txtNumMushrooms.Location = new System.Drawing.Point(187, 180);
            this.txtNumMushrooms.Name = "txtNumMushrooms";
            this.txtNumMushrooms.Size = new System.Drawing.Size(137, 20);
            this.txtNumMushrooms.TabIndex = 7;
            this.txtNumMushrooms.TextChanged += new System.EventHandler(this.txtNumMushrooms_TextChanged_1);
            // 
            // txtNumBirds
            // 
            this.txtNumBirds.Location = new System.Drawing.Point(187, 210);
            this.txtNumBirds.Name = "txtNumBirds";
            this.txtNumBirds.Size = new System.Drawing.Size(137, 20);
            this.txtNumBirds.TabIndex = 8;
            this.txtNumBirds.TextChanged += new System.EventHandler(this.txtNumBirds_TextChanged_1);
            // 
            // txtBirdSpeed
            // 
            this.txtBirdSpeed.Location = new System.Drawing.Point(187, 247);
            this.txtBirdSpeed.Name = "txtBirdSpeed";
            this.txtBirdSpeed.Size = new System.Drawing.Size(137, 20);
            this.txtBirdSpeed.TabIndex = 9;
            this.txtBirdSpeed.TextChanged += new System.EventHandler(this.txtBirdSpeed_TextChanged_1);
            // 
            // lblLevelEditorName
            // 
            this.lblLevelEditorName.AutoSize = true;
            this.lblLevelEditorName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelEditorName.ForeColor = System.Drawing.Color.Red;
            this.lblLevelEditorName.Location = new System.Drawing.Point(182, 28);
            this.lblLevelEditorName.Name = "lblLevelEditorName";
            this.lblLevelEditorName.Size = new System.Drawing.Size(155, 29);
            this.lblLevelEditorName.TabIndex = 10;
            this.lblLevelEditorName.Text = "Level Editor";
            // 
            // lblDisplayMessage
            // 
            this.lblDisplayMessage.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayMessage.ForeColor = System.Drawing.Color.Red;
            this.lblDisplayMessage.Location = new System.Drawing.Point(330, 113);
            this.lblDisplayMessage.Name = "lblDisplayMessage";
            this.lblDisplayMessage.Size = new System.Drawing.Size(273, 208);
            this.lblDisplayMessage.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(187, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 38);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(12, 6);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(126, 51);
            this.btnReturn.TabIndex = 13;
            this.btnReturn.Text = "Return to Menu";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Visible = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click_1);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Location = new System.Drawing.Point(225, 338);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMessage.TabIndex = 14;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(187, 83);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(137, 20);
            this.txtFileName.TabIndex = 15;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(17, 83);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(77, 18);
            this.lblFileName.TabIndex = 16;
            this.lblFileName.Text = "File Name:";
            // 
            // LevelEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 360);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDisplayMessage);
            this.Controls.Add(this.lblLevelEditorName);
            this.Controls.Add(this.txtBirdSpeed);
            this.Controls.Add(this.txtNumBirds);
            this.Controls.Add(this.txtNumMushrooms);
            this.Controls.Add(this.txtNumWalls);
            this.Controls.Add(this.txtDifficulty);
            this.Controls.Add(this.lblBirdSpeed);
            this.Controls.Add(this.lblNumBirds);
            this.Controls.Add(this.lblNumMushrooms);
            this.Controls.Add(this.lblNumWalls);
            this.Controls.Add(this.lblDifficulty);
            this.Name = "LevelEditorForm";
            this.Text = "LevelEditorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblNumWalls;
        private System.Windows.Forms.Label lblNumMushrooms;
        private System.Windows.Forms.Label lblNumBirds;
        private System.Windows.Forms.Label lblBirdSpeed;
        private System.Windows.Forms.TextBox txtDifficulty;
        private System.Windows.Forms.TextBox txtNumWalls;
        private System.Windows.Forms.TextBox txtNumMushrooms;
        private System.Windows.Forms.TextBox txtNumBirds;
        private System.Windows.Forms.TextBox txtBirdSpeed;
        private System.Windows.Forms.Label lblLevelEditorName;
        private System.Windows.Forms.Label lblDisplayMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
    }
}