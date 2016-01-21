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
        private TextoFijo iTextoFijoOriginal;

        public TextoFijo TextoFijo
        {
            get { return this.iTextoFijoOriginal; }
        }

        private FuenteRSS iFuenteRSSOriginal;

        public FuenteRSS FuenteRSS
        {
            get { return this.iFuenteRSSOriginal; }
        }
        public AgregarModificarTextoFijoRSS()
        {
            InitializeComponent();
        }

        public void AgregarTextoFijo(TextoFijo pTextoFijoNuevo)
        {
            this.txtTitulo.Text = String.Empty;
            this.txtDescripcion.Text = String.Empty;
            this.txtTexto.Text = String.Empty;
            this.Text = "Agregar nuevo Texto Fijo";
            this.iTextoFijoOriginal = pTextoFijoNuevo;
        }

        public void ModificarTextoFijo(TextoFijo pTextoFijo)
        {
            this.txtTitulo.Text = pTextoFijo.Titulo;
            this.txtDescripcion.Text = pTextoFijo.Descripcion;
            this.txtTexto.Text = pTextoFijo.Texto;
            this.Text = "Modificar Texto Fijo";
            this.iTextoFijoOriginal = pTextoFijo;
        }

        public void AgregarFuenteRSS(FuenteRSS pFuenteRSSNueva)
        {
            this.txtTitulo.Text = String.Empty;
            this.txtDescripcion.Text = String.Empty;
            this.txtTexto.Text = String.Empty;
            this.lblTexto.Text = "URL";
            this.Text = "Agregar nueva FuenteRSS";
            this.iFuenteRSSOriginal = pFuenteRSSNueva;
        }

        public void ModificarFuenteRSS(FuenteRSS pFuenteRSS)
        {
            this.txtTitulo.Text = pFuenteRSS.Titulo;
            this.txtDescripcion.Text = pFuenteRSS.Descripcion;
            this.txtTexto.Text = pFuenteRSS.URL;
            this.lblTexto.Text = "URL";
            this.Text = "Modificar FuenteRSS";
            this.iFuenteRSSOriginal = pFuenteRSS;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.lblTexto.Text == "Texto")
            {
                this.iTextoFijoOriginal.Titulo = this.txtTitulo.Text;
                this.iTextoFijoOriginal.Descripcion = this.txtDescripcion.Text;
                this.iTextoFijoOriginal.Texto = this.txtTexto.Text;
            }
            else
            {
                this.iFuenteRSSOriginal.Titulo = this.txtTitulo.Text;
                this.iFuenteRSSOriginal.Descripcion = this.txtDescripcion.Text;
                this.iFuenteRSSOriginal.URL = this.txtTexto.Text;
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
