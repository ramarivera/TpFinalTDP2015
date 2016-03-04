using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.UI.View
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

        private void dgvIntervals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvIntervals.CurrentRow;
            DateIntervalDTO lInterval = (DateIntervalDTO)dgvIntervals.GetItem(row.Index);
            DateIntervalView ventana = new DateIntervalView();
            ventana.View(lInterval);
        }

        private void dgvTexts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTexts.CurrentRow;
            StaticTextDTO lText = (StaticTextDTO)dgvTexts.GetItem(row.Index);
            StaticTextView ventana = new StaticTextView();
            ventana.View(lText);
        }

        private void dgvSources_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSources.CurrentRow;
            RssSourceDTO lSource = (RssSourceDTO)dgvSources.GetItem(row.Index);
            RssSourceView ventana = new RssSourceView();
            ventana.View(lSource);
        }
    }
}
