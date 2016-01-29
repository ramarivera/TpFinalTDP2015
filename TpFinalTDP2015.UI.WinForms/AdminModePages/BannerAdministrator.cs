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
    [AdminModePageInfo(Name = "Administrador de Banners")]
    public partial class BannerAdministrator : AdminModePage
    {
        BannerDTO banner;

        public BannerAdministrator(): base()
        {
            InitializeComponent();
            //TODO obtener lo que está en la base de datos como una lista mediante fachada
            this.banner = new BannerDTO { Name = "Mañana", Description = "banner de la mañana" };
            this.dgvBanner.iSource.Add(this.banner);
            this.dgvBanner.DataSource = this.dgvBanner.iSource;
            this.dgvBanner.Rows[this.dgvBanner.RowCount-2].Tag = this.banner;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvBanner.SelectedRows)
            {
                banner = ((BannerDTO)row.DataBoundItem);
                this.dgvBanner.Eliminar(banner);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.banner = new BannerDTO();
            AgregarModificarBanner ventana = new AgregarModificarBanner();
            this.dgvBanner.Agregar(ventana, banner);
        }
       
        private void dgvBanner_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBanner.CurrentRow;
            this.banner = (BannerDTO)row.Tag;//this.iBinding.Single<Persona>(p => p.PersonaId == (int)row.Tag);
            AgregarModificarBanner ventana = new AgregarModificarBanner();
            this.dgvBanner.Modificar(ventana, banner);
        }

    }
}
