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
using Cuestionario.Model;
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
                    comboBox1.Items.Add(lCategory.Description);
                }
            }
            using (var lHandler = HandlerFactory.Get<IDifficultyHandler>())
            {
                IList<DifficultyData> lDifficulties = lHandler.GetAll().ToList();
                foreach (var lDifficulty in lDifficulties)
                {
                    comboBox2.Items.Add(lDifficulty.Description);
                }
            }

            for (int i = 10; i <= 20; i++)
            {
                comboBox3.Items.Add(i);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var lHandler = HandlerFactory.Get<IQuestionHandler>())
            {
                lHandler.HandlerImportQuestionsFromProvider(QuestionProviderType.OpenTrivia);
            }
            MessageBox.Show("Importación finalizada", "Cuestionario");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnswerSessionStartData lAnswerSessionStartData = new AnswerSessionStartData();

            lAnswerSessionStartData.Username = textBox1.Text;
            lAnswerSessionStartData.QuestionsCount = Int32.Parse(comboBox3.SelectedItem.ToString());
            List<QuestionData> lQuestions = new List<QuestionData>();

            using (var lHandler = HandlerFactory.Get<ICategoryHandler>())
            {
                //creo que esto no está bien que esté acá
                lAnswerSessionStartData.CategoryId = lHandler.GetAll()
                    .FirstOrDefault(x => x.Description == comboBox1.SelectedItem.ToString()).Id;
            }
            using (var lHandler = HandlerFactory.Get<IDifficultyHandler>())
            {
                lAnswerSessionStartData.DifficultyId = lHandler.GetAll()
                    .FirstOrDefault(x => x.Description == comboBox2.SelectedItem.ToString()).Id;
            }

            using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
            {
                lHandler.StartAnswerSession(lAnswerSessionStartData);
            }

            using (var lHandler = HandlerFactory.Get<IQuestionHandler>())
            {
                lQuestions = lHandler.GetQuestionsForSession(lAnswerSessionStartData).ToList();
            }

            QuestionData lQuestion = lQuestions[0];

            if (lQuestion.Type == "boolean")
            {
                BooleanAnswerView myNewForm = new BooleanAnswerView(lAnswerSessionStartData, lQuestion);
                this.Hide();
                myNewForm.ShowDialog();
            }
            else
            {
                MultipleAnswerView myNewForm = new MultipleAnswerView(lAnswerSessionStartData, lQuestion);
                this.Hide();
                myNewForm.ShowDialog();
            }
            
            
        }
    }
}
