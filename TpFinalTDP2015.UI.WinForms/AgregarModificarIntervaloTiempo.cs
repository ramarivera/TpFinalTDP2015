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
    public partial class AgregarModificarIntervaloTiempo : BaseForm, IAddModifyViewForm
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

        void IAddModifyViewForm.Agregar(IDTO pNewTimeInterval)
        {
            this.dtpStartTime.Value = DateTime.Now;
            this.dtpEndTime.Value = DateTime.Now;
            this.Text = "Agregar nuevo Intervalo";
            this.iOriginalTimeInterval = (TimeIntervalDTO)pNewTimeInterval;
        }

        void IAddModifyViewForm.Modificar(IDTO pTimeInterval)
        {
            this.iOriginalTimeInterval = (TimeIntervalDTO)pTimeInterval;
            this.dtpStartTime.Value = DateTime.MinValue + iOriginalTimeInterval.StartTime;
            this.dtpEndTime.Value = DateTime.MinValue + iOriginalTimeInterval.EndTime;
            this.Text = "Modificar Intervalo";
            
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
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
