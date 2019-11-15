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
            this.SuspendLayout();
            // 
            // iQuestionsBtn
            // 
            this.iQuestionsBtn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iQuestionsBtn.Location = new System.Drawing.Point(170, 66);
            this.iQuestionsBtn.Name = "iQuestionsBtn";
            this.iQuestionsBtn.Size = new System.Drawing.Size(180, 29);
            this.iQuestionsBtn.TabIndex = 2;
            this.iQuestionsBtn.Text = "Update questions";
            this.iQuestionsBtn.UseVisualStyleBackColor = true;
            this.iQuestionsBtn.Click += new System.EventHandler(this.iQuestionsBtn_Click);
            // 
            // iBackBtn
            // 
            this.iBackBtn.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.iBackBtn.Location = new System.Drawing.Point(223, 163);
            this.iBackBtn.Name = "iBackBtn";
            this.iBackBtn.Size = new System.Drawing.Size(75, 29);
            this.iBackBtn.TabIndex = 3;
            this.iBackBtn.Text = "Back";
            this.iBackBtn.UseVisualStyleBackColor = true;
            this.iBackBtn.Click += new System.EventHandler(this.iBackBtn_Click);
            // 
            // AdministratorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 211);
            this.Controls.Add(this.iBackBtn);
            this.Controls.Add(this.iQuestionsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdministratorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire: Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministratorView_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button iQuestionsBtn;
        private System.Windows.Forms.Button iBackBtn;
    }
}