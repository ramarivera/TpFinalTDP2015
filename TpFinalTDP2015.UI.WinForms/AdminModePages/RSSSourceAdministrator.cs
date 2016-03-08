using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.UI.View;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Fuentes RSS")]
    public partial class RSSSourceAdministrator : AdminModePage
    {
        RssSourceService iController;
        private GenericDGV<RssSourceDTO> dgvRSSSource;


        RssSourceDTO rssSource;
        public RSSSourceAdministrator(): base()
        {
            InitializeComponent();
        }

        private RssSourceService Controller
        {
            get
            {
                return 
                    BusinessServiceLocator.
                    Resolve<RssSourceService>();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (iController = this.Controller)
                {
                    this.rssSource = new RssSourceDTO();
                    AgregarModificarFuenteRSS ventana = new AgregarModificarFuenteRSS();
                    this.dgvRSSSource.Add(ventana, this.rssSource);
                    iController.Save(this.rssSource);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (iController = this.Controller)
                {
                    IList<RssSourceDTO> fuentesAEliminar = new List<RssSourceDTO>();
                    foreach (DataGridViewRow row in this.dgvRSSSource.SelectedRows)
                    {
                        fuentesAEliminar.Add(dgvRSSSource.GetItem(row.Index));
                    }
                    if (fuentesAEliminar.Count == 0)
                    {
                        MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.dgvRSSSource.Delete(fuentesAEliminar);
                        foreach (RssSourceDTO source in fuentesAEliminar)
                        {
                            iController.Delete(source);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvRSSSource_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (iController = this.Controller)
                {
                    DataGridViewRow row = dgvRSSSource.CurrentRow;
                    this.rssSource = dgvRSSSource.GetItem(row.Index);
                    AgregarModificarFuenteRSS ventana = new AgregarModificarFuenteRSS();
                    this.dgvRSSSource.Modify(ventana, this.rssSource);
                    iController.Save(this.rssSource);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void RSSSourceAdministrator_Load(object sender, EventArgs e)
        {
            this.CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            try
            {
                using (iController = this.Controller)
                {
                    this.dgvRSSSource.SetSource(this.iController.GetAll());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvRSSSource.CurrentRow;
            this.rssSource = dgvRSSSource.GetItem(row.Index);
            RssSourceView ventana = new RssSourceView();
            ventana.View(this.rssSource);
        }
    }
}
