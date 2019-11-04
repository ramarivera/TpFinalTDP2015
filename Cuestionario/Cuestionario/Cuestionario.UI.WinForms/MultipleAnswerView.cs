using Questionnaire.Model;
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

        private readonly List<QuestionData> iQuestions;

        private int iCurrentQuestionIndex = 0;

        private IQuestionViewer iCurrentQuestionViewer;

        public MultipleAnswerView(int pAnswerSessionId, List<QuestionData> pQuestions)
        {
            InitializeComponent();

            iAnswerSessionId = pAnswerSessionId;
            iQuestions = pQuestions;

            SetupFirstQuestion();
        }

        private void SetupFirstQuestion()
        {
            QuestionData lQuestionData = iQuestions[iCurrentQuestionIndex];

            IQuestionViewer lQuestionViewer = GetQuestionViewerFor(lQuestionData);

            iCurrentQuestionViewer = lQuestionViewer;

            var lQuestionViewerControl = lQuestionViewer as UserControl;

            this.iQuestionViewerPnl.Controls.Add(lQuestionViewerControl);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.iCurrentQuestionViewer.CanProceed())
            {
                // mostrar un cartel obligando a responder la pregunta no respondida.
            }

            AnswerSessionData lAnswerSession = new AnswerSessionData();

            using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
            {
                lAnswerSession = lHandler.GetById(iAnswerSessionId);
            }

            UserAnswerCreationData lUserAnswer = new UserAnswerCreationData()
            {
                AnswerSession = lAnswerSession,
                Question = iQuestions[iCurrentQuestionIndex],
                ChosenAnswer = this.iCurrentQuestionViewer.GetUserAnswer(),
            };

            lUserAnswer.AnswerStatus = lUserAnswer.ChosenAnswer.Correct;

            using (var lHandler = HandlerFactory.Get<IUserAnswerHandler>())
            {
                lHandler.SaveUserAnswer(lUserAnswer);
            }

            this.MoveToNextQuestion(iCurrentQuestionIndex);
        }

        private void MoveToNextQuestion(int pQuestionIndex)
        {
            iCurrentQuestionIndex++;

            if (this.iCurrentQuestionIndex < pQuestionIndex)
            {
                // error
            }

            QuestionData lQuestionData = iQuestions[iCurrentQuestionIndex];

            IQuestionViewer lQuestionViewer = GetQuestionViewerFor(lQuestionData);

            // guardar el current viewer (como IQV)

            var lQuestionViewerControl = lQuestionViewer as UserControl;

            this.iQuestionViewerPnl.Controls.Add(lQuestionViewerControl);

            // 
        }

        private IQuestionViewer GetQuestionViewerFor(QuestionData lQuestionData)
        {
            if (lQuestionData.QuestionType == "boolean")
            {
                return new MultipleChoiceQuestionViewer();//YesNoQuestionViewer();
            }
            else
            {
                return new MultipleChoiceQuestionViewer(lQuestionData);
            }
        }
    }
}
