using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.UI.View
{
    partial class BannerView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grbIntervalos = new System.Windows.Forms.GroupBox();
            this.grbTextos = new System.Windows.Forms.GroupBox();
            this.grbFuentes = new System.Windows.Forms.GroupBox();
            this.dgvIntervals = new AdminModePages.GenericDGV<ScheduleDTO>(this.components);
            this.dgvTexts = new AdminModePages.GenericDGV<StaticTextDTO>(this.components);
            this.dgvSources = new AdminModePages.GenericDGV<RssSourceDTO>(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.grbDatos.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.grbIntervalos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervals)).BeginInit();
            this.grbTextos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTexts)).BeginInit();
            this.grbFuentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSources)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grbDatos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grbIntervalos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.grbTextos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grbFuentes, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 320);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.tableLayoutPanel2);
            this.grbDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDatos.Location = new System.Drawing.Point(3, 3);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(311, 154);
            this.grbDatos.TabIndex = 0;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(305, 135);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.lblName, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtName, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(299, 34);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(83, 27);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(92, 6);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(204, 20);
            this.txtName.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Controls.Add(this.lblDescription, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtDescription, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 56);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(299, 76);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Location = new System.Drawing.Point(3, 7);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 60);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Descripción";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(92, 10);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(204, 54);
            this.txtDescription.TabIndex = 1;
            // 
            // grbIntervalos
            // 
            this.grbIntervalos.Controls.Add(this.dgvIntervals);
            this.grbIntervalos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbIntervalos.Location = new System.Drawing.Point(320, 3);
            this.grbIntervalos.Name = "grbIntervalos";
            this.grbIntervalos.Size = new System.Drawing.Size(312, 154);
            this.grbIntervalos.TabIndex = 1;
            this.grbIntervalos.TabStop = false;
            this.grbIntervalos.Text = "Intervalos de aplicación";
            // 
            // dgvIntervals
            // 
            this.dgvIntervals.AllowUserToAddRows = false;
            this.dgvIntervals.AllowUserToOrderColumns = true;
            this.dgvIntervals.AllowUserToResizeRows = false;
            this.dgvIntervals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIntervals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntervals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIntervals.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIntervals.Location = new System.Drawing.Point(3, 16);
            this.dgvIntervals.Name = "dgvIntervals";
            this.dgvIntervals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIntervals.Size = new System.Drawing.Size(306, 135);
            this.dgvIntervals.TabIndex = 0;
            this.dgvIntervals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIntervals_CellContentClick);
            // 
            // grbTextos
            // 
            this.grbTextos.Controls.Add(this.dgvTexts);
            this.grbTextos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTextos.Location = new System.Drawing.Point(3, 163);
            this.grbTextos.Name = "grbTextos";
            this.grbTextos.Size = new System.Drawing.Size(311, 154);
            this.grbTextos.TabIndex = 2;
            this.grbTextos.TabStop = false;
            this.grbTextos.Text = "Textos Fijos";
            // 
            // dgvTexts
            // 
            this.dgvTexts.AllowUserToAddRows = false;
            this.dgvTexts.AllowUserToOrderColumns = true;
            this.dgvTexts.AllowUserToResizeRows = false;
            this.dgvTexts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTexts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTexts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTexts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTexts.Location = new System.Drawing.Point(3, 16);
            this.dgvTexts.Name = "dgvTexts";
            this.dgvTexts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTexts.Size = new System.Drawing.Size(305, 135);
            this.dgvTexts.TabIndex = 0;
            this.dgvTexts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTexts_CellContentClick);
            // 
            // grbFuentes
            // 
            this.grbFuentes.Controls.Add(this.dgvSources);
            this.grbFuentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbFuentes.Location = new System.Drawing.Point(320, 163);
            this.grbFuentes.Name = "grbFuentes";
            this.grbFuentes.Size = new System.Drawing.Size(312, 154);
            this.grbFuentes.TabIndex = 3;
            this.grbFuentes.TabStop = false;
            this.grbFuentes.Text = "Fuentes RSS";
            // 
            // dgvSources
            // 
            this.dgvSources.AllowUserToAddRows = false;
            this.dgvSources.AllowUserToOrderColumns = true;
            this.dgvSources.AllowUserToResizeRows = false;
            this.dgvSources.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSources.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSources.Location = new System.Drawing.Point(3, 16);
            this.dgvSources.Name = "dgvSources";
            this.dgvSources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSources.Size = new System.Drawing.Size(306, 135);
            this.dgvSources.TabIndex = 0;
            this.dgvSources.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSources_CellContentClick);
            // 
            // BannerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 320);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BannerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BannerView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grbDatos.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.grbIntervalos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervals)).EndInit();
            this.grbTextos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTexts)).EndInit();
            this.grbFuentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSources)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grbDatos;
        private System.Windows.Forms.GroupBox grbIntervalos;
        private System.Windows.Forms.GroupBox grbTextos;
        private System.Windows.Forms.GroupBox grbFuentes;
        
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
    }
}