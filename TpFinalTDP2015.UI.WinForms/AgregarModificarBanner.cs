﻿using System;
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
using TpFinalTDP2015.Service.Comparers;

namespace TpFinalTDP2015.UI
{
    public partial class AgregarModificarBanner : Form, IAddModifyViewForm
    {
        DateIntervalController dateIntervalController;
        StaticTextController staticTextController = new StaticTextController();
        RssSourcesController rssSourcesController = new RssSourcesController();

        private AdminBannerDTO iOriginalBanner = new AdminBannerDTO();

        
        public AgregarModificarBanner()
        {
            InitializeComponent();
        }

        private DateIntervalController DateIntervalController
        {
            get
            {
                return (DateIntervalController)
                    ControllerFactory.
                    Instance.
                    GetController<DateIntervalDTO>();
            }
        }

        public AdminBannerDTO Banner
        {
            get { return this.iOriginalBanner; }
        }

        void IAddModifyViewForm.Agregar(IDTO pNewBanner)
        {
            this.txtName.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.Text = "Agregar nuevo Banner";
            this.iOriginalBanner = (AdminBannerDTO)pNewBanner;
        }

        void IAddModifyViewForm.Modificar(IDTO pBanner)
        {
            if (pBanner == null)
            {
                throw new ArgumentNullException();
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.iOriginalBanner = (AdminBannerDTO)pBanner;
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
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void AgregarModificarBanner_Load(object sender, EventArgs e)
        {
            try
            {
                using (this.dateIntervalController = this.DateIntervalController)
                {
                    int i = 0;
                    IList<DateIntervalDTO> lIntervals = this.dateIntervalController.GetAll();
                    IList<StaticTextDTO> lTexts = this.staticTextController.GetStaticTexts();
                    IList<RssSourceDTO> lSources = this.rssSourcesController.GetRssSources();
                    IList<DateIntervalDTO> lBannerIntervals = this.iOriginalBanner.ActiveIntervals;
                    IList<StaticTextDTO> lBannerTexts = this.iOriginalBanner.Texts;
                    IList<RssSourceDTO> lBannerSources = this.iOriginalBanner.RssSources;

                    foreach (DateIntervalDTO lInterval in lIntervals)
                    {
                        this.chlInterval.Items.Add(lInterval.Name);
                        if (lBannerIntervals != null)
                        {
                            if (lBannerIntervals.Contains(lInterval, new DateIntervalDTOComparer()))
                            {
                                this.chlInterval.SetItemChecked(i, true);
                            }
                            i++;
                        }
                    }
                    i = 0;
                    foreach (RssSourceDTO lSource in lSources)
                    {
                        this.chlSources.Items.Add(lSource.Title);
                        if (lBannerSources != null)
                        {
                            if (lBannerSources.Contains(lSource, new RssSourceDTOComparer()))
                            {
                                this.chlSources.SetItemChecked(i, true);
                            }
                            i++;
                        }
                    }
                    i = 0;
                    foreach (StaticTextDTO lText in lTexts)
                    {
                        this.chlTexts.Items.Add(lText.Title);
                        if (lBannerTexts != null)
                        {
                            if (lBannerTexts.Contains(lText, new StaticTextDTOComparer()))
                            {
                                this.chlTexts.SetItemChecked(i, true);
                            }
                            i++;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (dateIntervalController = this.DateIntervalController)
                {
                    iOriginalBanner.ActiveIntervals = new List<DateIntervalDTO>();
                    for (int i = 0; i < this.chlInterval.Items.Count; i++)
                    {
                        if (this.chlInterval.GetItemChecked(i))
                        {
                            string lName = this.chlInterval.Items[i].ToString();
                            IEnumerable<DateIntervalDTO> query =
                                from lInterval in this.dateIntervalController.GetAll()
                                where lInterval.Name == lName
                                select lInterval;
                            foreach (DateIntervalDTO dto in query)
                            {
                                this.iOriginalBanner.ActiveIntervals.Add(dto);
                            }
                        }
                    }
                    iOriginalBanner.Texts = new List<StaticTextDTO>();
                    for (int i = 0; i < this.chlTexts.Items.Count; i++)
                    {
                        if (this.chlTexts.GetItemChecked(i))
                        {
                            string lTitle = this.chlTexts.Items[i].ToString();
                            IEnumerable<StaticTextDTO> query =
                                from lText in this.staticTextController.GetStaticTexts()
                                where lText.Title == lTitle
                                select lText;
                            foreach (StaticTextDTO dto in query)
                            {
                                this.iOriginalBanner.Texts.Add(dto);
                            }
                        }
                    }
                    iOriginalBanner.RssSources = new List<RssSourceDTO>();
                    for (int i = 0; i < this.chlSources.Items.Count; i++)
                    {
                        if (this.chlSources.GetItemChecked(i))
                        {
                            string lTitle = this.chlSources.Items[i].ToString();
                            IEnumerable<RssSourceDTO> query =
                                from lSource in this.rssSourcesController.GetRssSources()
                                where lSource.Title == lTitle
                                select lSource;
                            foreach (RssSourceDTO dto in query)
                            {
                                this.iOriginalBanner.RssSources.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
