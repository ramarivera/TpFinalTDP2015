using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    partial class IntervalAdministrator
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
            this.grbDateInterval = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddDateInterval = new System.Windows.Forms.Button();
            this.btnDeleteDateInterval = new System.Windows.Forms.Button();
            this.grbTimeInterval = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddTimeInterval = new System.Windows.Forms.Button();
            this.btnDeleteTimeInterval = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.dgvTimeInterval = new GenericDGV<TimeIntervalDTO>(this.components);
            this.dgvDateInterval = new GenericDGV<DateIntervalDTO>(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.grbDateInterval.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateInterval)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.grbTimeInterval.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeInterval)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.grbDateInterval, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grbTimeInterval, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 355);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grbDateInterval
            // 
            this.grbDateInterval.Controls.Add(this.tableLayoutPanel3);
            this.grbDateInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDateInterval.Location = new System.Drawing.Point(3, 38);
            this.grbDateInterval.Name = "grbDateInterval";
            this.grbDateInterval.Size = new System.Drawing.Size(424, 153);
            this.grbDateInterval.TabIndex = 4;
            this.grbDateInterval.TabStop = false;
            this.grbDateInterval.Text = "Intervalos de fecha";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.dgvDateInterval, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(418, 134);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dgvDateInterval
            // 
            this.dgvDateInterval.AllowUserToAddRows = false;
            this.dgvDateInterval.AllowUserToOrderColumns = true;
            this.dgvDateInterval.AllowUserToResizeRows = false;
            this.dgvDateInterval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDateInterval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDateInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDateInterval.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDateInterval.Location = new System.Drawing.Point(3, 3);
            this.dgvDateInterval.Name = "dgvDateInterval";
            this.dgvDateInterval.RowHeadersVisible = false;
            this.dgvDateInterval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDateInterval.Size = new System.Drawing.Size(412, 94);
            this.dgvDateInterval.TabIndex = 2;
            this.dgvDateInterval.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDateInterval_CellClick);
            this.dgvDateInterval.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDateInterval_CellContentDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddDateInterval, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDeleteDateInterval, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnView, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(412, 28);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnAddDateInterval
            // 
            this.btnAddDateInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddDateInterval.Location = new System.Drawing.Point(44, 3);
            this.btnAddDateInterval.Name = "btnAddDateInterval";
            this.btnAddDateInterval.Size = new System.Drawing.Size(76, 22);
            this.btnAddDateInterval.TabIndex = 0;
            this.btnAddDateInterval.Text = "Agregar";
            this.btnAddDateInterval.UseVisualStyleBackColor = true;
            this.btnAddDateInterval.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteDateInterval
            // 
            this.btnDeleteDateInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteDateInterval.Location = new System.Drawing.Point(167, 3);
            this.btnDeleteDateInterval.Name = "btnDeleteDateInterval";
            this.btnDeleteDateInterval.Size = new System.Drawing.Size(76, 22);
            this.btnDeleteDateInterval.TabIndex = 1;
            this.btnDeleteDateInterval.Text = "Eliminar";
            this.btnDeleteDateInterval.UseVisualStyleBackColor = true;
            this.btnDeleteDateInterval.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // grbTimeInterval
            // 
            this.grbTimeInterval.Controls.Add(this.tableLayoutPanel4);
            this.grbTimeInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTimeInterval.Location = new System.Drawing.Point(3, 197);
            this.grbTimeInterval.Name = "grbTimeInterval";
            this.grbTimeInterval.Size = new System.Drawing.Size(424, 155);
            this.grbTimeInterval.TabIndex = 5;
            this.grbTimeInterval.TabStop = false;
            this.grbTimeInterval.Text = "Intervalos de tiempo (Del Intervalo de fecha seleccionado)";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.dgvTimeInterval, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(418, 136);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // dgvTimeInterval
            // 
            this.dgvTimeInterval.AllowUserToAddRows = false;
            this.dgvTimeInterval.AllowUserToOrderColumns = true;
            this.dgvTimeInterval.AllowUserToResizeRows = false;
            this.dgvTimeInterval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimeInterval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTimeInterval.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTimeInterval.Location = new System.Drawing.Point(3, 3);
            this.dgvTimeInterval.Name = "dgvTimeInterval";
            this.dgvTimeInterval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimeInterval.Size = new System.Drawing.Size(412, 96);
            this.dgvTimeInterval.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btnAddTimeInterval, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnDeleteTimeInterval, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 105);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(412, 28);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // btnAddTimeInterval
            // 
            this.btnAddTimeInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTimeInterval.Location = new System.Drawing.Point(85, 3);
            this.btnAddTimeInterval.Name = "btnAddTimeInterval";
            this.btnAddTimeInterval.Size = new System.Drawing.Size(76, 22);
            this.btnAddTimeInterval.TabIndex = 0;
            this.btnAddTimeInterval.Text = "Agregar";
            this.btnAddTimeInterval.UseVisualStyleBackColor = true;
            this.btnAddTimeInterval.Click += new System.EventHandler(this.btnAddTimeInterval_Click_1);
            // 
            // btnDeleteTimeInterval
            // 
            this.btnDeleteTimeInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteTimeInterval.Location = new System.Drawing.Point(249, 3);
            this.btnDeleteTimeInterval.Name = "btnDeleteTimeInterval";
            this.btnDeleteTimeInterval.Size = new System.Drawing.Size(76, 22);
            this.btnDeleteTimeInterval.TabIndex = 1;
            this.btnDeleteTimeInterval.Text = "Eliminar";
            this.btnDeleteTimeInterval.UseVisualStyleBackColor = true;
            this.btnDeleteTimeInterval.Click += new System.EventHandler(this.btnDeleteTimeInterval_Click);
            // 
            // btnView
            // 
            this.btnView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnView.Location = new System.Drawing.Point(290, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(76, 22);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "Ver";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // IntervalAdministrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 355);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "IntervalAdministrator";
            this.Text = "DateIntervalAdministrator";
            this.Load += new System.EventHandler(this.IntervalAdministrator_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grbDateInterval.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateInterval)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grbTimeInterval.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeInterval)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grbDateInterval;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAddDateInterval;
        private System.Windows.Forms.Button btnDeleteDateInterval;
        private System.Windows.Forms.GroupBox grbTimeInterval;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnAddTimeInterval;
        private System.Windows.Forms.Button btnDeleteTimeInterval;
        private System.Windows.Forms.Button btnView;
    }
}