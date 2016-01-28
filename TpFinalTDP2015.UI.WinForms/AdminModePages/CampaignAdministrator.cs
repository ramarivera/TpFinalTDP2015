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
    [AdminModePageInfo(Name = "Administrador de Campañas")]
    public partial class CampaignAdministrator : AdminModePage
    {
        CampaignDTO campaign;
        public CampaignAdministrator() : base()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            campaign = new CampaignDTO();
            AgregarModificarCampaña ventana = new AgregarModificarCampaña();
            this.dgvCampaign.Agregar(ventana,campaign);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvCampaign.SelectedRows)
            {
                campaign = ((CampaignDTO)row.DataBoundItem);
                this.dgvCampaign.Eliminar(campaign);
            }
        }

        private void dgvCampaign_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCampaign.CurrentRow;
            this.campaign = (CampaignDTO)row.Tag;//this.iBinding.Single<Persona>(p => p.PersonaId == (int)row.Tag);
            AgregarModificarCampaña ventana = new AgregarModificarCampaña();
            this.dgvCampaign.Modificar(ventana, campaign);
        }
    }
}
