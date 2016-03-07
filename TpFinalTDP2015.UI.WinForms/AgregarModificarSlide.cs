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

namespace MarrSystems.TpFinalTDP2015.UI
{
    public partial class AgregarModificarSlide : Form, IAddModifyViewForm
    {
        private SlideDTO iOriginalSlide;

        public SlideDTO Slide
        {
            get { return this.iOriginalSlide; }
        }

        public AgregarModificarSlide()
        {
            InitializeComponent();
        }

        void IAddModifyViewForm.Add(IDTO pNewSlide)
        {
            this.txtDuration.Text = String.Empty;
            //transicion
            this.Text = "Agregar nuevo Slide";
            this.iOriginalSlide = (SlideDTO)pNewSlide;
        }

        void IAddModifyViewForm.Modify(IDTO pSlide)
        {
            if (pSlide == null)
            {
                throw new ArgumentNullException();
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.iOriginalSlide = (SlideDTO)pSlide;
                this.txtDuration.Text = iOriginalSlide.Duration.ToString();
                this.Text = "Modificar Slide";
            }
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnImage_Click(object sender, EventArgs e)
        {

        }
    }
}
