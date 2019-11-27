﻿namespace Questionnaire.UI.WinForms
{
    partial class WelcomeView
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.iFooterLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iBackBtn = new System.Windows.Forms.Button();
            this.iBeginBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iQuestionSourceCmbBox = new System.Windows.Forms.ComboBox();
            this.iQuestionSourceLbl = new System.Windows.Forms.Label();
            this.iQuestionsCountCmbBox = new System.Windows.Forms.ComboBox();
            this.iDifficultyCmbBox = new System.Windows.Forms.ComboBox();
            this.iCategoryCmbBox = new System.Windows.Forms.ComboBox();
            this.iNameTxtBox = new System.Windows.Forms.TextBox();
            this.iQuestionsCountLbl = new System.Windows.Forms.Label();
            this.iDifficultyLbl = new System.Windows.Forms.Label();
            this.iCategoryLbl = new System.Windows.Forms.Label();
            this.iNameLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.iTitleLbl);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 141);
            this.panel1.TabIndex = 0;
            // 
            // iTitleLbl
            // 
            this.iTitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.iTitleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTitleLbl.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTitleLbl.Location = new System.Drawing.Point(0, 0);
            this.iTitleLbl.Name = "iTitleLbl";
            this.iTitleLbl.Size = new System.Drawing.Size(784, 141);
            this.iTitleLbl.TabIndex = 0;
            this.iTitleLbl.Text = "Welcome to Questionnaire";
            this.iTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.Controls.Add(this.iFooterLbl);
            this.panel2.Location = new System.Drawing.Point(0, 506);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 55);
            this.panel2.TabIndex = 1;
            this.panel2.UseWaitCursor = true;
            // 
            // iFooterLbl
            // 
            this.iFooterLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iFooterLbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iFooterLbl.Location = new System.Drawing.Point(0, 0);
            this.iFooterLbl.Name = "iFooterLbl";
            this.iFooterLbl.Size = new System.Drawing.Size(784, 55);
            this.iFooterLbl.TabIndex = 0;
            this.iFooterLbl.Text = "Developed by MARR";
            this.iFooterLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iFooterLbl.UseWaitCursor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, 141);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 365);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel5.Controls.Add(this.iBackBtn);
            this.panel5.Controls.Add(this.iBeginBtn);
            this.panel5.Location = new System.Drawing.Point(0, 294);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(784, 71);
            this.panel5.TabIndex = 4;
            // 
            // iBackBtn
            // 
            this.iBackBtn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iBackBtn.Location = new System.Drawing.Point(140, 24);
            this.iBackBtn.Name = "iBackBtn";
            this.iBackBtn.Size = new System.Drawing.Size(83, 29);
            this.iBackBtn.TabIndex = 1;
            this.iBackBtn.Text = "Back";
            this.iBackBtn.UseVisualStyleBackColor = true;
            this.iBackBtn.Click += new System.EventHandler(this.iBackBtn_Click);
            // 
            // iBeginBtn
            // 
            this.iBeginBtn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iBeginBtn.Location = new System.Drawing.Point(560, 24);
            this.iBeginBtn.Name = "iBeginBtn";
            this.iBeginBtn.Size = new System.Drawing.Size(83, 29);
            this.iBeginBtn.TabIndex = 0;
            this.iBeginBtn.Text = "Start";
            this.iBeginBtn.UseVisualStyleBackColor = true;
            this.iBeginBtn.Click += new System.EventHandler(this.iBeginBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel4.Controls.Add(this.iQuestionSourceCmbBox);
            this.panel4.Controls.Add(this.iQuestionSourceLbl);
            this.panel4.Controls.Add(this.iQuestionsCountCmbBox);
            this.panel4.Controls.Add(this.iDifficultyCmbBox);
            this.panel4.Controls.Add(this.iCategoryCmbBox);
            this.panel4.Controls.Add(this.iNameTxtBox);
            this.panel4.Controls.Add(this.iQuestionsCountLbl);
            this.panel4.Controls.Add(this.iDifficultyLbl);
            this.panel4.Controls.Add(this.iCategoryLbl);
            this.panel4.Controls.Add(this.iNameLbl);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(784, 288);
            this.panel4.TabIndex = 3;
            // 
            // iQuestionSourceCmbBox
            // 
            this.iQuestionSourceCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iQuestionSourceCmbBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iQuestionSourceCmbBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iQuestionSourceCmbBox.FormattingEnabled = true;
            this.iQuestionSourceCmbBox.Location = new System.Drawing.Point(390, 89);
            this.iQuestionSourceCmbBox.Name = "iQuestionSourceCmbBox";
            this.iQuestionSourceCmbBox.Size = new System.Drawing.Size(256, 31);
            this.iQuestionSourceCmbBox.TabIndex = 9;
            // 
            // iQuestionSourceLbl
            // 
            this.iQuestionSourceLbl.AutoSize = true;
            this.iQuestionSourceLbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iQuestionSourceLbl.Location = new System.Drawing.Point(162, 93);
            this.iQuestionSourceLbl.Name = "iQuestionSourceLbl";
            this.iQuestionSourceLbl.Size = new System.Drawing.Size(186, 23);
            this.iQuestionSourceLbl.TabIndex = 8;
            this.iQuestionSourceLbl.Text = "Select Question source";
            // 
            // iQuestionsCountCmbBox
            // 
            this.iQuestionsCountCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iQuestionsCountCmbBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iQuestionsCountCmbBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iQuestionsCountCmbBox.FormattingEnabled = true;
            this.iQuestionsCountCmbBox.Location = new System.Drawing.Point(390, 230);
            this.iQuestionsCountCmbBox.Name = "iQuestionsCountCmbBox";
            this.iQuestionsCountCmbBox.Size = new System.Drawing.Size(256, 31);
            this.iQuestionsCountCmbBox.TabIndex = 7;
            // 
            // iDifficultyCmbBox
            // 
            this.iDifficultyCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iDifficultyCmbBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iDifficultyCmbBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iDifficultyCmbBox.FormattingEnabled = true;
            this.iDifficultyCmbBox.Location = new System.Drawing.Point(390, 183);
            this.iDifficultyCmbBox.Name = "iDifficultyCmbBox";
            this.iDifficultyCmbBox.Size = new System.Drawing.Size(256, 31);
            this.iDifficultyCmbBox.TabIndex = 6;
            // 
            // iCategoryCmbBox
            // 
            this.iCategoryCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iCategoryCmbBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iCategoryCmbBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iCategoryCmbBox.FormattingEnabled = true;
            this.iCategoryCmbBox.Location = new System.Drawing.Point(390, 136);
            this.iCategoryCmbBox.Name = "iCategoryCmbBox";
            this.iCategoryCmbBox.Size = new System.Drawing.Size(256, 31);
            this.iCategoryCmbBox.TabIndex = 5;
            // 
            // iNameTxtBox
            // 
            this.iNameTxtBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iNameTxtBox.Location = new System.Drawing.Point(390, 42);
            this.iNameTxtBox.Name = "iNameTxtBox";
            this.iNameTxtBox.Size = new System.Drawing.Size(256, 31);
            this.iNameTxtBox.TabIndex = 4;
            this.iNameTxtBox.Text = "name";
            // 
            // iQuestionsCountLbl
            // 
            this.iQuestionsCountLbl.AutoSize = true;
            this.iQuestionsCountLbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iQuestionsCountLbl.Location = new System.Drawing.Point(129, 234);
            this.iQuestionsCountLbl.Name = "iQuestionsCountLbl";
            this.iQuestionsCountLbl.Size = new System.Drawing.Size(219, 23);
            this.iQuestionsCountLbl.TabIndex = 3;
            this.iQuestionsCountLbl.Text = "Select amount of questions";
            // 
            // iDifficultyLbl
            // 
            this.iDifficultyLbl.AutoSize = true;
            this.iDifficultyLbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iDifficultyLbl.Location = new System.Drawing.Point(228, 187);
            this.iDifficultyLbl.Name = "iDifficultyLbl";
            this.iDifficultyLbl.Size = new System.Drawing.Size(120, 23);
            this.iDifficultyLbl.TabIndex = 2;
            this.iDifficultyLbl.Text = "Select dificulty";
            // 
            // iCategoryLbl
            // 
            this.iCategoryLbl.AutoSize = true;
            this.iCategoryLbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iCategoryLbl.Location = new System.Drawing.Point(222, 140);
            this.iCategoryLbl.Name = "iCategoryLbl";
            this.iCategoryLbl.Size = new System.Drawing.Size(126, 23);
            this.iCategoryLbl.TabIndex = 1;
            this.iCategoryLbl.Text = "Select category";
            // 
            // iNameLbl
            // 
            this.iNameLbl.AutoSize = true;
            this.iNameLbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iNameLbl.Location = new System.Drawing.Point(152, 46);
            this.iNameLbl.Name = "iNameLbl";
            this.iNameLbl.Size = new System.Drawing.Size(196, 23);
            this.iNameLbl.TabIndex = 0;
            this.iNameLbl.Text = "Please, enter your name";
            this.iNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WelcomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WelcomeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WelcomeView_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label iTitleLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label iQuestionsCountLbl;
        private System.Windows.Forms.Label iDifficultyLbl;
        private System.Windows.Forms.Label iCategoryLbl;
        private System.Windows.Forms.Label iNameLbl;
        private System.Windows.Forms.Button iBeginBtn;
        private System.Windows.Forms.ComboBox iQuestionsCountCmbBox;
        private System.Windows.Forms.ComboBox iDifficultyCmbBox;
        private System.Windows.Forms.ComboBox iCategoryCmbBox;
        private System.Windows.Forms.TextBox iNameTxtBox;
        private System.Windows.Forms.Label iFooterLbl;
        private System.Windows.Forms.Button iBackBtn;
        private System.Windows.Forms.ComboBox iQuestionSourceCmbBox;
        private System.Windows.Forms.Label iQuestionSourceLbl;
    }
}

