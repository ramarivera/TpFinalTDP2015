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
using TpFinalTDP2015.Service.Controllers;

namespace TpFinalTDP2015.UI
{
    public partial class AgregarModificarBanner : Form, IAddModifyViewForm
    {
        DateIntervalController dateIntervalController = new DateIntervalController();
        StaticTextController staticTextController = new StaticTextController();
        RssSourcesController rssSourcesController = new RssSourcesController();

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
            if (pBanner == null)
            {
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.iOriginalBanner = (BannerDTO)pBanner;
                this.txtName.Text = iOriginalBanner.Name;
                this.txtDescription.Text = iOriginalBanner.Description;
                this.Text = "Modificar Banner";
            }  
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrWhiteSpace(this.txtName.Text)))
            {
                MessageBox.Show("Complete el campo 'Nombre'","Faltan datos",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if ((String.IsNullOrWhiteSpace(this.txtDescription.Text)))
            {
                MessageBox.Show("Complete el campo 'Descripción'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.iOriginalBanner.Name = this.txtName.Text;
                this.iOriginalBanner.Description = this.txtDescription.Text;
                //  this.iCampañaOriginal.Duration = int.Parse(this.txtDuration.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show(
                                        "¿Desea salir sin guardar los cambios?",
                                        "Salir",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
            switch (opcion)
            {
                case DialogResult.Yes:
                    this.DialogResult = DialogResult.No;
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void AgregarModificarBanner_Load(object sender, EventArgs e)
        {
            //levanto las listas de la base de datos y las listas del banner, obtengo los nombres de una
            IList<DateIntervalDTO> lIntervals = this.dateIntervalController.GetDateIntervals();
            IList<StaticTextDTO> lTexts = this.staticTextController.GetStaticTexts();
            IList<RssSourceDTO> lSources = this.rssSourcesController.GetRssSources();
            IList<DateIntervalDTO> lBannerIntervals = this.iOriginalBanner.ActiveIntervals;
            //IList<StaticTextDTO> lBannerTexts = this.iOriginalBanner.Items.t
            IList<RssSourceDTO> lBannerSources = this.iOriginalBanner.RssSources;

            foreach (DateIntervalDTO lInterval in lIntervals)
            {
                int i = 0;
                this.chlInterval.Items.Add(lInterval.Name);
                if (lBannerIntervals != null)
                {
                    if (lBannerIntervals.Contains(lInterval))
                    {
                        this.chlInterval.SetItemChecked(i, true);
                    }
                    i++;
                }
            }
            foreach (RssSourceDTO lSource in lSources)
            {
                int i = 0;
                this.chlSources.Items.Add(lSource.Title);
                if(lBannerSources != null)
                {
                    if (lBannerSources.Contains(lSource))
                    {
                        this.chlSources.SetItemChecked(i, true);
                    }
                    i++;
                }
            }
            foreach (StaticTextDTO lText in lTexts)
            {
                int i = 0;
                this.chlTexts.Items.Add(lText.Title);
                /*if (lBannerSources.Contains(lSource))
                {
                    this.chlSources.SetItemChecked(i, true);
                }*/
                //TODO como obtener solos los textos del banner
                i++;
            }
        }
    }
}
