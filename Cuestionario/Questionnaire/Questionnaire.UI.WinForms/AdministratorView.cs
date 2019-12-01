using Questionnaire.Handlers.DTO;
using Questionnaire.Handlers.Handlers;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Model.Enums;
using System;
using System.ComponentModel;
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

            this.iBackgroundWorker = new BackgroundWorker();
            this.iBackgroundWorker.DoWork += IBackgroundWorker_DoWork;
            this.iBackgroundWorker.ProgressChanged += IBackgroundWorker_ProgressChanged;
            this.iBackgroundWorker.RunWorkerCompleted += IBackgroundWorker_RunWorkerCompleted;
            this.iBackgroundWorker.WorkerReportsProgress = true;

            for (int i = 50; i <= 200; i = i + 10)
            {
                iAmountCmbBox.Items.Add(i);
            }
        }

        private void IBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Import complete", "Questionnaire");
            this.iProgressBar.Value = 0;
            this.iBackBtn.Enabled = true;
            this.iQuestionsBtn.Enabled = true;
        }

        private void IBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.iProgressBar.Value = e.ProgressPercentage;
        }

        private void IBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var lWorker = sender as BackgroundWorker;
            var lAmount = (int)e.Argument;

            using (var lHandler = HandlerFactory.Get<IQuestionHandler>())
            {
                var lOpenTriviaQuestionImportingRequest = QuestionImportingRequestData.ForSourceAndAmount(QuestionSource.OpenTrivia, lAmount);
                lHandler.HandlerImportQuestionsFromProvider(
                    lOpenTriviaQuestionImportingRequest,
                    (pProgress) => {
                        lWorker.ReportProgress(Convert.ToInt32(pProgress));
                    }
                );
            }
        }

        private void iQuestionsBtn_Click(object sender, EventArgs e)
        {
            if (!this.CanProceed())
            {
                MessageBox.Show("Please, select the amount of questions to add", "Questionnaire");
            }
            else if (!this.iBackgroundWorker.IsBusy)
            {
                this.iBackBtn.Enabled = false;
                this.iQuestionsBtn.Enabled = false;
                this.iBackgroundWorker.RunWorkerAsync(argument: (int)iAmountCmbBox.SelectedItem);
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

        private bool CanProceed()
        {
            return this.iAmountCmbBox.SelectedItem != null;
        }
    }
}
