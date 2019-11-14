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
    public partial class StartUpView : Form
    {
        public StartUpView()
        {
            InitializeComponent();
        }

        private void iPlayBtn_Click(object sender, EventArgs e)
        {
            WelcomeView lWelcomeView = new WelcomeView();
            this.Hide();
            lWelcomeView.ShowDialog();
        }

        private void StartUpView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult lDialogResult = MessageBox.Show("¿Está seguro que desea salir?", "Questionnaire", MessageBoxButtons.YesNo);
            if (lDialogResult == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void iAdminBtn_Click(object sender, EventArgs e)
        {
            AdministratorView lAdministratorView = new AdministratorView();
            this.Hide();
            lAdministratorView.ShowDialog();
        }
    }
}
