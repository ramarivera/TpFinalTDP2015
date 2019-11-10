namespace Cuestionario.UI.WinForms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.iTitleLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iRestartBtn = new System.Windows.Forms.Button();
            this.iExitBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iResultsDGV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iResultsDGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.iTitleLbl);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 149);
            this.panel1.TabIndex = 1;
            // 
            // iTitleLbl
            // 
            this.iTitleLbl.AutoSize = true;
            this.iTitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.iTitleLbl.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTitleLbl.Location = new System.Drawing.Point(247, 12);
            this.iTitleLbl.Name = "iTitleLbl";
            this.iTitleLbl.Size = new System.Drawing.Size(309, 39);
            this.iTitleLbl.TabIndex = 0;
            this.iTitleLbl.Text = "¡Gracias por paticipar!";
            this.iTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
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
            this.iRestartBtn.Text = "Reiniciar";
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
            this.iExitBtn.Text = "Salir";
            this.iExitBtn.UseVisualStyleBackColor = true;
            this.iExitBtn.Click += new System.EventHandler(this.iExitBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel4.Controls.Add(this.iResultsDGV);
            this.panel4.Location = new System.Drawing.Point(0, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(784, 271);
            this.panel4.TabIndex = 3;
            // 
            // iResultsDGV
            // 
            this.iResultsDGV.AllowUserToAddRows = false;
            this.iResultsDGV.AllowUserToDeleteRows = false;
            this.iResultsDGV.AllowUserToOrderColumns = true;
            this.iResultsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.iResultsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iResultsDGV.Location = new System.Drawing.Point(100, 11);
            this.iResultsDGV.Name = "iResultsDGV";
            this.iResultsDGV.ReadOnly = true;
            this.iResultsDGV.Size = new System.Drawing.Size(598, 224);
            this.iResultsDGV.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 506);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 55);
            this.panel2.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(293, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Desarrollado por John Wayne";
            // 
            // ResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "ResultsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuestionario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iResultsDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label iTitleLbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button iRestartBtn;
        private System.Windows.Forms.Button iExitBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView iResultsDGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
    }
}