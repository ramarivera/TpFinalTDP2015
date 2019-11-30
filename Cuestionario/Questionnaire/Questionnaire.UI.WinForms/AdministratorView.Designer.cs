namespace Questionnaire.UI.WinForms
{
    partial class AdministratorView
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
            this.iQuestionsBtn = new System.Windows.Forms.Button();
            this.iBackBtn = new System.Windows.Forms.Button();
            this.iProgressBar = new System.Windows.Forms.ProgressBar();
            this.iAmountLbl = new System.Windows.Forms.Label();
            this.iAmountCmbBox = new System.Windows.Forms.ComboBox();
            this.iBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // iQuestionsBtn
            // 
            this.iQuestionsBtn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iQuestionsBtn.Location = new System.Drawing.Point(393, 39);
            this.iQuestionsBtn.Name = "iQuestionsBtn";
            this.iQuestionsBtn.Size = new System.Drawing.Size(75, 29);
            this.iQuestionsBtn.TabIndex = 2;
            this.iQuestionsBtn.Text = "Start";
            this.iQuestionsBtn.UseVisualStyleBackColor = true;
            this.iQuestionsBtn.Click += new System.EventHandler(this.iQuestionsBtn_Click);
            // 
            // iBackBtn
            // 
            this.iBackBtn.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.iBackBtn.Location = new System.Drawing.Point(223, 165);
            this.iBackBtn.Name = "iBackBtn";
            this.iBackBtn.Size = new System.Drawing.Size(75, 29);
            this.iBackBtn.TabIndex = 3;
            this.iBackBtn.Text = "Back";
            this.iBackBtn.UseVisualStyleBackColor = true;
            this.iBackBtn.Click += new System.EventHandler(this.iBackBtn_Click);
            // 
            // iProgressBar
            // 
            this.iProgressBar.Location = new System.Drawing.Point(93, 113);
            this.iProgressBar.Name = "iProgressBar";
            this.iProgressBar.Size = new System.Drawing.Size(334, 30);
            this.iProgressBar.TabIndex = 4;
            // 
            // iAmountLbl
            // 
            this.iAmountLbl.AutoSize = true;
            this.iAmountLbl.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.iAmountLbl.Location = new System.Drawing.Point(36, 42);
            this.iAmountLbl.Name = "iAmountLbl";
            this.iAmountLbl.Size = new System.Drawing.Size(225, 23);
            this.iAmountLbl.TabIndex = 5;
            this.iAmountLbl.Text = "Amount of questions to add";
            // 
            // iAmountCmbBox
            // 
            this.iAmountCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iAmountCmbBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iAmountCmbBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iAmountCmbBox.FormattingEnabled = true;
            this.iAmountCmbBox.Location = new System.Drawing.Point(269, 38);
            this.iAmountCmbBox.Name = "iAmountCmbBox";
            this.iAmountCmbBox.Size = new System.Drawing.Size(115, 31);
            this.iAmountCmbBox.TabIndex = 10;
            // 
            // AdministratorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 211);
            this.Controls.Add(this.iAmountCmbBox);
            this.Controls.Add(this.iAmountLbl);
            this.Controls.Add(this.iProgressBar);
            this.Controls.Add(this.iBackBtn);
            this.Controls.Add(this.iQuestionsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdministratorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire: Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministratorView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button iQuestionsBtn;
        private System.Windows.Forms.Button iBackBtn;
        private System.Windows.Forms.ProgressBar iProgressBar;
        private System.Windows.Forms.Label iAmountLbl;
        private System.Windows.Forms.ComboBox iAmountCmbBox;
        private System.ComponentModel.BackgroundWorker iBackgroundWorker;
    }
}