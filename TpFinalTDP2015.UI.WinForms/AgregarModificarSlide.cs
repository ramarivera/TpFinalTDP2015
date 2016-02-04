using System;
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
    public partial class AgregarModificarSlide : BaseForm, IAddModifyViewForm
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

        void IAddModifyViewForm.Agregar(IDTO pNewCampaign)
        {
            
        }

        void IAddModifyViewForm.Modificar(IDTO pCampaign)
        {
         
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
        }
    }
}
