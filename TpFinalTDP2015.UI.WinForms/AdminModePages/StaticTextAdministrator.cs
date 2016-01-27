using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Textos Fijos")]
    public partial class StaticTextAdministrator : AdminModePage
    {
        StaticTextDTO staticText;
        public StaticTextAdministrator(): base()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            staticText = new StaticTextDTO();
            AgregarModificarTextoFijoRSS ventana = new AgregarModificarTextoFijoRSS();
            ventana.AgregarTextoFijo(staticText);
            DialogResult resultado = ventana.ShowDialog();
            if (resultado == DialogResult.OK)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvStaticText.SelectedRows)
            {
                RssSourceDTO rssSource = ((RssSourceDTO)row.DataBoundItem);
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar la fuente RSS " + rssSource.Title + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (resultado)
                {
                    case DialogResult.Yes:
                        //this.iFachada.Delete(persona);
                        //this.iBinding.Remove(persona);
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
    }
}
