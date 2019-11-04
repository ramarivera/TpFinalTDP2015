using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cuestionario.Services.DTO;

namespace Cuestionario.UI.WinForms
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
            radioButton1.Text = iQuestion.Answers[0].Description;
            radioButton2.Text = iQuestion.Answers[1].Description;
            radioButton3.Text = iQuestion.Answers[2].Description;
            radioButton4.Text = iQuestion.Answers[3].Description;
            // Aca deberiamos poner las distintas descriptions en los labels
        }

        private void MultipleChoiceQuestionViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
