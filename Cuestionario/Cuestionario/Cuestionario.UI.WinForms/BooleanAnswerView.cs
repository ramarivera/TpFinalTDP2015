using Cuestionario.Model;
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
    public partial class BooleanAnswerView : Form
    {
        public BooleanAnswerView(Question pQuestion)
        {
            InitializeComponent();
            label1.Text = pQuestion.Description;
            radioButton1.Text = pQuestion.Answers[0].Description;
            radioButton2.Text = pQuestion.Answers[1].Description;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
            {
                //lHandler.StartAnswerSession2();
            }
        }
    }
}
