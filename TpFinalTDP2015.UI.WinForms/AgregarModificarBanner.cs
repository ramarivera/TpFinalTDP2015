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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.iOriginalBanner.Name = this.txtName.Text;
            this.iOriginalBanner.Description = this.txtDescription.Text;
            //  this.iCampañaOriginal.Duration = int.Parse(this.txtDuration.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
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
    }
}
