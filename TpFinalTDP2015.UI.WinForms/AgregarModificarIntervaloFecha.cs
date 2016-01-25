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
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.UI
{
    public partial class AgregarModificarIntervaloFecha : BaseForm
    {
        private DateIntervalDTO iOriginalInterval;

        public DateIntervalDTO Interval
        {
            get { return this.iOriginalInterval; }
        }
        public AgregarModificarIntervaloFecha()
        {
            InitializeComponent();
        }

        public void AgregarIntervalo(DateIntervalDTO pNewInterval)
        {
            this.txtTitle.Text = String.Empty;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.Text = "Agregar nuevo Intervalo";
            this.iOriginalInterval = pNewInterval;
        }

        public void ModificarIntervalo(DateIntervalDTO pInterval)
        {
            this.txtTitle.Text = pInterval.Name;
            this.dtpStartDate.Value = pInterval.ActiveFrom;
            this.dtpEndDate.Value =  pInterval.ActiveUntil;
            //this.dtpStartTime.Value = DateTime.MinValue + pInterval.StartTime;
            //this.dtpEndTime.Value = DateTime.MinValue + pInterval.EndTime;
            this.Text = "Modificar Intervalo";
            foreach (Days dia in pInterval.Days)
            {
                switch (dia)
                {
                    case Days.Domingo:
                        this.chkSunday.Checked = true;
                        break;
                    case Days.Lunes:
                        this.chkMonday.Checked = true;
                        break;
                    case Days.Martes:
                        this.chkTuesday.Checked = true;
                        break;
                    case Days.Miercoles:
                        this.chkWednesday.Checked = true;
                        break;
                    case Days.Jueves:
                        this.chkThursday.Checked = true;
                        break;
                    case Days.Viernes:
                        this.chkFriday.Checked = true;
                        break;
                    case Days.Sabado:
                        this.chkSaturday.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            this.iOriginalInterval = pInterval;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.chkSunday.Checked = true;
            this.chkMonday.Checked = true;
            this.chkTuesday.Checked = true;
            this.chkWednesday.Checked = true;
            this.chkThursday.Checked = true;
            this.chkFriday.Checked = true;
            this.chkSaturday.Checked = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.iOriginalInterval.Name = this.txtTitle.Text;
            this.iOriginalInterval.ActiveFrom = this.dtpStartDate.Value;
            this.iOriginalInterval.ActiveUntil = this.dtpEndDate.Value;
            //this.iOriginalInterval.StartTime = this.dtpStartTime.Value.TimeOfDay;
            //this.iOriginalInterval.EndTime = this.dtpEndTime.Value.TimeOfDay;
            if (this.chkSunday.Checked)
            {
                this.iOriginalInterval.Days.Add(Days.Domingo);
            }
            if (this.chkMonday.Checked)
            {
                this.iOriginalInterval.Days.Add(Days.Lunes);
            }
            if (this.chkTuesday.Checked)
            {
                this.iOriginalInterval.Days.Add(Days.Martes);
            }
            if (this.chkWednesday.Checked)
            {
                this.iOriginalInterval.Days.Add(Days.Miercoles);
            }
            if (this.chkThursday.Checked)
            {
                this.iOriginalInterval.Days.Add(Days.Jueves);
            }
            if (this.chkFriday.Checked)
            {
                this.iOriginalInterval.Days.Add(Days.Viernes);
            }
            if (this.chkSaturday.Checked)
            {
                this.iOriginalInterval.Days.Add(Days.Sabado);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
