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

namespace TpFinalTDP2015.UI
{
    public partial class AgregarModificarCampaña : BaseForm, IAddModifyViewForm
    {
        private CampaignDTO iOriginalCampaign;

        public CampaignDTO Campaign
        {
            get { return this.iOriginalCampaign; }
        }
        public AgregarModificarCampaña()
        {
            InitializeComponent();
        }

        void IAddModifyViewForm.Agregar(IDTO pNewCampaign)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtDuration.Text = String.Empty;
            this.Text = "Agregar nueva Campaña";
            this.iOriginalCampaign = (CampaignDTO)pNewCampaign;
        }

        void IAddModifyViewForm.Modificar(IDTO pCampaign)
        {
            this.iOriginalCampaign = (CampaignDTO)pCampaign;
            this.txtTitle.Text = iOriginalCampaign.Name;
            this.txtDescription.Text = iOriginalCampaign.Description;
           // this.txtDuration.Text = pCampaña.Duration.ToString();
            this.Text = "Modificar Campaña";
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.iOriginalCampaign.Name = this.txtTitle.Text;
            this.iOriginalCampaign.Description = this.txtDescription.Text;
          //  this.iCampañaOriginal.Duration = int.Parse(this.txtDuration.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show(
                                        "¿Desea salir sin guardar los cambios?",
                                        "Salir",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
            switch (opcion)
            {
                case DialogResult.Yes:
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {

        }
    }
}
