using Cuestionario.Model;
using Cuestionario.Services.DTO;
using Questionnaire.Handlers.Handlers;
using Questionnaire.Handlers.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuestionario.UI.WinForms
{
    public partial class MultipleAnswerView : Form
    {
        private readonly int iAnswerSessionId;
        private readonly QuestionData iQuestion;
        public MultipleAnswerView(int pAnswerSessionId, QuestionData pQuestion)
        {
            InitializeComponent();
            iAnswerSessionId = pAnswerSessionId;
            iQuestion = pQuestion;
            label1.Text = pQuestion.Description;
            radioButton1.Text = pQuestion.Answers[0].Description;
            radioButton2.Text = pQuestion.Answers[1].Description;
            radioButton3.Text = pQuestion.Answers[2].Description;
            radioButton4.Text = pQuestion.Answers[3].Description;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnswerSessionData lAnswerSession = new AnswerSessionData();

            using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
            {
                lAnswerSession = lHandler.GetById(iAnswerSessionId);
            }

            UserAnswerCreationData lUserAnswer = new UserAnswerCreationData()
            {
                AnswerSession = lAnswerSession,
                Question = iQuestion,
                ChosenAnswer = this.GetChosenAnswer(),
            };

            lUserAnswer.AnswerStatus = lUserAnswer.ChosenAnswer.Correct;

            using (var lHandler = HandlerFactory.Get<IUserAnswerHandler>())
            {
               lHandler.SaveUserAnswer(lUserAnswer);
            }
        }

        private AnswerData GetChosenAnswer()
        {
            AnswerData lResult = new AnswerData();
            if (radioButton1.Checked)
            {
                lResult = iQuestion.Answers.FirstOrDefault(x => x.Description == radioButton1.Text);
            }
            else if (radioButton2.Checked)
            {
                lResult = iQuestion.Answers.FirstOrDefault(x => x.Description == radioButton2.Text);
            }
            else if (radioButton3.Checked)
            {
                lResult = iQuestion.Answers.FirstOrDefault(x => x.Description == radioButton3.Text);
            }
            else if (radioButton4.Checked)
            {
                lResult = iQuestion.Answers.FirstOrDefault(x => x.Description == radioButton4.Text);
            }
            return lResult;
        }
    }
} 
