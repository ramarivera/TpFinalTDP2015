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

namespace TpFinalTDP2015.UI
{
    public partial class AgregarModificarCampaña : Form
    {
        private Campaña iCampañaOriginal;

        public Campaña Campaña
        {
            get { return this.iCampañaOriginal; }
        }
        public AgregarModificarCampaña()
        {
            InitializeComponent();
        }

        public void AgregarCampaña(Campaña pCampañaNueva)
        {
            this.txtTitulo.Text = String.Empty;
            this.txtDescripcion.Text = String.Empty;
            this.txtDuracion.Text = String.Empty;
            this.Text = "Agregar nueva Campaña";
            this.iCampañaOriginal = pCampañaNueva;
        }

        public void ModificarCampaña(Campaña pCampaña)
        {
            this.txtTitulo.Text = pCampaña.Titulo;
            this.txtDescripcion.Text = pCampaña.Descripcion;
            this.txtDuracion.Text = pCampaña.Duracion.ToString();
            this.Text = "Modificar Campaña";
            this.iCampañaOriginal = pCampaña;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.iCampañaOriginal.Titulo = this.txtTitulo.Text;
            this.iCampañaOriginal.Descripcion = this.txtDescripcion.Text;
            this.iCampañaOriginal.Duracion = int.Parse(this.txtDuracion.Text);
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
