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
    public partial class AgregarModificarIntervaloTiempo : Form
    {
        private TimeIntervalDTO iOriginalTimeInterval;

        public TimeIntervalDTO TimeInterval
        {
            get { return this.iOriginalTimeInterval; }
        }
        public AgregarModificarIntervaloTiempo()
        {
            InitializeComponent();
        }

        public void AgregarIntervalo(TimeIntervalDTO pNewTimeInterval)
        {
            this.dtpStartTime.Value = DateTime.Now;
            this.dtpEndTime.Value = DateTime.Now;
            this.Text = "Agregar nuevo Intervalo";
            this.iOriginalTimeInterval = pNewTimeInterval;
        }

        public void ModificarIntervalo(TimeIntervalDTO pTimeInterval)
        {
            this.dtpStartTime.Value = DateTime.MinValue + pTimeInterval.StartTime;
            this.dtpEndTime.Value = DateTime.MinValue + pTimeInterval.EndTime;
            this.Text = "Modificar Intervalo";
            this.iOriginalTimeInterval = pTimeInterval;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.iOriginalTimeInterval.StartTime = this.dtpStartTime.Value.TimeOfDay;
            this.iOriginalTimeInterval.EndTime = this.dtpEndTime.Value.TimeOfDay;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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
}
