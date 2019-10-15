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
using NHibernate;

namespace Cuestionario.UI.WinForms
{
    public partial class WelcomeView : Form
    {
        private static ISessionFactory sessionFactory = NHibernateHelper.CreateSessionFactory();
        static ISession _session = sessionFactory.OpenSession();
        private static ICategoryServices _categoryService = new CategoryServices(_session);
        private static IDifficultyServices _difficultyService = new DifficultyServices(_session);
        private static IQuestionServices _questionService = new QuestionServices(_session, _categoryService, _difficultyService);
        private OpenTriviaQuestionsServices _opentdb = new OpenTriviaQuestionsServices(_categoryService, _difficultyService, _questionService);

        public WelcomeView()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEnumerable <QuestionCreationData> lNewQuiestions = _opentdb.FilterNotImportedQuestions(_questionService.GetAll());

            foreach (var item in lNewQuiestions)
            {
                _questionService.Create(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MultipleAnswerView myNewForm = new MultipleAnswerView();
            this.Hide();
            myNewForm.ShowDialog();
            
        }
    }
}
