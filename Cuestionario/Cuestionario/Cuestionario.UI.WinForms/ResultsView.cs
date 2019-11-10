﻿using Cuestionario.Services.DTO;
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

namespace Cuestionario.UI.WinForms
{
    public partial class ResultsView : Form
    {
        public ResultsView()//int pAnswerSessionId)
        {
            InitializeComponent();

            using (var lHandler = HandlerFactory.Get<IAnswerSessionHandler>())
            {
                IList<AnswerSessionData> lAnswerSessions = lHandler.GetAll()
                    .OrderByDescending(x => x.Score).ToList();

                // falta limitar que sean 20
                var lSource = new BindingList<AnswerSessionData>(lAnswerSessions);
                iResultsDGV.DataSource = lSource.Select(x => new
                {
                    Nombre = x.Username,
                    Puntaje = x.Score +" puntos",
                    Tiempo = x.AnswerTime +" segundos",
                    Fecha = x.Date
                }).ToList();
            }
        }

        private void iExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("¿Está seguro que desea salir?", "Cuestionario", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void iRestartBtn_Click(object sender, EventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("¿Está seguro que desea reiniciar el Cuestionario?", "Cuestionario", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                WelcomeView lWelcomeView = new WelcomeView();
                this.Hide();
                lWelcomeView.ShowDialog();
            }
        }
    }
}
