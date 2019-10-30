using Cuestionario.Model;
using Cuestionario.Services.DTO;
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
        private readonly AnswerSessionStartData iAnswerSession;
        private readonly Question iQuestion;
        public MultipleAnswerView(AnswerSessionStartData pAnswerSession, Question pQuestion)
        {
            InitializeComponent();
            iAnswerSession = pAnswerSession;
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
            //UserAnswerCreationData lUserAnswer = new UserAnswerCreationData()
            //{
            //    AnswerSession = iAnswerSession,
            //    Question = iQuestion,
            //    ChosenAnswer = 
            //}
        }

        //private Answer GetChosenAnswer()
        //{
        //    //Answer lResult = new Answer(); 
        //    //if (radioButton1.Checked)
        //    //{
        //    //    lResult = radio
        //    //}
        //    //return lResult;
        //}
    }
}
