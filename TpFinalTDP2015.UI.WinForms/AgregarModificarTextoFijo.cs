using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using TpFinalTDP2015.UI.Excepciones;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.UI
{
    public partial class AgregarModificarTextoFijo : BaseForm, IAddModifyViewForm
    {
        private StaticTextDTO iOriginalStaticText = new StaticTextDTO();
        private readonly IControllerFactory iFactory;

        public StaticTextDTO StaticText
        {
            get { return this.iOriginalStaticText; }
        }

        
        public AgregarModificarTextoFijo(IControllerFactory pFactory)
        {
            InitializeComponent();
            this.iFactory = pFactory;
        }

        void IAddModifyViewForm.Add(IDTO pNewStaticText)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtText.Text = String.Empty;
            this.Text = "Agregar nuevo Texto Fijo";
            this.iOriginalStaticText = (StaticTextDTO)pNewStaticText;
        }

        void IAddModifyViewForm.Modify(IDTO pStaticText)
        {
            if (pStaticText == null)
            {
                throw new EntidadNulaException("El texto fijo indicado es nulo");
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.iOriginalStaticText = (StaticTextDTO)pStaticText;
                this.txtTitle.Text = iOriginalStaticText.Title;
                this.txtDescription.Text = iOriginalStaticText.Description;
                this.txtText.Text = iOriginalStaticText.Text;
                this.Text = "Modificar Texto Fijo";
            }    
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((String.IsNullOrWhiteSpace(this.txtTitle.Text)))
                {
                    throw new CampoNuloOVacioException("Complete el campo 'Título'");
                }
                else 
                if ((String.IsNullOrWhiteSpace(this.txtDescription.Text)))
                {
                    throw new CampoNuloOVacioException("Complete el campo 'Descripción'");
                }
                else if ((String.IsNullOrWhiteSpace(this.txtText.Text)))
                {
                    throw new CampoNuloOVacioException("Complete el campo 'Texto'");
                }
                else
                {
                    this.iOriginalStaticText.Title = this.txtTitle.Text;
                    this.iOriginalStaticText.Description = this.txtDescription.Text;
                    this.iOriginalStaticText.Text = this.txtText.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (CampoNuloOVacioException ex)
            {
                MessageBox.Show(ex.Message, "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*if ((String.IsNullOrWhiteSpace(this.txtTitle.Text)))
            {
                MessageBox.Show("Complete el campo 'Título'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((String.IsNullOrWhiteSpace(this.txtDescription.Text)))
            {
                MessageBox.Show("Complete el campo 'Descripción'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((String.IsNullOrWhiteSpace(this.txtText.Text)))
            {
                MessageBox.Show("Complete el campo 'Texto'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.iOriginalStaticText.Title = this.txtTitle.Text;
                this.iOriginalStaticText.Description = this.txtDescription.Text;
                this.iOriginalStaticText.Text = this.txtText.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }*/
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
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
