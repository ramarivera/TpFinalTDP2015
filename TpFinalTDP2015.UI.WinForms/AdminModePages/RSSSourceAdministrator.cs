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
using TpFinalTDP2015.Service.Controllers;

namespace TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Fuentes RSS")]
    public partial class RSSSourceAdministrator : AdminModePage
    {
        RssSourcesController iController = new RssSourcesController();

        RssSourceDTO rssSource;
        public RSSSourceAdministrator(): base()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.rssSource = new RssSourceDTO();
            AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
            this.dgvRSSSource.Agregar(ventana,this.rssSource);
            iController.SaveRssSource(this.rssSource);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            List<IDTO> fuentesAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvRSSSource.SelectedRows)
            {
                fuentesAEliminar.Add((RssSourceDTO)dgvRSSSource.GetItem(row.Index));
            }
            if (fuentesAEliminar.Count == 0)
            {
                MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.dgvRSSSource.Eliminar(fuentesAEliminar);
                foreach (IDTO source in fuentesAEliminar)
                {
                    iController.DeleteRssSource((RssSourceDTO)source);
                }
            }
        }

        private void dgvRSSSource_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvRSSSource.CurrentRow;
            this.rssSource = (RssSourceDTO)dgvRSSSource.GetItem(row.Index);
            AgregarModificarFuenteRSS ventana = new AgregarModificarFuenteRSS();
            this.dgvRSSSource.Modificar(ventana, this.rssSource);
            iController.SaveRssSource(this.rssSource);
        }

        private void RSSSourceAdministrator_Load(object sender, EventArgs e)
        {
            IList<RssSourceDTO> lList = this.iController.GetRssSources();
            this.dgvRSSSource.AddToSource(lList.ToDTOList());
        }
    }
}
