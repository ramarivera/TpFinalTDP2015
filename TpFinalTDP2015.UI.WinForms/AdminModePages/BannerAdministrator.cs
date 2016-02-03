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

namespace TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Banners")]
    public partial class BannerAdministrator : AdminModePage
    {
        BannerDTO banner;

        public BannerAdministrator(): base()
        {
            InitializeComponent();
            this.Load += BannerAdministrator_Load;
        }

        private void BannerAdministrator_Load(object sender, EventArgs e)
        {
            //TODO obtener lo que está en la base de datos como una lista mediante fachada
            this.banner = new BannerDTO { Name = "Mañana", Description = "banner de la mañana" };
            List<IDTO> elements = new List<IDTO>() { this.banner };
            this.dgvBanner.AddToSource(elements);
            //this.dgvBanner.iSource.Add(this.banner);
            //this.dgvBanner.DataSource = this.dgvBanner.iSource;
            this.dgvBanner.Rows[this.dgvBanner.RowCount - 1].Tag = this.banner;
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
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.banner = new BannerDTO();
            AgregarModificarBanner ventana = new AgregarModificarBanner();
            this.dgvBanner.Agregar(ventana, banner);
            //TODO falta guardarlo en la base de datos
        }

        private void dgvBanner_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBanner.CurrentRow;
            this.banner = (BannerDTO)row.Tag;
            AgregarModificarBanner ventana = new AgregarModificarBanner();
            this.dgvBanner.Modificar(ventana, banner);
        }

    }
}
