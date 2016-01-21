﻿using System;
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
            this.txtTitle.Text = String.Empty;
            this.dtpFechaIni.Value = DateTime.Now;
            this.dtpFechaFin.Value = DateTime.Now;
            this.dtpHoraIni.Value = DateTime.Now;
            this.dtpHoraFin.Value = DateTime.Now;
            this.Text = "Agregar nuevo Intervalo";
            this.iIntervaloOriginal = pIntervaloNuevo;
        }

        public void ModificarIntervalo(IntervaloAplicacion pIntervalo)
        {
            this.txtTitle.Text = pIntervalo.Name;
            this.dtpFechaIni.Value = pIntervalo.FechaInicio;
            this.dtpFechaFin.Value = pIntervalo.FechaFin;
            //this.dtpHoraIni.Value.TimeOfDay = pIntervalo.HoraInicio.;
            //this.dtpHoraFin.Value = pIntervalo.HoraFin;
            this.Text = "Modificar Intervalo";
            foreach (Dia dia in pIntervalo.DiasDeLaSemana)
            {
                switch (dia)
                {
                    case Dia.Domingo:
                        this.chkDomingo.Checked = true;
                        break;
                    case Dia.Lunes:
                        this.chkLunes.Checked = true;
                        break;
                    case Dia.Martes:
                        this.chkMartes.Checked = true;
                        break;
                    case Dia.Miercoles:
                        this.chkMiercoles.Checked = true;
                        break;
                    case Dia.Jueves:
                        this.chkJueves.Checked = true;
                        break;
                    case Dia.Viernes:
                        this.chkViernes.Checked = true;
                        break;
                    case Dia.Sabado:
                        this.chkSabado.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            this.iIntervaloOriginal = pIntervalo;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.chkDomingo.Checked = true;
            this.chkLunes.Checked = true;
            this.chkMartes.Checked = true;
            this.chkMiercoles.Checked = true;
            this.chkJueves.Checked = true;
            this.chkViernes.Checked = true;
            this.chkSabado.Checked = true;
        }
    }
}
