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
        //private ManageSourceHandler iController;
        private GenericDGV<RssSourceDTO> dgvRSSSource;

        public RSSSourceAdministrator(IControllerFactory pFactory) : base(pFactory)
        {
            InitializeComponent();
            //this.iController = pFactory.GetController<ManageSourceHandler>();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageSourceHandler>())
                    {
                        RssSourceDTO lRssSource = new RssSourceDTO();
                        AgregarModificarFuenteRSS ventana = new AgregarModificarFuenteRSS(this.iFactory);
                        if (this.dgvRSSSource.Add(ventana, lRssSource))
                        {
                            controller.AddSource(lRssSource);
                            this.CargarDataGrid();
                        }
                        
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
                using (var controller = this.iFactory.GetController<ManageSourceHandler>())
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
                            controller.DeleteSource(source);
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
                using (var controller = this.iFactory.GetController<ManageSourceHandler>())
                {
                    DataGridViewRow row = dgvRSSSource.CurrentRow;
                    RssSourceDTO lRssSource = dgvRSSSource.GetItem(row.Index);
                    AgregarModificarFuenteRSS ventana = new AgregarModificarFuenteRSS(this.iFactory);
                    if (this.dgvRSSSource.Modify(ventana, lRssSource))
                    {
                        controller.ModifySource(lRssSource);
                        this.CargarDataGrid();
                    }
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void RSSSourceAdministrator_Load(object sender, EventArgs e)
        {
            this.ConfigurarGrillas();
            this.CargarDataGrid();
        }

        private void ConfigurarGrillas()
        {
            this.dgvRSSSource.AddColumn(x => x.Title, "Titulo");
            this.dgvRSSSource.AddColumn(x => x.Description, "Descripcion");
            this.dgvRSSSource.AddColumn(x => x.URL, "URL");
        }

        private void CargarDataGrid()
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageSourceHandler>())
                {
                    this.dgvRSSSource.SetSource(controller.ListSources());
                }
                   
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
