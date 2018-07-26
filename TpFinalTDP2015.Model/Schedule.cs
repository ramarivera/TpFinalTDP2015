using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;
using MarrSystems.TpFinalTDP2015.Model.Exceptiones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarrSystems.TpFinalTDP2015.Model
{
    [Serializable]
    public class Schedule : BaseEntity
    {
        private string iName;
        private DateTime iActiveFrom;
        private DateTime iActiveUntil;

        private bool iMonday;
        private bool iTuesday;
        private bool iWednesday;
        private bool iThursday;
        private bool iFriday;
        private bool iSaturday;
        private bool iSunday;

        private static readonly DateTime MIN_VALUE = new DateTime(1980, 1, 1);
        private static readonly DateTime MAX_VALUE = new DateTime(2099, 12, 31);

        public Schedule() : base()
        {
            this.iActiveUntil = MAX_VALUE;
            this.iActiveFrom = MIN_VALUE;
            this.TimeIntervals = new List<ScheduleEntry>();
        }

        public virtual string Name
        {
            get { return this.iName; }
            set { this.iName = value; }
        }

        public virtual DateTime ActiveFrom
        {
            get { return this.iActiveFrom; }
            set
            {
                if ((value <= this.iActiveUntil) && ((value >= MIN_VALUE) && (value <= MAX_VALUE)))
                {
                    this.iActiveFrom = value;
                }
                else
                {
                    throw new FechaInvalidaException("La fecha indicada no es valida");
                }
                /*
                                if (!(value <= this.iActiveUntil))
                                {
                                    throw new FechaInvalidaException("La fecha de inicio del intervalo debe ser menor o igual a la fecha de fin");
                                }
                                else if (!(value >= MIN_VALUE))
                                {
                                    throw new FechaInvalidaException("La fecha indicada debe ser mayor o igual a "+MIN_VALUE.ToString());
                                }
                                else if (!(value <= MAX_VALUE))
                                {
                                    throw new FechaInvalidaException("La fecha indicada debe ser menor o igual a " + MAX_VALUE.ToString());
                                }
                                else
                                {
                                    this.iActiveFrom = value;
                                }*/
            }
        }
        public virtual DateTime ActiveUntil
        {
            get { return this.iActiveUntil; }
            set
            {
                if ((value >= this.iActiveFrom) && ((value >= MIN_VALUE) && (value <= MAX_VALUE)))
                {
                    this.iActiveUntil = value;
                }
                else
                {
                    throw new FechaInvalidaException("La fecha indicada no es valida");
                }

                /*
                if (!(value >= this.iActiveFrom))
                {
                    throw new FechaInvalidaException("La fecha de fin del intervalo debe ser mayor o igual a la fecha de inicio");
                }
                else if (!(value >= MIN_VALUE))
                {
                    throw new FechaInvalidaException("La fecha indicada debe ser mayor o igual a "+MIN_VALUE.ToString());
                }
                else if (!(value <= MAX_VALUE))
                {
                    throw new FechaInvalidaException("La fecha indicada debe ser menor o igual a " + MAX_VALUE.ToString());
                }
                else
                {
                    this.iActiveFrom = value;
                }*/

            }
        }

        public virtual bool Monday
        {
            get { return this.iMonday; }
            set { this.iMonday = value; }
        }

        public virtual bool Thursday
        {
            get { return this.iThursday; }
            set { this.iThursday = value; }
        }

        public virtual bool Wednesday
        {
            get { return this.iWednesday; }
            set { this.iWednesday = value; }
        }

        public virtual bool Tuesday
        {
            get { return this.iTuesday; }
            set { this.iTuesday = value; }
        }
        public virtual bool Friday
        {
            get { return this.iFriday; }
            set { this.iFriday = value; }
        }

        public virtual bool Saturday
        {
            get { return this.iSaturday; }
            set { this.iSaturday = value; }
        }

        public virtual bool Sunday
        {
            get { return this.iSunday; }
            set { this.iSunday = value; }
        }

        protected virtual IList<ScheduleEntry> TimeIntervals { get; set; }

        public List<Days> ActiveDays
        {
            get
            {
                var lResult = new List<Days>();

                if (Monday)
                {
                    lResult.Add(Days.Lunes);
                }

                if (Tuesday)
                {
                    lResult.Add(Days.Martes);
                }

                if (Wednesday)
                {
                    lResult.Add(Days.Miercoles);
                }

                if (Thursday)
                {
                    lResult.Add(Days.Jueves);
                }

                if (Friday)
                {
                    lResult.Add(Days.Viernes);
                }

                if (Saturday)
                {
                    lResult.Add(Days.Sabado);
                }

                if (Sunday)
                {
                    lResult.Add(Days.Domingo);
                }

                return lResult;
            }
        }

        public virtual IEnumerable<ScheduleEntry> ActiveHours
        {
            get
            {
                return this.TimeIntervals;
            }
        }

        public virtual void AddTimeInterval(ScheduleEntry pInterval)
        {
            if (pInterval == null)
            {
                throw new EntidadNulaException("El intervalo de tiempo indicado es nulo");
            }
            if (!this.CanBeAdded(pInterval))
            {
                throw new IntervaloTiempoInvalidoException("El intervalo de tiempo indicado no puede ser agregado al Intervalo de fechas debido a que se superpone con un intervalo de tiempo existente");
            }
            else
            {
                this.TimeIntervals.Add(pInterval);
            }
        }

        public virtual void RemoveTimeInterval(ScheduleEntry pInterval)
        {
            this.TimeIntervals.Remove(pInterval);
        }


        public virtual void RemoveAllIntervals()
        {
            foreach (var interval in TimeIntervals.Reverse())
            {
                RemoveTimeInterval(interval);
            }
        }

        private bool CanBeAdded(ScheduleEntry pInterval)//para ser agregado
        {
            bool lResult = true;
            int i = this.TimeIntervals.Count - 1;
            while ((lResult == true) && (i >= 0))
            {
                ScheduleEntry lInterval = this.TimeIntervals[i];
                if (pInterval.IntersectsWith(lInterval))
                {
                    lResult = false;
                }
                i--;
            }
            return lResult;
        }

        public bool IntersectsWith(Schedule pInterval)
        {
            bool lResult = false;
            if ((pInterval.ActiveFrom > this.iActiveFrom)
                && (pInterval.ActiveFrom < this.iActiveUntil)) // fecha de inicio de pInterval entre intervalo que llama
            {
                lResult = true;
            }
            else if ((pInterval.ActiveUntil > this.iActiveFrom) //fecha de fin de pInteval entre intervalo que llama
                    && (pInterval.ActiveUntil < this.iActiveUntil))
            {
                lResult = true;
            }
            else if ((this.iActiveFrom > pInterval.ActiveFrom) //fecha de inicio de intervalo que llama entre pInterval
                    && (this.iActiveFrom < pInterval.ActiveUntil))
            {
                lResult = true;
            }
            else if ((this.iActiveUntil > pInterval.ActiveFrom) //fecha de fin de intervalo que llama entre pInterval
                    && (this.iActiveUntil < pInterval.ActiveUntil))
            {
                lResult = true;
            }
            else if ((this.iActiveFrom == pInterval.ActiveFrom)//intervalos iguales
                    && (this.iActiveUntil == pInterval.ActiveUntil))
            {
                lResult = true;
            }
            if (lResult)
            {
                lResult = this.HasEqualDays(pInterval);
            }
            if (lResult)
            {
                lResult = this.HasEqualTimeIntervals(pInterval);
            }
            return lResult;
        }

        private bool HasEqualDays(Schedule pInterval)
        {
            return this.ActiveDays.Any(x => pInterval.ActiveDays.Contains(x));
        }

        private bool HasEqualTimeIntervals(Schedule pInterval)
        {
            bool lResult = false;
            int i = this.TimeIntervals.Count - 1;
            while ((lResult == false) && (i >= 0))
            {
                ScheduleEntry pTimeInterval = this.TimeIntervals[i];
                int j = pInterval.ActiveHours.Count() - 1;
                while ((lResult == false) && (j >= 0))
                {
                    lResult = pTimeInterval.IntersectsWith(pInterval.ActiveHours.ElementAt(j));
                    j--;
                }
                i--;
            }
            return lResult;
        }

        public bool IsActiveAt(DateTime pDate)
        {
            return (pDate >= this.ActiveFrom)
                && (pDate <= this.ActiveUntil)
                && this.IsActiveAtDate(pDate)
                && this.IsActiveAtTime(pDate.TimeOfDay);
        }

        private bool IsActiveAtDate(DateTime pDate)
        {
            return this.ActiveDays.Any(x => (int)x == pDate.Day);
        }

        private bool IsActiveAtTime(TimeSpan pTime)
        {
            return this.TimeIntervals.Any(x => x.Start < pTime && pTime < x.End);
        }

        public virtual void AddDay(Days pDay)
        {
            if (this.ActiveDays.Contains(pDay))
            {
                //TODO excepcion dia repetido
                throw new DiaRepetidoException("El día indicado ya existe en el intervalo");
            }
            else
            {
                if (pDay == Days.Domingo) this.Sunday = true;
                if (pDay == Days.Lunes) this.Monday = true;
                if (pDay == Days.Martes) this.Tuesday = true;
                if (pDay == Days.Miercoles) this.Wednesday = true;
                if (pDay == Days.Jueves) this.Thursday = true;
                if (pDay == Days.Viernes) this.Friday = true;
                if (pDay == Days.Sabado) this.Saturday = true;
            }
        }
    }
}
