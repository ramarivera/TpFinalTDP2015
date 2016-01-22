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
        private CampaignInterval iIntervaloOriginal;

        public CampaignInterval Intervalo
        {
            get { return this.iIntervaloOriginal; }
        }
        public AgregarModificarIntervalo()
        {
            InitializeComponent();
        }

        public void AgregarIntervalo(CampaignInterval pIntervaloNuevo)
        {
            this.txtTitle.Text = String.Empty;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.dtpStartTime.Value = DateTime.Now;
            this.dtpEndTime.Value = DateTime.Now;
            this.Text = "Agregar nuevo Intervalo";
            this.iIntervaloOriginal = pIntervaloNuevo;
        }

        public void ModificarIntervalo(CampaignInterval pIntervalo)
        {
            this.txtTitle.Text = pIntervalo.Name;
            this.dtpStartDate.Value = pIntervalo.StartDate;
            this.dtpEndDate.Value =  pIntervalo.EndDate;
            this.dtpStartTime.Value = DateTime.MinValue + pIntervalo.StartTime;
            this.dtpEndTime.Value = DateTime.MinValue + pIntervalo.EndTime;
            this.Text = "Modificar Intervalo";
            foreach (Dia dia in pIntervalo.DiasDeLaSemana)
            {
                switch (dia)
                {
                    case Dia.Domingo:
                        this.chkSunday.Checked = true;
                        break;
                    case Dia.Lunes:
                        this.chkMonday.Checked = true;
                        break;
                    case Dia.Martes:
                        this.chkTuesday.Checked = true;
                        break;
                    case Dia.Miercoles:
                        this.chkWednesday.Checked = true;
                        break;
                    case Dia.Jueves:
                        this.chkThursday.Checked = true;
                        break;
                    case Dia.Viernes:
                        this.chkFriday.Checked = true;
                        break;
                    case Dia.Sabado:
                        this.chkSaturday.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            this.iIntervaloOriginal = pIntervalo;
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
            this.iIntervaloOriginal.Name = this.txtTitle.Text;
            this.iIntervaloOriginal.StartDate = this.dtpStartDate.Value;
            this.iIntervaloOriginal.EndDate = this.dtpEndDate.Value;
            this.iIntervaloOriginal.StartTime = this.dtpStartTime.Value.TimeOfDay;
            this.iIntervaloOriginal.EndTime = this.dtpEndTime.Value.TimeOfDay;
            if (this.chkSunday.Checked)
            {
                this.iIntervaloOriginal.DiasDeLaSemana.Add(Dia.Domingo);
            }
            if (this.chkMonday.Checked)
            {
                this.iIntervaloOriginal.DiasDeLaSemana.Add(Dia.Lunes);
            }
            if (this.chkTuesday.Checked)
            {
                this.iIntervaloOriginal.DiasDeLaSemana.Add(Dia.Martes);
            }
            if (this.chkWednesday.Checked)
            {
                this.iIntervaloOriginal.DiasDeLaSemana.Add(Dia.Miercoles);
            }
            if (this.chkThursday.Checked)
            {
                this.iIntervaloOriginal.DiasDeLaSemana.Add(Dia.Jueves);
            }
            if (this.chkFriday.Checked)
            {
                this.iIntervaloOriginal.DiasDeLaSemana.Add(Dia.Viernes);
            }
            if (this.chkSaturday.Checked)
            {
                this.iIntervaloOriginal.DiasDeLaSemana.Add(Dia.Sabado);
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
