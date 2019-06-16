namespace COMPE_361_Final_Project
{
    partial class Form1
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
            this.currentRoomLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.entryRoomPortalTimer = new System.Windows.Forms.Timer(this.components);
            this.aboutTimer = new System.Windows.Forms.Timer(this.components);
            this.portalRotateStart = new System.Windows.Forms.Timer(this.components);
            this.portalRotateEnd = new System.Windows.Forms.Timer(this.components);
            this.endGameTImer = new System.Windows.Forms.Timer(this.components);
            this.inventoryLabel = new System.Windows.Forms.Label();
            this.iterationTimer = new System.Windows.Forms.Timer(this.components);
            this.spritePictureBox = new System.Windows.Forms.PictureBox();
            this.cheatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // currentRoomLabel
            // 
            this.currentRoomLabel.AutoSize = true;
            this.currentRoomLabel.Font = new System.Drawing.Font("Rick_and_Morty", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRoomLabel.Location = new System.Drawing.Point(1028, 105);
            this.currentRoomLabel.Name = "currentRoomLabel";
            this.currentRoomLabel.Size = new System.Drawing.Size(179, 60);
            this.currentRoomLabel.TabIndex = 4;
            this.currentRoomLabel.Text = "Room: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem,
            this.cheatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1470, 42);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 38);
            this.toolStripMenuItem1.Text = "File";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(165, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(165, 38);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem1,
            this.aboutToolStripMenuItem2});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 38);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem1
            // 
            this.instructionsToolStripMenuItem1.Name = "instructionsToolStripMenuItem1";
            this.instructionsToolStripMenuItem1.Size = new System.Drawing.Size(237, 38);
            this.instructionsToolStripMenuItem1.Text = "Instructions";
            this.instructionsToolStripMenuItem1.Click += new System.EventHandler(this.instructionsToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(237, 38);
            this.aboutToolStripMenuItem2.Text = "About";
            this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 903);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1470, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // entryRoomPortalTimer
            // 
            this.entryRoomPortalTimer.Interval = 1000;
            this.entryRoomPortalTimer.Tick += new System.EventHandler(this.entryRoomPortalTimer_Tick);
            // 
            // aboutTimer
            // 
            this.aboutTimer.Interval = 5000;
            this.aboutTimer.Tick += new System.EventHandler(this.aboutTimer_Tick);
            // 
            // portalRotateStart
            // 
            this.portalRotateStart.Interval = 200;
            this.portalRotateStart.Tick += new System.EventHandler(this.portalRotateStart_Tick);
            // 
            // endGameTImer
            // 
            this.endGameTImer.Interval = 3000;
            this.endGameTImer.Tick += new System.EventHandler(this.endGameTImer_Tick);
            // 
            // inventoryLabel
            // 
            this.inventoryLabel.AutoSize = true;
            this.inventoryLabel.Font = new System.Drawing.Font("Rick_and_Morty", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryLabel.Location = new System.Drawing.Point(1028, 762);
            this.inventoryLabel.Name = "inventoryLabel";
            this.inventoryLabel.Size = new System.Drawing.Size(206, 60);
            this.inventoryLabel.TabIndex = 12;
            this.inventoryLabel.Text = "Pieces: ";
            // 
            // iterationTimer
            // 
            this.iterationTimer.Interval = 2000;
            this.iterationTimer.Tick += new System.EventHandler(this.iterationTimer_Tick);
            // 
            // spritePictureBox
            // 
            this.spritePictureBox.Image = global::COMPE_361_Final_Project.Properties.Resources.mortimerright;
            this.spritePictureBox.Location = new System.Drawing.Point(561, 531);
            this.spritePictureBox.Name = "spritePictureBox";
            this.spritePictureBox.Size = new System.Drawing.Size(47, 123);
            this.spritePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spritePictureBox.TabIndex = 6;
            this.spritePictureBox.TabStop = false;
            // 
            // cheatToolStripMenuItem
            // 
            this.cheatToolStripMenuItem.Name = "cheatToolStripMenuItem";
            this.cheatToolStripMenuItem.Size = new System.Drawing.Size(89, 38);
            this.cheatToolStripMenuItem.Text = "Cheat";
            this.cheatToolStripMenuItem.Click += new System.EventHandler(this.cheatToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1470, 925);
            this.Controls.Add(this.inventoryLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.spritePictureBox);
            this.Controls.Add(this.currentRoomLabel);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label currentRoomLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox spritePictureBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.Timer entryRoomPortalTimer;
        private System.Windows.Forms.Timer aboutTimer;
        private System.Windows.Forms.Timer portalRotateStart;
        private System.Windows.Forms.Timer portalRotateEnd;
        private System.Windows.Forms.Timer endGameTImer;
        private System.Windows.Forms.Label inventoryLabel;
        private System.Windows.Forms.Timer iterationTimer;
        private System.Windows.Forms.ToolStripMenuItem cheatToolStripMenuItem;
    }
}

