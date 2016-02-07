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
            //TODO obtener lo que está en la base de datos como una lista mediante fachada y guardar en iSource
            
           // this.dgvCampaign.DataSource = this.dgvCampaign.iSource;
        }

        private void CampaignAdministrator_Load(object sender, EventArgs e)
        {
            IList<CampaignDTO> lList = this.iController.GetCampaigns();
            foreach (var dto in lList)
            {
                this.dgvCampaign.iSource.Add(dto);
            }
            this.dgvCampaign.DataSource = this.dgvCampaign.iSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            campaign = new CampaignDTO();
            AgregarModificarCampaña ventana = new AgregarModificarCampaña();
            this.dgvCampaign.Agregar(ventana,campaign);
            // TODO guardar en base de datos
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //TODO verificar lista no vacia
            List<IDTO> campañasAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvCampaign.SelectedRows)
            {
                campañasAEliminar.Add((CampaignDTO)row.DataBoundItem);
            }
            this.dgvCampaign.Eliminar(campañasAEliminar);
        }

        private void dgvCampaign_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCampaign.CurrentRow;
            this.campaign = (CampaignDTO)row.Tag;
            AgregarModificarCampaña ventana = new AgregarModificarCampaña();
            this.dgvCampaign.Modificar(ventana, campaign);
        }
    }
}
