namespace TpFinalTDP2015.UI
{
    partial class ModoAdministrador
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
            this.pnlMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.trvPageNames = new System.Windows.Forms.TreeView();
            this.pnlRightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblPageName = new System.Windows.Forms.Label();
            this.pnlMainPanel.SuspendLayout();
            this.pnlLeftPanel.SuspendLayout();
            this.pnlRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainPanel
            // 
            this.pnlMainPanel.ColumnCount = 2;
            this.pnlMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.8189F));
            this.pnlMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.1811F));
            this.pnlMainPanel.Controls.Add(this.pnlLeftPanel, 0, 0);
            this.pnlMainPanel.Controls.Add(this.pnlRightPanel, 1, 0);
            this.pnlMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainPanel.Location = new System.Drawing.Point(0, 0);
            this.pnlMainPanel.Name = "pnlMainPanel";
            this.pnlMainPanel.RowCount = 1;
            this.pnlMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMainPanel.Size = new System.Drawing.Size(730, 428);
            this.pnlMainPanel.TabIndex = 0;
            this.pnlMainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // pnlLeftPanel
            // 
            this.pnlLeftPanel.ColumnCount = 1;
            this.pnlLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlLeftPanel.Controls.Add(this.trvPageNames, 0, 1);
            this.pnlLeftPanel.Location = new System.Drawing.Point(3, 3);
            this.pnlLeftPanel.Name = "pnlLeftPanel";
            this.pnlLeftPanel.RowCount = 2;
            this.pnlLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.8871F));
            this.pnlLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.1129F));
            this.pnlLeftPanel.Size = new System.Drawing.Size(204, 422);
            this.pnlLeftPanel.TabIndex = 1;
            // 
            // trvPageNames
            // 
            this.trvPageNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvPageNames.Location = new System.Drawing.Point(3, 48);
            this.trvPageNames.Name = "trvPageNames";
            this.trvPageNames.Size = new System.Drawing.Size(198, 371);
            this.trvPageNames.TabIndex = 0;
            this.trvPageNames.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // pnlRightPanel
            // 
            this.pnlRightPanel.ColumnCount = 1;
            this.pnlRightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlRightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlRightPanel.Controls.Add(this.lblPageName, 0, 0);
            this.pnlRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightPanel.Location = new System.Drawing.Point(213, 3);
            this.pnlRightPanel.Name = "pnlRightPanel";
            this.pnlRightPanel.RowCount = 2;
            this.pnlRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29032F));
            this.pnlRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.70968F));
            this.pnlRightPanel.Size = new System.Drawing.Size(514, 422);
            this.pnlRightPanel.TabIndex = 2;
            // 
            // lblPageName
            // 
            this.lblPageName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPageName.AutoSize = true;
            this.lblPageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPageName.Location = new System.Drawing.Point(3, 11);
            this.lblPageName.Name = "lblPageName";
            this.lblPageName.Size = new System.Drawing.Size(160, 25);
            this.lblPageName.TabIndex = 1;
            this.lblPageName.Text = "NombrePagina:";
            // 
            // ModoAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 428);
            this.Controls.Add(this.pnlMainPanel);
            this.Name = "ModoAdministrador";
            this.Text = "ModoAdministrador";
            this.pnlMainPanel.ResumeLayout(false);
            this.pnlLeftPanel.ResumeLayout(false);
            this.pnlRightPanel.ResumeLayout(false);
            this.pnlRightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMainPanel;
        private System.Windows.Forms.TableLayoutPanel pnlLeftPanel;
        private System.Windows.Forms.TreeView trvPageNames;
        private System.Windows.Forms.TableLayoutPanel pnlRightPanel;
        private System.Windows.Forms.Label lblPageName;
    }
}