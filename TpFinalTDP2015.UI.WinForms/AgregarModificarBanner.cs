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
    public partial class AgregarModificarBanner : BaseForm, IAddModifyViewForm
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

        void IAddModifyViewForm.Agregar(IDTO pNewBanner)
        {
            this.txtName.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.Text = "Agregar nuevo Banner";
            this.iOriginalBanner = (BannerDTO)pNewBanner;
        }

        void IAddModifyViewForm.Modificar(IDTO pBanner)
        {
            this.iOriginalBanner = (BannerDTO)pBanner;
            this.txtName.Text = iOriginalBanner.Name;
            this.txtDescription.Text = iOriginalBanner.Description;
            this.Text = "Modificar Banner";
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }
    }
}
