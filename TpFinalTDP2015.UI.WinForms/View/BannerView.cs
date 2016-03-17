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
using TpFinalTDP2015.UI.Excepciones;

namespace MarrSystems.TpFinalTDP2015.UI.View
{
    public partial class BannerView : Form
    {
        private AdminModePages.GenericDGV<ScheduleDTO> dgvIntervals;
        private AdminModePages.GenericDGV<StaticTextDTO> dgvTexts;
        private AdminModePages.GenericDGV<RssSourceDTO> dgvSources;

        public BannerView()
        {
            InitializeComponent();
        }

        public void View(AdminBannerDTO pBanner)
        {
            if (pBanner == null)
            {
                throw new EntidadNulaException("El Banner indicado es nulo");
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.txtName.Text = pBanner.Name;
                this.txtDescription.Text = pBanner.Description;
                this.Text = "Banner: " + pBanner.Name;
                this.dgvIntervals.SetSource(pBanner.ActiveIntervals);
                this.dgvSources.SetSource(pBanner.RssSources);
                this.dgvTexts.SetSource(pBanner.Texts);
                this.ShowDialog();
            }
        }

        private void dgvIntervals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvIntervals.CurrentRow;
            ScheduleDTO lInterval = (ScheduleDTO)dgvIntervals.GetItem(row.Index);
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
