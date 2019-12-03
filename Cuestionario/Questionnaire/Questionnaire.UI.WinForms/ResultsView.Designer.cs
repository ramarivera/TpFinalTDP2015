namespace Questionnaire.UI.WinForms
{
    partial class ResultsView
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
            this.iHeaderPnl = new System.Windows.Forms.Panel();
            this.iTimePnl = new System.Windows.Forms.Panel();
            this.iTimeLbl = new System.Windows.Forms.Label();
            this.iScorePnl = new System.Windows.Forms.Panel();
            this.iScoreLbl = new System.Windows.Forms.Label();
            this.iTitlePnl = new System.Windows.Forms.Panel();
            this.iTitleLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iRestartBtn = new System.Windows.Forms.Button();
            this.iExitBtn = new System.Windows.Forms.Button();
            this.iResultsPnl = new System.Windows.Forms.Panel();
            this.iDataGridPnl = new System.Windows.Forms.Panel();
            this.iResultsDGV = new System.Windows.Forms.DataGridView();
            this.iResultsTitlePnl = new System.Windows.Forms.Panel();
            this.iBestScoresLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iHeaderPnl.SuspendLayout();
            this.iTimePnl.SuspendLayout();
            this.iScorePnl.SuspendLayout();
            this.iTitlePnl.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.iResultsPnl.SuspendLayout();
            this.iDataGridPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iResultsDGV)).BeginInit();
            this.iResultsTitlePnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // iHeaderPnl
            // 
            this.iHeaderPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.iHeaderPnl.Controls.Add(this.iTimePnl);
            this.iHeaderPnl.Controls.Add(this.iScorePnl);
            this.iHeaderPnl.Controls.Add(this.iTitlePnl);
            this.iHeaderPnl.Location = new System.Drawing.Point(0, 0);
            this.iHeaderPnl.Name = "iHeaderPnl";
            this.iHeaderPnl.Size = new System.Drawing.Size(784, 165);
            this.iHeaderPnl.TabIndex = 1;
            // 
            // iTimePnl
            // 
            this.iTimePnl.Controls.Add(this.iTimeLbl);
            this.iTimePnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iTimePnl.Location = new System.Drawing.Point(0, 109);
            this.iTimePnl.Name = "iTimePnl";
            this.iTimePnl.Size = new System.Drawing.Size(784, 56);
            this.iTimePnl.TabIndex = 5;
            // 
            // iTimeLbl
            // 
            this.iTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTimeLbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTimeLbl.Location = new System.Drawing.Point(0, 0);
            this.iTimeLbl.Name = "iTimeLbl";
            this.iTimeLbl.Size = new System.Drawing.Size(784, 56);
            this.iTimeLbl.TabIndex = 2;
            this.iTimeLbl.Text = "Game time: 0 seconds";
            this.iTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iScorePnl
            // 
            this.iScorePnl.Controls.Add(this.iScoreLbl);
            this.iScorePnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.iScorePnl.Location = new System.Drawing.Point(0, 68);
            this.iScorePnl.Name = "iScorePnl";
            this.iScorePnl.Size = new System.Drawing.Size(784, 38);
            this.iScorePnl.TabIndex = 4;
            // 
            // iScoreLbl
            // 
            this.iScoreLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iScoreLbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iScoreLbl.Location = new System.Drawing.Point(0, 0);
            this.iScoreLbl.Name = "iScoreLbl";
            this.iScoreLbl.Size = new System.Drawing.Size(784, 38);
            this.iScoreLbl.TabIndex = 1;
            this.iScoreLbl.Text = "Score: 0 points";
            this.iScoreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iTitlePnl
            // 
            this.iTitlePnl.Controls.Add(this.iTitleLbl);
            this.iTitlePnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.iTitlePnl.Location = new System.Drawing.Point(0, 0);
            this.iTitlePnl.Name = "iTitlePnl";
            this.iTitlePnl.Size = new System.Drawing.Size(784, 68);
            this.iTitlePnl.TabIndex = 3;
            // 
            // iTitleLbl
            // 
            this.iTitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.iTitleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTitleLbl.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTitleLbl.Location = new System.Drawing.Point(0, 0);
            this.iTitleLbl.Name = "iTitleLbl";
            this.iTitleLbl.Size = new System.Drawing.Size(784, 68);
            this.iTitleLbl.TabIndex = 0;
            this.iTitleLbl.Text = "Thanks for playing!";
            this.iTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.iResultsPnl);
            this.panel3.Location = new System.Drawing.Point(0, 155);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 351);
            this.panel3.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel5.Controls.Add(this.iRestartBtn);
            this.panel5.Controls.Add(this.iExitBtn);
            this.panel5.Location = new System.Drawing.Point(0, 294);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(784, 57);
            this.panel5.TabIndex = 4;
            // 
            // iRestartBtn
            // 
            this.iRestartBtn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iRestartBtn.Location = new System.Drawing.Point(156, 14);
            this.iRestartBtn.Name = "iRestartBtn";
            this.iRestartBtn.Size = new System.Drawing.Size(83, 29);
            this.iRestartBtn.TabIndex = 1;
            this.iRestartBtn.Text = "Restart";
            this.iRestartBtn.UseVisualStyleBackColor = true;
            this.iRestartBtn.Click += new System.EventHandler(this.iRestartBtn_Click);
            // 
            // iExitBtn
            // 
            this.iExitBtn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iExitBtn.Location = new System.Drawing.Point(563, 17);
            this.iExitBtn.Name = "iExitBtn";
            this.iExitBtn.Size = new System.Drawing.Size(83, 29);
            this.iExitBtn.TabIndex = 0;
            this.iExitBtn.Text = "Exit";
            this.iExitBtn.UseVisualStyleBackColor = true;
            this.iExitBtn.Click += new System.EventHandler(this.iExitBtn_Click);
            // 
            // iResultsPnl
            // 
            this.iResultsPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.iResultsPnl.Controls.Add(this.iDataGridPnl);
            this.iResultsPnl.Controls.Add(this.iResultsTitlePnl);
            this.iResultsPnl.Location = new System.Drawing.Point(0, 3);
            this.iResultsPnl.Name = "iResultsPnl";
            this.iResultsPnl.Size = new System.Drawing.Size(784, 285);
            this.iResultsPnl.TabIndex = 3;
            // 
            // iDataGridPnl
            // 
            this.iDataGridPnl.Controls.Add(this.iResultsDGV);
            this.iDataGridPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iDataGridPnl.Location = new System.Drawing.Point(0, 46);
            this.iDataGridPnl.Name = "iDataGridPnl";
            this.iDataGridPnl.Size = new System.Drawing.Size(784, 239);
            this.iDataGridPnl.TabIndex = 4;
            // 
            // iResultsDGV
            // 
            this.iResultsDGV.AllowUserToAddRows = false;
            this.iResultsDGV.AllowUserToDeleteRows = false;
            this.iResultsDGV.AllowUserToOrderColumns = true;
            this.iResultsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.iResultsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iResultsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iResultsDGV.Location = new System.Drawing.Point(0, 0);
            this.iResultsDGV.Name = "iResultsDGV";
            this.iResultsDGV.ReadOnly = true;
            this.iResultsDGV.Size = new System.Drawing.Size(784, 239);
            this.iResultsDGV.TabIndex = 0;
            // 
            // iResultsTitlePnl
            // 
            this.iResultsTitlePnl.Controls.Add(this.iBestScoresLbl);
            this.iResultsTitlePnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.iResultsTitlePnl.Location = new System.Drawing.Point(0, 0);
            this.iResultsTitlePnl.Name = "iResultsTitlePnl";
            this.iResultsTitlePnl.Size = new System.Drawing.Size(784, 46);
            this.iResultsTitlePnl.TabIndex = 3;
            // 
            // iBestScoresLbl
            // 
            this.iBestScoresLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iBestScoresLbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iBestScoresLbl.Location = new System.Drawing.Point(0, 0);
            this.iBestScoresLbl.Name = "iBestScoresLbl";
            this.iBestScoresLbl.Size = new System.Drawing.Size(784, 46);
            this.iBestScoresLbl.TabIndex = 2;
            this.iBestScoresLbl.Text = "Best results";
            this.iBestScoresLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.Location = new System.Drawing.Point(0, 506);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 55);
            this.panel2.TabIndex = 4;
            // 
            // ResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.iHeaderPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResultsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire";
            this.iHeaderPnl.ResumeLayout(false);
            this.iTimePnl.ResumeLayout(false);
            this.iScorePnl.ResumeLayout(false);
            this.iTitlePnl.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.iResultsPnl.ResumeLayout(false);
            this.iDataGridPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iResultsDGV)).EndInit();
            this.iResultsTitlePnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel iHeaderPnl;
        private System.Windows.Forms.Label iTitleLbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button iRestartBtn;
        private System.Windows.Forms.Button iExitBtn;
        private System.Windows.Forms.Panel iResultsPnl;
        private System.Windows.Forms.DataGridView iResultsDGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label iTimeLbl;
        private System.Windows.Forms.Label iScoreLbl;
        private System.Windows.Forms.Label iBestScoresLbl;
        private System.Windows.Forms.Panel iTimePnl;
        private System.Windows.Forms.Panel iScorePnl;
        private System.Windows.Forms.Panel iTitlePnl;
        private System.Windows.Forms.Panel iResultsTitlePnl;
        private System.Windows.Forms.Panel iDataGridPnl;
    }
}