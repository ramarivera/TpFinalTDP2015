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
            AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
            this.dgvRSSSource.Agregar(ventana,rssSource);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvRSSSource.SelectedRows)
            {
                RssSourceDTO rssSource = ((RssSourceDTO)row.DataBoundItem);
                this.dgvRSSSource.Eliminar(rssSource);
            }
        }

        private void dgvRSSSource_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvRSSSource.CurrentRow;
            this.rssSource = (RssSourceDTO)row.Tag;//this.iBinding.Single<Persona>(p => p.PersonaId == (int)row.Tag);
            AgregarModificarFuenteRSS ventana = new AgregarModificarFuenteRSS();
            this.dgvRSSSource.Modificar(ventana, rssSource);
        }
    }
}
