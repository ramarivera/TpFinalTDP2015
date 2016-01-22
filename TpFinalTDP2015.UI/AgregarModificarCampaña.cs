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
    public partial class AgregarModificarCampaña : BaseForm
    {
        private Campaign iCampañaOriginal;

        public Campaign Campaña
        {
            get { return this.iCampañaOriginal; }
        }
        public AgregarModificarCampaña()
        {
            InitializeComponent();
        }

        public void AgregarCampaña(Campaign pCampañaNueva)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtDuration.Text = String.Empty;
            this.Text = "Agregar nueva Campaña";
            this.iCampañaOriginal = pCampañaNueva;
        }

        public void ModificarCampaña(Campaign pCampaña)
        {
            this.txtTitle.Text = pCampaña.Name;
            this.txtDescription.Text = pCampaña.Description;
           // this.txtDuration.Text = pCampaña.Duration.ToString();
            this.Text = "Modificar Campaña";
            this.iCampañaOriginal = pCampaña;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.iCampañaOriginal.Name = this.txtTitle.Text;
            this.iCampañaOriginal.Description = this.txtDescription.Text;
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
