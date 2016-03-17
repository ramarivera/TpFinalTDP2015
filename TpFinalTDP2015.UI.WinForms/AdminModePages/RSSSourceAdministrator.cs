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
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using TpFinalTDP2015.UI.Excepciones;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Fuentes RSS")]
    public partial class RSSSourceAdministrator : AdminModePage
    {
        private ManageSourceHandler iController = new ManageSourceHandler();
        private GenericDGV<RssSourceDTO> dgvRSSSource;

        public RSSSourceAdministrator(): base()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var lRssSource = new RssSourceDTO();
                    AgregarModificarFuenteRSS ventana = new AgregarModificarFuenteRSS();
                    this.dgvRSSSource.Add(ventana, lRssSource);
                    iController.AddSource(lRssSource);
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
                        foreach (var source in fuentesAEliminar)
                        {
                            iController.DeleteSource(source);
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
                    DataGridViewRow row = dgvRSSSource.CurrentRow;
                    var lRssSource = dgvRSSSource.GetItem(row.Index);
                    AgregarModificarFuenteRSS ventana = new AgregarModificarFuenteRSS();
                    this.dgvRSSSource.Modify(ventana, lRssSource);
                    iController.ModifySource(lRssSource);
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
                    this.dgvRSSSource.SetSource(this.iController.ListSources());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvRSSSource.CurrentRow;
                var lRssSource = dgvRSSSource.GetItem(row.Index);
                RssSourceView ventana = new RssSourceView();
                ventana.View(lRssSource);
            }
            catch (EntidadNulaException ex)
            {
                MessageBox.Show(ex.Message, "Entidad nula", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
