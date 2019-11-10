using Cuestionario.Services.Interfaces;
using Cuestionario.Services.DTO;
using Cuestionario.Services.OpenTrivia;
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
using Cuestionario.Services;
using Questionnaire.Model;
using Questionnaire.Handlers.Handlers;
using Questionnaire.Handlers.Handlers.Interfaces;

namespace Cuestionario.UI.WinForms
{
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
                    iCategoryCmbBox.Items.Add(lCategory.Description);
                }
            }
            using (var lHandler = HandlerFactory.Get<IDifficultyHandler>())
            {
                IList<DifficultyData> lDifficulties = lHandler.GetAll().ToList();
                foreach (var lDifficulty in lDifficulties)
                {
                    iDifficultyCmbBox.Items.Add(lDifficulty.Description);
                }
            }

            for (int i = 10; i <= 20; i++)
            {
                iQuestionsCountCmbBox.Items.Add(i);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var lHandler = HandlerFactory.Get<IQuestionHandler>())
            {
                lHandler.HandlerImportQuestionsFromProvider(QuestionProviderType.OpenTrivia);
            }
            MessageBox.Show("Importación finalizada", "Cuestionario");
        }

        private void iBeginBtn_Click(object sender, EventArgs e)
        {
            if (!this.CanProceed())
            {
                MessageBox.Show("Por favor, complete la información inicial", "Cuestionario");
            }
            else
            {
                AnswerSessionStartData lAnswerSessionStartData = new AnswerSessionStartData();

                lAnswerSessionStartData.Username = iNameTxtBox.Text;
                lAnswerSessionStartData.QuestionsCount = Int32.Parse(iQuestionsCountCmbBox.SelectedItem.ToString());
                List<QuestionData> lQuestions = new List<QuestionData>();
                int lAnswerSessionId;

                using (var lHandler = HandlerFactory.Get<ICategoryHandler>())
                {
                    //creo que esto no está bien que esté acá
                    lAnswerSessionStartData.CategoryId = lHandler.GetAll()
                        .FirstOrDefault(x => x.Description == iCategoryCmbBox.SelectedItem.ToString()).Id;
                }
                using (var lHandler = HandlerFactory.Get<IDifficultyHandler>())
                {
                    lAnswerSessionStartData.DifficultyId = lHandler.GetAll()
                        .FirstOrDefault(x => x.Description == iDifficultyCmbBox.SelectedItem.ToString()).Id;
                }

                using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
                {
                    lAnswerSessionId = lHandler.StartAnswerSession(lAnswerSessionStartData);
                }

                using (var lHandler = HandlerFactory.Get<IQuestionHandler>())
                {
                    lQuestions = lHandler.GetQuestionsForSession(lAnswerSessionStartData).ToList();
                }

                AnswerSessionView lMultipleAnswerView = new AnswerSessionView(lAnswerSessionId, lQuestions);
                this.Hide();
                lMultipleAnswerView.ShowDialog();
            }
        }

        private void WelcomeView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("¿Está seguro que desea salir?", "Cuestionario", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private bool CanProceed()
        {
            bool lResult = true;

            if(iCategoryCmbBox.Text == "Categoría") { lResult = false; }
            else if (iDifficultyCmbBox.Text == "Dificultad") { lResult = false; }
            else if (iQuestionsCountCmbBox.Text == "-") { lResult = false; }

            return lResult;
        }
    }
}
