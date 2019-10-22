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
                IList<Category> lCategories = lHandler.GetAll().OrderBy(c => c.Description).ToList();
                foreach (var lCategory in lCategories)
                {
                    comboBox1.Items.Add(lCategory.Description);
                }
            }
            using (var lHandler = HandlerFactory.Get<IDifficultyHandler>())
            {
                IList<Difficulty> lDifficulties = lHandler.GetAll();
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
            //AnswerSessionStartData lAnswerSessionStartData = new AnswerSessionStartData
            //{
            //    CategoryId = comboBox1.SelectedItem.
            //}

            //using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
            //{
            //    lHandler.StartAnswerSession
            //}

            MultipleAnswerView myNewForm = new MultipleAnswerView();
            this.Hide();
            myNewForm.ShowDialog();
        }
    }
}
