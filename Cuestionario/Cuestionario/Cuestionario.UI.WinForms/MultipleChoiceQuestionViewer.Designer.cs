namespace Cuestionario.UI.WinForms
{
    partial class MultipleChoiceQuestionViewer
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
            this.iQuestionTitle = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iAnswerBtn4 = new System.Windows.Forms.RadioButton();
            this.iAnswerBtn3 = new System.Windows.Forms.RadioButton();
            this.iAnswerBtn2 = new System.Windows.Forms.RadioButton();
            this.iAnswerBtn1 = new System.Windows.Forms.RadioButton();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // iQuestionTitle
            // 
            this.iQuestionTitle.AutoSize = true;
            this.iQuestionTitle.BackColor = System.Drawing.Color.Transparent;
            this.iQuestionTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iQuestionTitle.Location = new System.Drawing.Point(128, 55);
            this.iQuestionTitle.Name = "iQuestionTitle";
            this.iQuestionTitle.Size = new System.Drawing.Size(470, 39);
            this.iQuestionTitle.TabIndex = 0;
            this.iQuestionTitle.Text = "Espacio dinámico para la pregunta";
            this.iQuestionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel4.Controls.Add(this.iQuestionTitle);
            this.panel4.Controls.Add(this.iAnswerBtn4);
            this.panel4.Controls.Add(this.iAnswerBtn3);
            this.panel4.Controls.Add(this.iAnswerBtn2);
            this.panel4.Controls.Add(this.iAnswerBtn1);
            this.panel4.Location = new System.Drawing.Point(-14, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(784, 390);
            this.panel4.TabIndex = 4;
            // 
            // iAnswerBtn4
            // 
            this.iAnswerBtn4.AutoSize = true;
            this.iAnswerBtn4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iAnswerBtn4.Location = new System.Drawing.Point(159, 344);
            this.iAnswerBtn4.Name = "iAnswerBtn4";
            this.iAnswerBtn4.Size = new System.Drawing.Size(121, 27);
            this.iAnswerBtn4.TabIndex = 7;
            this.iAnswerBtn4.Text = "Respuesta 4";
            this.iAnswerBtn4.UseVisualStyleBackColor = true;
            this.iAnswerBtn4.CheckedChanged += new System.EventHandler(this.iAnswerBtn4_CheckedChanged);
            // 
            // iAnswerBtn3
            // 
            this.iAnswerBtn3.AutoSize = true;
            this.iAnswerBtn3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iAnswerBtn3.Location = new System.Drawing.Point(159, 286);
            this.iAnswerBtn3.Name = "iAnswerBtn3";
            this.iAnswerBtn3.Size = new System.Drawing.Size(121, 27);
            this.iAnswerBtn3.TabIndex = 6;
            this.iAnswerBtn3.Text = "Respuesta 3";
            this.iAnswerBtn3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iAnswerBtn3.UseVisualStyleBackColor = true;
            this.iAnswerBtn3.CheckedChanged += new System.EventHandler(this.iAnswerBtn3_CheckedChanged);
            // 
            // iAnswerBtn2
            // 
            this.iAnswerBtn2.AutoSize = true;
            this.iAnswerBtn2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iAnswerBtn2.Location = new System.Drawing.Point(159, 228);
            this.iAnswerBtn2.Name = "iAnswerBtn2";
            this.iAnswerBtn2.Size = new System.Drawing.Size(121, 27);
            this.iAnswerBtn2.TabIndex = 5;
            this.iAnswerBtn2.Text = "Respuesta 2";
            this.iAnswerBtn2.UseVisualStyleBackColor = true;
            this.iAnswerBtn2.CheckedChanged += new System.EventHandler(this.iAnswerBtn2_CheckedChanged);
            // 
            // iAnswerBtn1
            // 
            this.iAnswerBtn1.AutoSize = true;
            this.iAnswerBtn1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iAnswerBtn1.Location = new System.Drawing.Point(159, 170);
            this.iAnswerBtn1.Name = "iAnswerBtn1";
            this.iAnswerBtn1.Size = new System.Drawing.Size(121, 27);
            this.iAnswerBtn1.TabIndex = 4;
            this.iAnswerBtn1.Text = "Respuesta 1";
            this.iAnswerBtn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iAnswerBtn1.UseVisualStyleBackColor = true;
            this.iAnswerBtn1.CheckedChanged += new System.EventHandler(this.iAnswerBtn1_CheckedChanged);
            // 
            // MultipleChoiceQuestionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Name = "MultipleChoiceQuestionViewer";
            this.Size = new System.Drawing.Size(757, 499);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label iQuestionTitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton iAnswerBtn4;
        private System.Windows.Forms.RadioButton iAnswerBtn3;
        private System.Windows.Forms.RadioButton iAnswerBtn2;
        private System.Windows.Forms.RadioButton iAnswerBtn1;
    }
}
