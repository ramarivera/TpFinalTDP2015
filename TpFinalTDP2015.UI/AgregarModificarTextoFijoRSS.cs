using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Persistence.Model;

namespace TpFinalTDP2015.UI
{
    public partial class AgregarModificarTextoFijoRSS : BaseForm
    {
        private StaticText iTextoFijoOriginal;

        public StaticText TextoFijo
        {
            get { return this.iTextoFijoOriginal; }
        }

        private RSSSource iFuenteRSSOriginal;

        public RSSSource RSSSource
        {
            get { return this.iFuenteRSSOriginal; }
        }
        public AgregarModificarTextoFijoRSS()
        {
            InitializeComponent();
        }

        public void AgregarTextoFijo(StaticText pTextoFijoNuevo)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtText.Text = String.Empty;
            this.Text = "Agregar nuevo Texto Fijo";
            this.iTextoFijoOriginal = pTextoFijoNuevo;
        }

        public void ModificarTextoFijo(StaticText pTextoFijo)
        {
            this.txtTitle.Text = pTextoFijo.Title;
            this.txtDescription.Text = pTextoFijo.Description;
            this.txtText.Text = pTextoFijo.Text;
            this.Text = "Modificar Texto Fijo";
            this.iTextoFijoOriginal = pTextoFijo;
        }

        public void AgregarFuenteRSS(RSSSource pFuenteRSSNueva)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtText.Text = String.Empty;
            this.lblText.Text = "URL";
            this.Text = "Agregar nueva FuenteRSS";
            this.iFuenteRSSOriginal = pFuenteRSSNueva;
        }

        public void ModificarFuenteRSS(RSSSource pFuenteRSS)
        {
            this.txtTitle.Text = pFuenteRSS.Title;
            this.txtDescription.Text = pFuenteRSS.Description;
            this.txtText.Text = pFuenteRSS.URL;
            this.lblText.Text = "URL";
            this.Text = "Modificar FuenteRSS";
            this.iFuenteRSSOriginal = pFuenteRSS;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.lblText.Text == "Texto")
            {
                this.iTextoFijoOriginal.Title = this.txtTitle.Text;
                this.iTextoFijoOriginal.Description = this.txtDescription.Text;
                this.iTextoFijoOriginal.Text = this.txtText.Text;
            }
            else
            {
                this.iFuenteRSSOriginal.Title = this.txtTitle.Text;
                this.iFuenteRSSOriginal.Description = this.txtDescription.Text;
                this.iFuenteRSSOriginal.URL = this.txtText.Text;
            }
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
    }
}
