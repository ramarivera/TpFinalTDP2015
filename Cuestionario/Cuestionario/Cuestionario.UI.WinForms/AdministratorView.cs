using Questionnaire.Handlers.Handlers;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Services;
using System;
using System.Windows.Forms;

namespace Questionnaire.UI.WinForms
{
    public partial class AdministratorView : Form
    {
        public AdministratorView()
        {
            InitializeComponent();
        }

        private async void iQuestionsBtn_Click(object sender, EventArgs e)
        {
            //using (var lHandler = HandlerFactory.Get<IQuestionHandler>())
            //{
            //    await lHandler.HandlerImportQuestionsFromProviderAsync(QuestionProviderType.OpenTrivia);
            //    MessageBox.Show("Import complete", "Questionnaire");
            //}

            var lHandler = HandlerFactory.Get<IQuestionHandler>();
            await lHandler.HandlerImportQuestionsFromProviderAsync(QuestionProviderType.OpenTrivia).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    MessageBox.Show("Import complete", "Questionnaire");
                }
                else
                {
                    MessageBox.Show(task.Exception.ToString(), "Import errored");
                }

                lHandler.Dispose();
            });

            //var lHandler = HandlerFactory.Get<IQuestionHandler>();
            //try
            //{
            //    await lHandler.HandlerImportQuestionsFromProviderAsync(QuestionProviderType.OpenTrivia);
            //    MessageBox.Show("Import complete", "Questionnaire");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Import errored");
            //}
            //finally
            //{
            //    lHandler.Dispose();
            //}
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
