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

namespace Questionnaire.UI.WinForms
{
    /// <summary>
    /// Form in charge of showing actual Answer Session result, 
    /// and the historical best Answer Session results 
    /// </summary>
    public partial class ResultsView : Form
    {
        public ResultsView(long pAnswerSessionId)
        {
            InitializeComponent();

            using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
            {
                AnswerSessionData lAnswerSession = lHandler.GetById(pAnswerSessionId);
                this.iScoreLbl.Text = String.Format("Score: {0} points", lAnswerSession.Score);
                this.iTimeLbl.Text = String.Format("Game time: {0} seconds", lAnswerSession.SessionDuration);

                IList<AnswerSessionData> lAnswerSessions = lHandler.GetAll()
                    .OrderByDescending(x => x.Score).ToList();

                // TODO the list must show only the 20 best results
                var lSource = new BindingList<AnswerSessionData>(lAnswerSessions);
                iResultsDGV.DataSource = lSource.Select(x => new
                {
                    Name = x.Username,
                    Score = x.Score +" points",
                    Time = x.SessionDuration +" seconds",
                    Date = x.StartTime
                }).ToList();
            }
        }

        private void iExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("Are you sure you want to exit?", "Questionnaire", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void iRestartBtn_Click(object sender, EventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("Are you sure you want to play again?", "Questionnaire", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                WelcomeView lWelcomeView = new WelcomeView();
                this.Hide();
                lWelcomeView.ShowDialog();
            }
        }
    }
}
