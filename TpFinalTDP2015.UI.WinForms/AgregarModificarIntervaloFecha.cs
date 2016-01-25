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
        private DateIntervalDTO iOriginalDateInterval;

        public DateIntervalDTO DateInterval
        {
            get { return this.iOriginalDateInterval; }
        }
        public AgregarModificarIntervaloFecha()
        {
            InitializeComponent();
        }

        public void AgregarIntervalo(DateIntervalDTO pNewDateInterval)
        {
            this.txtTitle.Text = String.Empty;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.Text = "Agregar nuevo Intervalo";
            this.iOriginalDateInterval = pNewDateInterval;
        }

        public void ModificarIntervalo(DateIntervalDTO pDateInterval)
        {
            this.txtTitle.Text = pDateInterval.Name;
            this.dtpStartDate.Value = pDateInterval.ActiveFrom;
            this.dtpEndDate.Value =  pDateInterval.ActiveUntil;
            this.Text = "Modificar Intervalo";
            foreach (Days dia in pDateInterval.Days)
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
            this.iOriginalDateInterval = pDateInterval;
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
            this.iOriginalDateInterval.Name = this.txtTitle.Text;
            this.iOriginalDateInterval.ActiveFrom = this.dtpStartDate.Value;
            this.iOriginalDateInterval.ActiveUntil = this.dtpEndDate.Value;
            if (this.chkSunday.Checked)
            {
                this.iOriginalDateInterval.Days.Add(Days.Domingo);
            }
            if (this.chkMonday.Checked)
            {
                this.iOriginalDateInterval.Days.Add(Days.Lunes);
            }
            if (this.chkTuesday.Checked)
            {
                this.iOriginalDateInterval.Days.Add(Days.Martes);
            }
            if (this.chkWednesday.Checked)
            {
                this.iOriginalDateInterval.Days.Add(Days.Miercoles);
            }
            if (this.chkThursday.Checked)
            {
                this.iOriginalDateInterval.Days.Add(Days.Jueves);
            }
            if (this.chkFriday.Checked)
            {
                this.iOriginalDateInterval.Days.Add(Days.Viernes);
            }
            if (this.chkSaturday.Checked)
            {
                this.iOriginalDateInterval.Days.Add(Days.Sabado);
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
    }
}
