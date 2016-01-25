using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.UI
{
    public partial class AgregarModificarTextoFijoRSS : BaseForm
    {
        private StaticTextDTO iOriginalStaticText;

        public StaticTextDTO StaticText
        {
            get { return this.iOriginalStaticText; }
        }

        private RSSSourceDTO iOriginalRSSSource;

        public RSSSourceDTO RSSSource
        {
            get { return this.iOriginalRSSSource; }
        }
        public AgregarModificarTextoFijoRSS()
        {
            InitializeComponent();
        }

        public void AgregarTextoFijo(StaticTextDTO pNewStaticText)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtText.Text = String.Empty;
            this.Text = "Agregar nuevo Texto Fijo";
            this.iOriginalStaticText = pNewStaticText;
        }

        public void ModificarTextoFijo(StaticTextDTO pStaticText)
        {
            this.txtTitle.Text = pStaticText.Title;
            this.txtDescription.Text = pStaticText.Description;
            this.txtText.Text = pStaticText.Text;
            this.Text = "Modificar Texto Fijo";
            this.iOriginalStaticText = pStaticText;
        }

        public void AgregarFuenteRSS(RSSSourceDTO pNewRSSSource)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtText.Text = String.Empty;
            this.lblText.Text = "URL";
            this.Text = "Agregar nueva FuenteRSS";
            this.iOriginalRSSSource = pNewRSSSource;
        }

        public void ModificarFuenteRSS(RSSSourceDTO pRSSSource)
        {
            this.txtTitle.Text = pRSSSource.Title;
            this.txtDescription.Text = pRSSSource.Description;
            this.txtText.Text = pRSSSource.URL;
            this.lblText.Text = "URL";
            this.Text = "Modificar FuenteRSS";
            this.iOriginalRSSSource = pRSSSource;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.lblText.Text == "Texto")
            {
                this.iOriginalStaticText.Title = this.txtTitle.Text;
                this.iOriginalStaticText.Description = this.txtDescription.Text;
                this.iOriginalStaticText.Text = this.txtText.Text;
            }
            else
            {
                this.iOriginalRSSSource.Title = this.txtTitle.Text;
                this.iOriginalRSSSource.Description = this.txtDescription.Text;
                this.iOriginalRSSSource.URL = this.txtText.Text;
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
