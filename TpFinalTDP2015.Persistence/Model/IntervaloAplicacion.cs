using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class IntervaloAplicacion
    {
        private string iName;
        private DateTime iFechaInicio;
        private DateTime iFechaFin;
        private TimeSpan iHoraInicio;
        private TimeSpan iHoraFin;



        public DateTime FechaInicio
        {
            get { return this.iFechaInicio; }
            set
            {
                if (value <= this.FechaFin)
                {
                    this.iFechaInicio = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }
        public DateTime FechaFin
        {
            get { return this.FechaFin; }
            set
            {
                if (value >= this.FechaInicio)
                {
                    this.iFechaFin = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }
        public TimeSpan HoraInicio
        {
            get { return this.HoraInicio; }
            set
            {
                if (value < this.HoraFin)
                {
                    this.iHoraInicio = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }
        public TimeSpan HoraFin
        {
            get { return this.HoraFin; }
            set
            {
                if (value > this.HoraInicio)
                {
                    this.iHoraFin = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }
        public List<Dia> DiasDeLaSemana { get; set; }
        public string Name { get; set; }

        public IntervaloAplicacion()
        {
            this.DiasDeLaSemana = new List<Dia>();
            this.FechaInicio = new DateTime(1);
            this.FechaFin = new DateTime(2);
            this.HoraInicio = new TimeSpan(1);
            this.HoraFin = new TimeSpan(2);

        }

        public bool OverlapsWith(IntervaloAplicacion pLapse)
        {
            bool lResult = false;

            if (this.FechaInicio > pLapse.FechaFin ||
                this.FechaFin < pLapse.FechaInicio)
            {
                lResult = false;
            }
            else
            {
                int i = 0;

                while (!lResult)
                {
                    Dia day = this.DiasDeLaSemana[i];

                    if (pLapse.DiasDeLaSemana.Contains(day))
                    {
                        if (this.HoraInicio > pLapse.HoraFin ||
                            this.HoraFin < pLapse.HoraInicio)
                        {
                            lResult = false;
                        }
                        else
                        {
                            lResult = true;
                        }
                    }

                }
            }

            return lResult;
        }
    }
}
