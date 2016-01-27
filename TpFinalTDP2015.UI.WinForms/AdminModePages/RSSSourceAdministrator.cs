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
    [AdminModePageInfo(Name = "Administrador de Fuentes RSS")]
    public partial class RSSSourceAdministrator : AdminModePage
    {
        RssSourceDTO rssSource;
        public RSSSourceAdministrator(): base()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            rssSource = new RssSourceDTO();
            AgregarModificarTextoFijoRSS ventana = new AgregarModificarTextoFijoRSS();
            ventana.AgregarFuenteRSS(rssSource);
            DialogResult resultado = ventana.ShowDialog();
            if (resultado == DialogResult.OK)
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvRSSSource.SelectedRows)
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
