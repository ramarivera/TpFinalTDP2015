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
            ventana.AgregarCampaña(campaign);
            DialogResult resultado = ventana.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvCampaign.SelectedRows)
            {
                CampaignDTO campaign = ((CampaignDTO)row.DataBoundItem);
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar la campaña " + campaign.Name + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (resultado)
                {
                    case DialogResult.Yes:
                        //this.iFachada.Delete(persona);
                        //this.iBinding.Remove(persona);
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
    }
}
