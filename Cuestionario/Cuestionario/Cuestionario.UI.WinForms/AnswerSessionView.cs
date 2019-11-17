using Questionnaire.Model;
using Questionnaire.Services.DTO;
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
using Questionnaire.Model.Enums;

namespace Questionnaire.UI.WinForms
{
    public partial class AnswerSessionView : Form
    {
        private readonly long iAnswerSessionId;

        private readonly List<QuestionData> iQuestions;

        private int iCurrentQuestionIndex = 0;

        private IQuestionViewer iCurrentQuestionViewer;

        public AnswerSessionView(long pAnswerSessionId, List<QuestionData> pQuestions)
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

        private void iNextBtn_Click(object sender, EventArgs e)
        {
            if (!this.iCurrentQuestionViewer.CanProceed())
            {
                MessageBox.Show("Please, choose an answer for the question", "Questionnaire");
            }
            else
            {
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
                    lHandler.SaveUserAnswer(lUserAnswer, iAnswerSessionId);
                }

                if(iCurrentQuestionIndex < iQuestions.Count()-1)
                {
                    this.MoveToNextQuestion(iCurrentQuestionIndex + 1);
                }
                else
                {
                    using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
                    {
                        lHandler.EndAnswerSession(iAnswerSessionId);
                    }

                    ResultsView lResultsView = new ResultsView(iAnswerSessionId);
                    this.Hide();
                    lResultsView.ShowDialog();
                }
            }
        }

        private void MoveToNextQuestion(int pQuestionIndex)
        {
            //if (this.iCurrentQuestionIndex < pQuestionIndex)
            //{
            //    // error
            //}

            iCurrentQuestionIndex = pQuestionIndex;

            QuestionData lQuestionData = iQuestions[iCurrentQuestionIndex];

            this.iQuestionViewerPnl.Controls.Clear();

            IQuestionViewer lQuestionViewer = GetQuestionViewerFor(lQuestionData);

            iCurrentQuestionViewer = lQuestionViewer;

            var lQuestionViewerControl = lQuestionViewer as UserControl;

            this.iQuestionViewerPnl.Controls.Add(lQuestionViewerControl);
        }

        private IQuestionViewer GetQuestionViewerFor(QuestionData lQuestionData)
        {
            if (lQuestionData.QuestionType == QuestionType.YesNo)
            {
                return new YesNoQuestionViewer(lQuestionData);
            }
            else 
            {
                return new MultipleChoiceQuestionViewer(lQuestionData);
            }
        }

        private void AnswerSessionView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("Are you sure you want to exit?", "Questionnaire", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void iFinishBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
