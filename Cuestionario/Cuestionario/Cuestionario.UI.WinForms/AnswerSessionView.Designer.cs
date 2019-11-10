namespace Cuestionario.UI.WinForms
{
    partial class AnswerSessionView
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iFinishBtn = new System.Windows.Forms.Button();
            this.iNextBtn = new System.Windows.Forms.Button();
            this.iQuestionViewerPnl = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.iQuestionViewerPnl);
            this.panel3.Location = new System.Drawing.Point(0, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 494);
            this.panel3.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel5.Controls.Add(this.iFinishBtn);
            this.panel5.Controls.Add(this.iNextBtn);
            this.panel5.Location = new System.Drawing.Point(0, 426);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(784, 68);
            this.panel5.TabIndex = 4;
            // 
            // iFinishBtn
            // 
            this.iFinishBtn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iFinishBtn.Location = new System.Drawing.Point(111, 24);
            this.iFinishBtn.Name = "iFinishBtn";
            this.iFinishBtn.Size = new System.Drawing.Size(89, 29);
            this.iFinishBtn.TabIndex = 1;
            this.iFinishBtn.Text = "Terminar";
            this.iFinishBtn.UseVisualStyleBackColor = true;
            // 
            // iNextBtn
            // 
            this.iNextBtn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iNextBtn.Location = new System.Drawing.Point(557, 24);
            this.iNextBtn.Name = "iNextBtn";
            this.iNextBtn.Size = new System.Drawing.Size(89, 29);
            this.iNextBtn.TabIndex = 0;
            this.iNextBtn.Text = "Siguiente";
            this.iNextBtn.UseVisualStyleBackColor = true;
            this.iNextBtn.Click += new System.EventHandler(this.iNextBtn_Click);
            // 
            // iQuestionViewerPnl
            // 
            this.iQuestionViewerPnl.Location = new System.Drawing.Point(0, 3);
            this.iQuestionViewerPnl.Name = "iQuestionViewerPnl";
            this.iQuestionViewerPnl.Size = new System.Drawing.Size(784, 417);
            this.iQuestionViewerPnl.TabIndex = 3;
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
            // MultipleAnswerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "MultipleAnswerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuestionario";
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button iFinishBtn;
        private System.Windows.Forms.Button iNextBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel iQuestionViewerPnl;
    }
}