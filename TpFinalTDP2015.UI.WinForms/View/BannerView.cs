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

namespace TpFinalTDP2015.UI.View
{
    public partial class BannerView : Form
    {
        public BannerView()
        {
            InitializeComponent();
        }

        public void View(AdminBannerDTO pBanner)
        {
            if (pBanner == null)
            {
                throw new ArgumentNullException();
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.txtName.Text = pBanner.Name;
                this.txtDescription.Text = pBanner.Description;
                this.Text = "Banner: " + pBanner.Name;
                this.dgvIntervals.AddToSource(pBanner.ActiveIntervals.ToDTOList());
                this.dgvSources.AddToSource(pBanner.RssSources.ToDTOList());
                this.dgvTexts.AddToSource(pBanner.Texts.ToDTOList());
                this.ShowDialog();
            }
        }
    }
}
