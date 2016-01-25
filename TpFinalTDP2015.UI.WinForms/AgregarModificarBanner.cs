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

namespace TpFinalTDP2015.UI
{
    public partial class AgregarModificarBanner: BaseForm
    {
        private BannerDTO iOriginalBanner;

        public BannerDTO Banner
        {
            get { return this.iOriginalBanner; }
        }
        public AgregarModificarBanner()
        {
            InitializeComponent();
        }

        public void AgregarBanner(BannerDTO pNewBanner)
        {
            this.txtName.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.Text = "Agregar nuevo Banner";
            this.iOriginalBanner = pNewBanner;
        }

        public void ModificarBanner(BannerDTO pBanner)
        {
            this.txtName.Text = pBanner.Name;
            this.txtDescription.Text = pBanner.Description;
            this.Text = "Modificar Banner";
            this.iOriginalBanner = pBanner;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }
    }
}
