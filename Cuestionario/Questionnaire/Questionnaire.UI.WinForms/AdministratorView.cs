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
using Questionnaire.Model.Enums;

namespace Questionnaire.UI.WinForms
{
    /// <summary>
    /// Form in charge of allow Questionnaire's Administrator to import new Questions 
    /// </summary>
    public partial class AdministratorView : Form
    {
        private int iAmount;
        public AdministratorView()
        {
            InitializeComponent();

            this.iBackgroundWorker = new BackgroundWorker();
            this.iBackgroundWorker.DoWork += IBackgroundWorker_DoWork;
            this.iBackgroundWorker.ProgressChanged += IBackgroundWorker_ProgressChanged;
            this.iBackgroundWorker.RunWorkerCompleted += IBackgroundWorker_RunWorkerCompleted;
            this.iBackgroundWorker.WorkerReportsProgress = true;

            for (int i = 50; i <= 200; i=i+10)
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
            //TODO review reportProgress
            BackgroundWorker lWorker = (BackgroundWorker)sender;
            for (int i = 0; i < 100; i++)
            {
                lWorker.ReportProgress(i);
                using (var lHandler = HandlerFactory.Get<IQuestionHandler>())
                {
                    lHandler.HandlerImportQuestionsFromProvider(QuestionSource.OpenTrivia, iAmount);
                }
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
                iAmount = (int)iAmountCmbBox.SelectedItem;
                this.iBackBtn.Enabled = false;
                this.iQuestionsBtn.Enabled = false;
                this.iBackgroundWorker.RunWorkerAsync();
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
            if (iAmountCmbBox.SelectedItem == null) return false;
            else return true;
        }
    }
}
