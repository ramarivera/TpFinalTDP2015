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

        private readonly QuestionData iQuestion;

        private int iCurrentQuestionIndex = 0;

        private IQuestionViewer iCurrentQuestionViewer;

        public MultipleAnswerView(int pAnswerSessionId, QuestionData pQuestion)
        {
            InitializeComponent();

            iAnswerSessionId = pAnswerSessionId;
            iQuestion = pQuestion;
            label1.Text = pQuestion.Description;

            SetupFirstQuestion();
        }

        private void SetupFirstQuestion()
        {
            throw new NotImplementedException();
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
                Question = iQuestion,
                ChosenAnswer = this.iCurrentQuestionViewer.GetUserAnswer(),
            };

            lUserAnswer.AnswerStatus = lUserAnswer.ChosenAnswer.Correct;

            using (var lHandler = HandlerFactory.Get<IUserAnswerHandler>())
            {
                lHandler.SaveUserAnswer(lUserAnswer);
            }

            this.MoveToNextQuestion();
        }

        private void MoveToQuestion(int pQuestionIndex)
        {
            if (this.iCurrentQuestionIndex < pQuestionIndex)
            {
                // error
            }

            // de algun lugar, en funcion del index, obtener la siguiente pregunt aa mostrar
            QuestionData lQuestionData = null;

            IQuestionViewer lQuestionViewer = GetQuestionViewerFor(lQuestionData);

            // guardar el current viewer (como IQV)

            var lQuestionViewerControl = lQuestionViewer as UserControl;

            this.iQuestionViewerPnl.Controls.Add(lQuestionViewerControl);

            // 
        }

        private IQuestionViewer GetQuestionViewerFor(QuestionData lQuestionData)
        {
            // aca, segun la pregunta, construir el viewer (mult choice vs yes no) correcto
            throw new NotImplementedException();
        }
    }
}
