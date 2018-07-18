using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;
using System.Windows.Forms;
using TpFinalTDP2015.UI.Excepciones;

namespace MarrSystems.TpFinalTDP2015.UI.View
{
    public partial class DateIntervalView: Form
    {
        private AdminModePages.GenericDGV<ScheduleEntryDTO> dgvTimeInterval;

        public DateIntervalView()
        {
            InitializeComponent();
        }

        public void View(ScheduleDTO pDateInterval)
        {
            if (pDateInterval == null)
            {
                throw new EntidadNulaException("El Intervalo de fechas indicado es nulo");
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.txtTitle.Text = pDateInterval.Name;
                this.dtpStartDate.Value = pDateInterval.ActiveFrom;
                this.dtpEndDate.Value = pDateInterval.ActiveUntil;
                this.Text = "Intervalo de fechas: " + pDateInterval.Name;
                foreach (Days dia in pDateInterval.ActiveDays)
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
                this.dgvTimeInterval.SetSource(pDateInterval.ActiveHours);
                this.ShowDialog();
            }
        }
    }
}
