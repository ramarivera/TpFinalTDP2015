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
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.UI.View;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Banners")]
    public partial class BannerAdministrator : AdminModePage
    {
        ManageBannerHandler iController;
        private GenericDGV<AdminBannerDTO> dgvBanner;
                  

        public BannerAdministrator(IControllerFactory pFactory): base(pFactory)
        {
            InitializeComponent();
            this.Load += BannerAdministrator_Load;
        }

        private void BannerAdministrator_Load(object sender, EventArgs e)
        {
            this.CargarDataGrid();
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDelete.Click += BtnDelete_Click;
        }

        [Log]
        private void CargarDataGrid()
        {
            try
            {
                this.dgvBanner.SetSource(this.iController.ListBanner());
            }
            catch (Exception)
            {

                throw;
            }
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
            this.dgvBanner.Delete(bannersAEliminar);*/
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
                this.dgvBanner.Delete(bannerAEliminar);
                foreach (IDTO banner in bannerAEliminar)
                {
                    iController.DeleteBanner((BannerDTO)banner);
                }
            }*/
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                    AdminBannerDTO banner = new AdminBannerDTO();
                    AgregarModificarBanner ventana = new AgregarModificarBanner();
                    this.dgvBanner.Add(ventana, banner);
                    iController.AddBanner(banner);
                    this.CargarDataGrid();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvBanner_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvBanner.CurrentRow;
                AdminBannerDTO banner = (AdminBannerDTO)dgvBanner.GetItem(row.Index);
                AgregarModificarBanner ventana = new AgregarModificarBanner();
                this.dgvBanner.Modify(ventana, banner);
                iController.ModifyBanner(banner);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvBanner.CurrentRow;
            AdminBannerDTO banner = (AdminBannerDTO)dgvBanner.GetItem(row.Index);
            BannerView ventana = new BannerView();
            ventana.View(banner);
        }
    }
}
