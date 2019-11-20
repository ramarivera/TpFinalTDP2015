using Questionnaire.Services;
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

namespace Questionnaire.UI.WinForms
{
    /// <summary>
    /// Form in charge of allow Questionnaire's Administrator to import new Questions 
    /// </summary>
    public partial class AdministratorView : Form
    {
        public AdministratorView()
        {
            InitializeComponent();
        }

        private void iQuestionsBtn_Click(object sender, EventArgs e)
        {
            using (var lHandler = HandlerFactory.Get<IQuestionHandler>())
            {
                lHandler.HandlerImportQuestionsFromProvider(QuestionProviderType.OpenTrivia);
                MessageBox.Show("Import complete", "Questionnaire");
            }
        }

        private void iBackBtn_Click(object sender, EventArgs e)
        {
            StartUpView lStartUpView = new StartUpView();
            this.Hide();
            lStartUpView.ShowDialog();
        }

        private void AdministratorView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("Are you sure you want to exit?", "Questionnaire", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }
    }
}
