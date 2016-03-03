using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.BusinessLogic.DTO;
using TpFinalTDP2015.BusinessLogic.Services;
using TpFinalTDP2015.UI.View;

namespace TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Fuentes RSS")]
    public partial class RSSSourceAdministrator : AdminModePage
    {
        RssSourceService iController;

        RssSourceDTO rssSource;
        public RSSSourceAdministrator(): base()
        {
            InitializeComponent();
        }

        private RssSourceService Controller
        {
            get
            {
                return (RssSourceService)
                    ServiceFactory.
                    GetService<RssSourceDTO>();
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
                    this.dgvRSSSource.Agregar(ventana, this.rssSource);
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
                            iController.Delete((RssSourceDTO)source);
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
                    this.rssSource = (RssSourceDTO)dgvRSSSource.GetItem(row.Index);
                    AgregarModificarFuenteRSS ventana = new AgregarModificarFuenteRSS();
                    this.dgvRSSSource.Modificar(ventana, this.rssSource);
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
                    IList<RssSourceDTO> lList = this.iController.GetAll();
                    this.dgvRSSSource.AddToSource(lList.ToDTOList());
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
            this.rssSource = (RssSourceDTO)dgvRSSSource.GetItem(row.Index);
            RssSourceView ventana = new RssSourceView();
            ventana.View(this.rssSource);
        }
    }
}
