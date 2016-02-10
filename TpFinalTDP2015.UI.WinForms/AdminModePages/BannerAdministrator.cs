using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Service.Controllers;

namespace TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Banners")]
    public partial class BannerAdministrator : AdminModePage
    {
        AdminBannerDTO banner;

        BannerController iController = new BannerController();

        public BannerAdministrator(): base()
        {
            InitializeComponent();
            this.Load += BannerAdministrator_Load;
        }

        private void BannerAdministrator_Load(object sender, EventArgs e)
        {
            IList<AdminBannerDTO> lList = this.iController.GetBanners();
            this.dgvBanner.AddToSource(lList.ToDTOList());
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Debugger.Break();
            /*
            //TODO verificar lista no vacia
            if (dgvBanner.SelectedRows.Count == 0)
            {
                 //TODO Quitar referencias a Diagnostics
            }
            List<IDTO> bannersAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvBanner.SelectedRows)
            {
                bannersAEliminar.Add((BannerDTO)row.DataBoundItem);
            }
            this.dgvBanner.Eliminar(bannersAEliminar);*/
            /*List<IDTO> bannersAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvBanner.SelectedRows)
            {
                bannerAEliminar.Add((BannerDTO)dgvBanner.GetItem(row.Index));
            }
            if (bannerAEliminar.Count == 0)
            {
                MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.dgvBanner.Eliminar(bannerAEliminar);
                foreach (IDTO banner in bannerAEliminar)
                {
                    iController.DeleteBanner((BannerDTO)banner);
                }
            }*/
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.banner = new AdminBannerDTO();
            AgregarModificarBanner ventana = new AgregarModificarBanner();
            this.dgvBanner.Agregar(ventana, banner);
            iController.SaveBanner(this.banner);
        }

        private void dgvBanner_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBanner.CurrentRow;
            this.banner = (AdminBannerDTO)dgvBanner.GetItem(row.Index);
            AgregarModificarBanner ventana = new AgregarModificarBanner();
            this.dgvBanner.Modificar(ventana, this.banner);
            iController.SaveBanner(this.banner);
        }
    }
}
