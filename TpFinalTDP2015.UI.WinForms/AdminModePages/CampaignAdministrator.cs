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

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Campañas")]
    public partial class CampaignAdministrator : AdminModePage
    {
        private CampaignService iController = new CampaignService();
        private GenericDGV<CampaignDTO> dgvCampaign;


        CampaignDTO campaign;
        public CampaignAdministrator() : base()
        {
           
            InitializeComponent();
            this.Load += CampaignAdministrator_Load;
        }

        private void CampaignAdministrator_Load(object sender, EventArgs e)
        {
            this.CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            IList<CampaignDTO> lList = this.iController.GetCampaigns();
            this.dgvCampaign.SetSource(lList);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            campaign = new CampaignDTO();
            AgregarModificarCampaña ventana = new AgregarModificarCampaña();
            this.dgvCampaign.Add(ventana,campaign);
            iController.SaveCampaign(this.campaign);
            this.CargarDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<CampaignDTO> campañasAEliminar = new List<CampaignDTO>();
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
                foreach (CampaignDTO campaign in campañasAEliminar)
                {
                    iController.DeleteCampaign(campaign);
                }
            }
            
        }

        private void dgvCampaign_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCampaign.CurrentRow;
            this.campaign = (CampaignDTO)dgvCampaign.GetItem(row.Index);
            AgregarModificarCampaña ventana = new AgregarModificarCampaña();
            this.dgvCampaign.Modify(ventana, this.campaign);
            iController.SaveCampaign(this.campaign);
        }
    }
}
