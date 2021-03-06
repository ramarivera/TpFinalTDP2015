﻿using MarrSystems.TpFinalTDP2015.BusinessLogic.Comparers;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TpFinalTDP2015.UI.Excepciones;

namespace MarrSystems.TpFinalTDP2015.UI
{
    public partial class AgregarModificarBanner : Form, IAddModifyViewForm
    {
        ManageScheduleHandler dateIntervalController;
        ManageTextHandler staticTextController;
        ManageSourceHandler rssSourcesController;

        private AdminBannerDTO iOriginalBanner = new AdminBannerDTO();
        private readonly IControllerFactory iFactory;

        public AgregarModificarBanner(IControllerFactory pFactory)
        {
            InitializeComponent();
            this.iFactory = pFactory;
        }

        public AdminBannerDTO Banner
        {
            get { return this.iOriginalBanner; }
        }

        void IAddModifyViewForm.Add(IDTO pNewBanner)
        {
            this.txtName.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.Text = "Agregar nuevo Banner";
            this.iOriginalBanner = (AdminBannerDTO)pNewBanner;
        }

        void IAddModifyViewForm.Modify(IDTO pBanner)
        {
            if (pBanner == null)
            {
                throw new EntidadNulaException("El Banner indicado es nulo");
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
            try
            {
                if ((String.IsNullOrWhiteSpace(this.txtName.Text)))
                {
                    throw new CampoNuloOVacioException("Complete el campo 'Nombre'");
                }
                else if ((String.IsNullOrWhiteSpace(this.txtDescription.Text)))
                {
                    throw new CampoNuloOVacioException("Complete el campo 'Descripción'");
                }
                else
                {
                    this.iOriginalBanner.Name = this.txtName.Text;
                    this.iOriginalBanner.Description = this.txtDescription.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (CampoNuloOVacioException ex)
            {
                MessageBox.Show(ex.Message, "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*
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
            }*/
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
                int i = 0;
                IList<ScheduleDTO> lIntervals = this.dateIntervalController.ListSchedules();
                IList<StaticTextDTO> lTexts = this.staticTextController.ListTexts();
                IList<RssSourceDTO> lSources = this.rssSourcesController.ListSources();
                IList<ScheduleDTO> lBannerIntervals = this.iOriginalBanner.ActiveIntervals;
                IList<StaticTextDTO> lBannerTexts = this.iOriginalBanner.Texts;
                IList<RssSourceDTO> lBannerSources = this.iOriginalBanner.RssSources;

                foreach (ScheduleDTO lInterval in lIntervals)
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
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                iOriginalBanner.ActiveIntervals = new List<ScheduleDTO>();
                for (int i = 0; i < this.chlInterval.Items.Count; i++)
                {
                    if (this.chlInterval.GetItemChecked(i))
                    {
                        string lName = this.chlInterval.Items[i].ToString();
                        IEnumerable<ScheduleDTO> query =
                            from lInterval in this.dateIntervalController.ListSchedules()
                            where lInterval.Name == lName
                            select lInterval;
                        foreach (ScheduleDTO dto in query)
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
                            from lText in this.staticTextController.ListTexts()
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
                            from lSource in this.rssSourcesController.ListSources()
                            where lSource.Title == lTitle
                            select lSource;
                        foreach (RssSourceDTO dto in query)
                        {
                            this.iOriginalBanner.RssSources.Add(dto);
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
