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
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Campañas")]
    public partial class CampaignAdministrator : AdminModePage
    {
        private ManageCampaignHandler iController;
        private GenericDGV<CampaignDTO> dgvCampaign;


        public CampaignAdministrator(IControllerFactory pFactory) : base(pFactory)
        {
            InitializeComponent();
            this.iController = pFactory.GetController<ManageCampaignHandler>();
            this.Load += CampaignAdministrator_Load;
        }

        private void CampaignAdministrator_Load(object sender, EventArgs e)
        {
            this.CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            try
            {
                this.dgvCampaign.SetSource(this.iController.ListCampaign());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CampaignDTO campaign = new CampaignDTO();
                AgregarModificarCampaña ventana = new AgregarModificarCampaña(this.iFactory);
                if (this.dgvCampaign.Add(ventana, campaign))
                {
                    iController.AddCampaign(campaign);
                    this.CargarDataGrid();
                }
            }
            catch (Exception)
            {

                throw;
            }   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                IList<CampaignDTO> campañasAEliminar = new List<CampaignDTO>();
                foreach (DataGridViewRow row in this.dgvCampaign.SelectedRows)
                {
                    campañasAEliminar.Add(dgvCampaign.GetItem(row.Index));
                }
                if (campañasAEliminar.Count == 0)
                {
                    MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.dgvCampaign.Delete(campañasAEliminar);
                    foreach (var campaign in campañasAEliminar)
                    {
                        iController.DeleteCampaign(campaign);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void dgvCampaign_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCampaign.CurrentRow;
            CampaignDTO campaign = (CampaignDTO)dgvCampaign.GetItem(row.Index);
            AgregarModificarCampaña ventana = new AgregarModificarCampaña(this.iFactory);
            this.dgvCampaign.Modify(ventana, campaign);
            iController.ModifyCampaign(campaign);
        }
    }
}
