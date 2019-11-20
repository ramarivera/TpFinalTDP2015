namespace Questionnaire.UI.WinForms
{
    partial class YesNoQuestionViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.iAnswersPnl = new System.Windows.Forms.Panel();
            this.iAnswerBtn1 = new System.Windows.Forms.RadioButton();
            this.iAnswerBtn2 = new System.Windows.Forms.RadioButton();
            this.iTitlePnl = new System.Windows.Forms.Panel();
            this.iQuestionTitle = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.iAnswersPnl.SuspendLayout();
            this.iTitlePnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel4.Controls.Add(this.iAnswersPnl);
            this.panel4.Controls.Add(this.iTitlePnl);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(751, 390);
            this.panel4.TabIndex = 5;
            // 
            // iAnswersPnl
            // 
            this.iAnswersPnl.Controls.Add(this.iAnswerBtn1);
            this.iAnswersPnl.Controls.Add(this.iAnswerBtn2);
            this.iAnswersPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iAnswersPnl.Location = new System.Drawing.Point(0, 100);
            this.iAnswersPnl.Name = "iAnswersPnl";
            this.iAnswersPnl.Size = new System.Drawing.Size(751, 290);
            this.iAnswersPnl.TabIndex = 7;
            // 
            // iAnswerBtn1
            // 
            this.iAnswerBtn1.AutoSize = true;
            this.iAnswerBtn1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iAnswerBtn1.Location = new System.Drawing.Point(122, 87);
            this.iAnswerBtn1.Name = "iAnswerBtn1";
            this.iAnswerBtn1.Size = new System.Drawing.Size(101, 27);
            this.iAnswerBtn1.TabIndex = 4;
            this.iAnswerBtn1.Text = "Answer 1";
            this.iAnswerBtn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iAnswerBtn1.UseVisualStyleBackColor = true;
            this.iAnswerBtn1.CheckedChanged += new System.EventHandler(this.iAnswerBtn1_CheckedChanged);
            // 
            // iAnswerBtn2
            // 
            this.iAnswerBtn2.AutoSize = true;
            this.iAnswerBtn2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iAnswerBtn2.Location = new System.Drawing.Point(122, 180);
            this.iAnswerBtn2.Name = "iAnswerBtn2";
            this.iAnswerBtn2.Size = new System.Drawing.Size(101, 27);
            this.iAnswerBtn2.TabIndex = 5;
            this.iAnswerBtn2.Text = "Answer 2";
            this.iAnswerBtn2.UseVisualStyleBackColor = true;
            this.iAnswerBtn2.CheckedChanged += new System.EventHandler(this.iAnswerBtn2_CheckedChanged);
            // 
            // iTitlePnl
            // 
            this.iTitlePnl.Controls.Add(this.iQuestionTitle);
            this.iTitlePnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.iTitlePnl.Location = new System.Drawing.Point(0, 0);
            this.iTitlePnl.Name = "iTitlePnl";
            this.iTitlePnl.Size = new System.Drawing.Size(751, 100);
            this.iTitlePnl.TabIndex = 6;
            // 
            // iQuestionTitle
            // 
            this.iQuestionTitle.BackColor = System.Drawing.Color.Transparent;
            this.iQuestionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iQuestionTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iQuestionTitle.Location = new System.Drawing.Point(0, 0);
            this.iQuestionTitle.Name = "iQuestionTitle";
            this.iQuestionTitle.Size = new System.Drawing.Size(751, 100);
            this.iQuestionTitle.TabIndex = 0;
            this.iQuestionTitle.Text = "Dynamic space for the question";
            this.iQuestionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YesNoQuestionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Name = "YesNoQuestionViewer";
            this.Size = new System.Drawing.Size(757, 499);
            this.panel4.ResumeLayout(false);
            this.iAnswersPnl.ResumeLayout(false);
            this.iAnswersPnl.PerformLayout();
            this.iTitlePnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label iQuestionTitle;
        private System.Windows.Forms.RadioButton iAnswerBtn2;
        private System.Windows.Forms.RadioButton iAnswerBtn1;
        private System.Windows.Forms.Panel iAnswersPnl;
        private System.Windows.Forms.Panel iTitlePnl;
    }
}
