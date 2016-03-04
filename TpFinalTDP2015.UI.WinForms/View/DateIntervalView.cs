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

namespace MarrSystems.TpFinalTDP2015.UI.View
{
    public partial class DateIntervalView: Form
    {
        public DateIntervalView()
        {
            InitializeComponent();
        }

        public void View(DateIntervalDTO pDateInterval)
        {
            if (pDateInterval == null)
            {
                throw new ArgumentNullException();
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.txtTitle.Text = pDateInterval.Name;
                this.dtpStartDate.Value = pDateInterval.ActiveFrom;
                this.dtpEndDate.Value = pDateInterval.ActiveUntil;
                this.Text = "Intervalo de fechas: " + pDateInterval.Name;
                foreach (Days dia in pDateInterval.Days)
                {
                    switch (dia)
                    {
                        case Days.Domingo:
                            this.lblDays.Text += Days.Domingo.ToString()+" - ";
                            break;
                        case Days.Lunes:
                            this.lblDays.Text += Days.Lunes.ToString()+ " - ";
                            break;
                        case Days.Martes:
                            this.lblDays.Text += Days.Martes.ToString()+ " - ";
                            break;
                        case Days.Miercoles:
                            this.lblDays.Text += Days.Miercoles.ToString()+ " - ";
                            break;
                        case Days.Jueves:
                            this.lblDays.Text += Days.Jueves.ToString()+ " - ";
                            break;
                        case Days.Viernes:
                            this.lblDays.Text += Days.Viernes.ToString()+ " - ";
                            break;
                        case Days.Sabado:
                            this.lblDays.Text += Days.Sabado.ToString()+ " - ";
                            break;
                        default:
                            break;
                    }
                }
                this.dgvTimeInterval.AddToSource(pDateInterval.ActiveHours.ToDTOList());
                this.ShowDialog();
            }
        }
    }
}
