using Questionnaire.Services.Interfaces;
using Questionnaire.Services.DTO;
using Questionnaire.Services.OpenTrivia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Questionnaire.Services;
using Questionnaire.Model;
using Questionnaire.Handlers.Handlers;
using Questionnaire.Handlers.Handlers.Interfaces;

namespace Questionnaire.UI.WinForms
{
    // TODO missing documentation
    public partial class WelcomeView : Form
    {
        public WelcomeView()
        {
            InitializeComponent();
            using (var lHandler = HandlerFactory.Get<ICategoryHandler>())
            {
                IList<CategoryData> lCategories = lHandler.GetAll()
                    .OrderBy(x => x.Description).ToList();
                foreach (var lCategory in lCategories)
                {
                    iCategoryCmbBox.Items.Add(lCategory);
                }
                iCategoryCmbBox.DisplayMember = "Description";
            }
            using (var lHandler = HandlerFactory.Get<IDifficultyHandler>())
            {
                IList<DifficultyData> lDifficulties = lHandler.GetAll().ToList();
                foreach (var lDifficulty in lDifficulties)
                {
                    iDifficultyCmbBox.Items.Add(lDifficulty);
                }
                iDifficultyCmbBox.DisplayMember = "Description";
            }

            for (int i = 10; i <= 20; i++)
            {
                iQuestionsCountCmbBox.Items.Add(i);
            }

        }

        private void iBackBtn_Click(object sender, EventArgs e)
        {
            StartUpView lStartUpView = new StartUpView();
            this.Hide();
            lStartUpView.ShowDialog();
        }

        private void iBeginBtn_Click(object sender, EventArgs e)
        {
            if (!this.CanProceed())
            {
                MessageBox.Show("Please, complete all fields", "Questionnaire");
            }
            else
            {
                AnswerSessionStartData lAnswerSessionStartData = new AnswerSessionStartData();
                List<QuestionData> lQuestions = new List<QuestionData>();
                long lAnswerSessionId;

                lAnswerSessionStartData.Username = iNameTxtBox.Text;
                lAnswerSessionStartData.QuestionsCount = Int32.Parse(iQuestionsCountCmbBox.SelectedItem.ToString());
                lAnswerSessionStartData.CategoryId = ((CategoryData)iCategoryCmbBox.SelectedItem).Id;
                lAnswerSessionStartData.DifficultyId = ((DifficultyData)iDifficultyCmbBox.SelectedItem).Id;

                using (var lHandler = HandlerFactory.Get<IQuestionHandler>())
                {
                    lQuestions = lHandler.GetQuestionsForSession(lAnswerSessionStartData).ToList();
                }

                if (!this.ValidateAmountQuestions(lQuestions, Int32.Parse(iQuestionsCountCmbBox.SelectedItem.ToString())))
                {
                    MessageBox.Show("There are not enough questions matching the selected parameters, please retrieve more questions.", "Error");
                }
                else
                {
                    using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
                    {
                        lAnswerSessionId = lHandler.StartAnswerSession(lAnswerSessionStartData);
                    }

                    AnswerSessionView lMultipleAnswerView = new AnswerSessionView(lAnswerSessionId, lQuestions);
                    this.Hide();
                    lMultipleAnswerView.ShowDialog();
                }
            }
        }

        private void WelcomeView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("Are you sure you want to exit?", "Questionnaire", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private bool CanProceed()
        {
            bool lResult = true;

            if(iCategoryCmbBox.SelectedItem == null) { lResult = false; }
            else if (iDifficultyCmbBox.SelectedItem == null) { lResult = false; }
            else if (iQuestionsCountCmbBox.SelectedItem == null) { lResult = false; }

            return lResult;
        }
        /// <summary>
        /// Compares the amount of elements in the data set against a given number
        /// </summary>
        /// <param name="pQuestions"></param>
        /// <param name="pQty"></param>
        /// <returns>true or false</returns>
        private bool ValidateAmountQuestions(List<QuestionData> pQuestions, Int32 pQty)
        {
            return pQuestions.Count() >= pQty;
        }
    }
}
