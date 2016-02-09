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
    [AdminModePageInfo(Name = "Administrador de Campañas")]
    public partial class CampaignAdministrator : AdminModePage
    {
        CampaignController iController = new CampaignController();

        CampaignDTO campaign;
        public CampaignAdministrator() : base()
        {
            InitializeComponent();
            this.Load += CampaignAdministrator_Load;
        }

        private void CampaignAdministrator_Load(object sender, EventArgs e)
        {
            IList<CampaignDTO> lList = this.iController.GetCampaigns();
            this.dgvCampaign.AddToSource(lList.ToDTOList());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            campaign = new CampaignDTO();
            AgregarModificarCampaña ventana = new AgregarModificarCampaña();
            this.dgvCampaign.Agregar(ventana,campaign);
            iController.SaveCampaign(this.campaign);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<IDTO> campañasAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvCampaign.SelectedRows)
            {
                campañasAEliminar.Add((CampaignDTO)row.DataBoundItem);
            }
            if (campañasAEliminar.Count == 0)
            {
                MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.dgvCampaign.Eliminar(campañasAEliminar);
                foreach (IDTO campaign in campañasAEliminar)
                {
                    iController.DeleteCampaign((CampaignDTO)campaign);
                }
            }
            
        }

        private void dgvCampaign_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCampaign.CurrentRow;
            this.campaign = (CampaignDTO)dgvCampaign.GetItem(row.Index);
            AgregarModificarCampaña ventana = new AgregarModificarCampaña();
            this.dgvCampaign.Modificar(ventana, this.campaign);
            iController.SaveCampaign(this.campaign);
        }
    }
}
