namespace Questionnaire.UI.WinForms
{
    partial class StartUpView
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
            this.iTitleLbl = new System.Windows.Forms.Label();
            this.iActionLbl = new System.Windows.Forms.Label();
            this.iTitlePnl = new System.Windows.Forms.Panel();
            this.iOptionsPnl = new System.Windows.Forms.Panel();
            this.iPlayPnl = new System.Windows.Forms.Panel();
            this.iPlayBtn = new System.Windows.Forms.Button();
            this.iAdminPnl = new System.Windows.Forms.Panel();
            this.iAdminBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iTitlePnl.SuspendLayout();
            this.iOptionsPnl.SuspendLayout();
            this.iPlayPnl.SuspendLayout();
            this.iAdminPnl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iTitleLbl
            // 
            this.iTitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.iTitleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTitleLbl.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTitleLbl.Location = new System.Drawing.Point(0, 0);
            this.iTitleLbl.Name = "iTitleLbl";
            this.iTitleLbl.Size = new System.Drawing.Size(504, 91);
            this.iTitleLbl.TabIndex = 1;
            this.iTitleLbl.Text = "Welcome to Questionnaire";
            this.iTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iActionLbl
            // 
            this.iActionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iActionLbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iActionLbl.Location = new System.Drawing.Point(0, 0);
            this.iActionLbl.Name = "iActionLbl";
            this.iActionLbl.Size = new System.Drawing.Size(504, 63);
            this.iActionLbl.TabIndex = 2;
            this.iActionLbl.Text = "What do you want to do?";
            this.iActionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iTitlePnl
            // 
            this.iTitlePnl.Controls.Add(this.iTitleLbl);
            this.iTitlePnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.iTitlePnl.Location = new System.Drawing.Point(0, 0);
            this.iTitlePnl.Name = "iTitlePnl";
            this.iTitlePnl.Size = new System.Drawing.Size(504, 91);
            this.iTitlePnl.TabIndex = 3;
            // 
            // iOptionsPnl
            // 
            this.iOptionsPnl.Controls.Add(this.iPlayPnl);
            this.iOptionsPnl.Controls.Add(this.iAdminPnl);
            this.iOptionsPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iOptionsPnl.Location = new System.Drawing.Point(0, 154);
            this.iOptionsPnl.Name = "iOptionsPnl";
            this.iOptionsPnl.Size = new System.Drawing.Size(504, 56);
            this.iOptionsPnl.TabIndex = 4;
            // 
            // iPlayPnl
            // 
            this.iPlayPnl.Controls.Add(this.iPlayBtn);
            this.iPlayPnl.Dock = System.Windows.Forms.DockStyle.Right;
            this.iPlayPnl.Location = new System.Drawing.Point(254, 0);
            this.iPlayPnl.Name = "iPlayPnl";
            this.iPlayPnl.Size = new System.Drawing.Size(250, 56);
            this.iPlayPnl.TabIndex = 1;
            // 
            // iPlayBtn
            // 
            this.iPlayBtn.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.iPlayBtn.Location = new System.Drawing.Point(89, 15);
            this.iPlayBtn.Name = "iPlayBtn";
            this.iPlayBtn.Size = new System.Drawing.Size(83, 29);
            this.iPlayBtn.TabIndex = 3;
            this.iPlayBtn.Text = "Play";
            this.iPlayBtn.UseVisualStyleBackColor = true;
            this.iPlayBtn.Click += new System.EventHandler(this.iPlayBtn_Click);
            // 
            // iAdminPnl
            // 
            this.iAdminPnl.Controls.Add(this.iAdminBtn);
            this.iAdminPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.iAdminPnl.Location = new System.Drawing.Point(0, 0);
            this.iAdminPnl.Name = "iAdminPnl";
            this.iAdminPnl.Size = new System.Drawing.Size(250, 56);
            this.iAdminPnl.TabIndex = 0;
            // 
            // iAdminBtn
            // 
            this.iAdminBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iAdminBtn.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.iAdminBtn.Location = new System.Drawing.Point(74, 15);
            this.iAdminBtn.Name = "iAdminBtn";
            this.iAdminBtn.Size = new System.Drawing.Size(119, 29);
            this.iAdminBtn.TabIndex = 2;
            this.iAdminBtn.Text = "Administrate";
            this.iAdminBtn.UseVisualStyleBackColor = true;
            this.iAdminBtn.Click += new System.EventHandler(this.iAdminBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iActionLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 63);
            this.panel1.TabIndex = 5;
            // 
            // StartUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 210);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.iOptionsPnl);
            this.Controls.Add(this.iTitlePnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartUpView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartUpView_FormClosing);
            this.iTitlePnl.ResumeLayout(false);
            this.iOptionsPnl.ResumeLayout(false);
            this.iPlayPnl.ResumeLayout(false);
            this.iAdminPnl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label iTitleLbl;
        private System.Windows.Forms.Label iActionLbl;
        private System.Windows.Forms.Panel iTitlePnl;
        private System.Windows.Forms.Panel iOptionsPnl;
        private System.Windows.Forms.Panel iPlayPnl;
        private System.Windows.Forms.Button iPlayBtn;
        private System.Windows.Forms.Panel iAdminPnl;
        private System.Windows.Forms.Button iAdminBtn;
        private System.Windows.Forms.Panel panel1;
    }
}