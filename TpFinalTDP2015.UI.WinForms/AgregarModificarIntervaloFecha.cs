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
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;

namespace MarrSystems.TpFinalTDP2015.UI
{
    public partial class AgregarModificarIntervaloFecha : BaseForm, IAddModifyViewForm
    {
        private ScheduleDTO iOriginalDateInterval;

        public ScheduleDTO DateInterval
        {
            get { return this.iOriginalDateInterval; }
        }
        public AgregarModificarIntervaloFecha()
        {
            InitializeComponent();
        }

        void IAddModifyViewForm.Add(IDTO pNewDateInterval)
        {
            this.txtTitle.Text = String.Empty;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.Text = "Agregar nuevo Intervalo";
            this.iOriginalDateInterval = (ScheduleDTO)pNewDateInterval;
        }

        void IAddModifyViewForm.Modify(IDTO pDateInterval)
        {
            if (pDateInterval == null)
            {
                throw new ArgumentNullException();
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.iOriginalDateInterval = (ScheduleDTO)pDateInterval;
                this.txtTitle.Text = iOriginalDateInterval.Name;
                this.dtpStartDate.Value = iOriginalDateInterval.ActiveFrom;
                this.dtpEndDate.Value = iOriginalDateInterval.ActiveUntil;
                this.Text = "Modificar Intervalo";
                foreach (Days dia in iOriginalDateInterval.Days)
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
            }
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
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
            if ((String.IsNullOrWhiteSpace(this.txtTitle.Text)))
            {
                MessageBox.Show("Complete el campo 'Título'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.iOriginalDateInterval.Name = this.txtTitle.Text;
                this.iOriginalDateInterval.ActiveFrom = this.dtpStartDate.Value;
                this.iOriginalDateInterval.ActiveUntil = this.dtpEndDate.Value;
                this.iOriginalDateInterval.Days.Clear();
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
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
