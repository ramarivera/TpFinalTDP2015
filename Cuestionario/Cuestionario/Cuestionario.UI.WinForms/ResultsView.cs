﻿using Questionnaire.Services.DTO;
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
    public partial class ResultsView : Form
    {
        public ResultsView(int pAnswerSessionId)
        {
            InitializeComponent();

            using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
            {
                AnswerSessionData lAnswerSession = lHandler.GetById(pAnswerSessionId);
                this.iScoreLbl.Text = String.Format("Puntaje: {0} puntos", lAnswerSession.Score);
                this.iTimeLbl.Text = String.Format("Tiempo de respuesta: {0} segundos", lAnswerSession.SessionDuration);

                IList<AnswerSessionData> lAnswerSessions = lHandler.GetAll()
                    .OrderByDescending(x => x.Score).ToList();

                // TODO falta limitar que sean 20
                var lSource = new BindingList<AnswerSessionData>(lAnswerSessions);
                iResultsDGV.DataSource = lSource.Select(x => new
                {
                    Nombre = x.Username,
                    Puntaje = x.Score +" puntos",
                    Tiempo = x.SessionDuration +" segundos",
                    Fecha = x.StartTime
                }).ToList();
            }
        }

        private void iExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("¿Está seguro que desea salir?", "Questionnaire", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void iRestartBtn_Click(object sender, EventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("¿Está seguro que desea reiniciar el Questionnaire?", "Questionnaire", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                WelcomeView lWelcomeView = new WelcomeView();
                this.Hide();
                lWelcomeView.ShowDialog();
            }
        }
    }
}
