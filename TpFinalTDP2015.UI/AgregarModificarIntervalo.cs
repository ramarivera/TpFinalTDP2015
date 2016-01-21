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
    public partial class AgregarModificarIntervalo : BaseForm
    {
        private IntervaloAplicacion iIntervaloOriginal;

        public IntervaloAplicacion Intervalo
        {
            get { return this.iIntervaloOriginal; }
        }
        public AgregarModificarIntervalo()
        {
            InitializeComponent();
        }

        public void AgregarIntervalo(IntervaloAplicacion pIntervaloNuevo)
        {
            this.dtpFechaIni.Value = DateTime.Now;
            this.dtpFechaFin.Value = DateTime.Now;
            this.dtpHoraIni.Value = DateTime.Now;
            this.dtpHoraFin.Value = DateTime.Now;
            this.Text = "Agregar nuevo Intervalo";
            this.iIntervaloOriginal = pIntervaloNuevo;
        }

        public void ModificarIntervalo(IntervaloAplicacion pIntervalo)
        {
            
            this.Text = "Modificar Intervalo";
            this.iIntervaloOriginal = pIntervalo;
        }
    }
}
