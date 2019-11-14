﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Questionnaire.Services.DTO;

namespace Questionnaire.UI.WinForms
{
    public partial class MultipleChoiceQuestionViewer : UserControl, IQuestionViewer
    {
        private readonly QuestionData iQuestion;
        private AnswerData iUserAnswer;

        public MultipleChoiceQuestionViewer()
        {
            InitializeComponent();
        }

        public MultipleChoiceQuestionViewer(QuestionData pQuestionData)
            : this()
        {
            this.iQuestion = pQuestionData;

            SetupControl(this.iQuestion);
        }

        public bool CanProceed()
        {
            return this.iUserAnswer != null;
        }

        public AnswerData GetUserAnswer()
        {
            return this.iUserAnswer;
        }

        private void SetupControl(QuestionData iQuestion)
        {
            iQuestionTitle.Text = iQuestion.Description;
            iAnswerBtn1.Text = iQuestion.Answers[0].Description;
            iAnswerBtn2.Text = iQuestion.Answers[1].Description;
            iAnswerBtn3.Text = iQuestion.Answers[2].Description;
            iAnswerBtn4.Text = iQuestion.Answers[3].Description;
        }

        private void iAnswerBtn1_CheckedChanged(object sender, EventArgs e)
        {
            if (iAnswerBtn1.Checked)
            {
                this.iUserAnswer = iQuestion.Answers.FirstOrDefault(x => x.Description == iAnswerBtn1.Text);
            }
        }

        private void iAnswerBtn2_CheckedChanged(object sender, EventArgs e)
        {
            if (iAnswerBtn2.Checked)
            {
                this.iUserAnswer = iQuestion.Answers.FirstOrDefault(x => x.Description == iAnswerBtn2.Text);
            }
        }

        private void iAnswerBtn3_CheckedChanged(object sender, EventArgs e)
        {
            if (iAnswerBtn3.Checked)
            {
                this.iUserAnswer = iQuestion.Answers.FirstOrDefault(x => x.Description == iAnswerBtn3.Text);
            }
        }

        private void iAnswerBtn4_CheckedChanged(object sender, EventArgs e)
        {
            if (iAnswerBtn4.Checked)
            {
                this.iUserAnswer = iQuestion.Answers.FirstOrDefault(x => x.Description == iAnswerBtn4.Text);
            }
        }
    }
}
