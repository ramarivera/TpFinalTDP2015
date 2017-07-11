using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model.Enum;
using MarrSystems.TpFinalTDP2015.Model.Interfaces;
using MarrSystems.TpFinalTDP2015.Model.Exceptiones;

namespace MarrSystems.TpFinalTDP2015.Model
{
    [Serializable]
    public class Schedule : BaseEntity
    {
        private string iName;
        private DateTime iActiveFrom;
        private DateTime iActiveUntil;

        private static readonly DateTime MIN_VALUE = new DateTime(1980, 1, 1);
        private static readonly DateTime MAX_VALUE = new DateTime(2099, 12, 31);

        public Schedule() : base()
        {
            this.iActiveUntil = MAX_VALUE;
            this.iActiveFrom = MIN_VALUE;
            this.TimeIntervals = new List<ScheduleEntry>();
            this.Days = new List<Day>();
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


     
        protected virtual IList<ScheduleEntry> TimeIntervals { get; set; }
        protected virtual IList<Day> Days  { get; set; }

      

        public virtual IEnumerable<Day> ActiveDays
        {
            get
            {
                return this.Days;
            }
        }

        public virtual IEnumerable<ScheduleEntry> ActiveHours
        {
            get
            {
                return this.TimeIntervals;
            }
        }

        public virtual void AddDay(Day pDay)
        {
            if (this.Days.Contains(pDay))
            {
                //TODO excepcion dia repetido
                throw new DiaRepetidoException("El día indicado ya existe en el intervalo");
            }
            else
            {
                this.Days.Add(pDay);
            }
        }

        public virtual void RemoveDay(Day pDay)
        {
            this.Days.Remove(pDay);
        }

        public virtual void RemoveAllDays()
        {
            foreach (var day in ActiveDays.Reverse())
            {
                RemoveDay(day);
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
                //TODO excepción si no es valido por interseccion, si es intervalo nulo. irian arriba
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
            bool lResult = false;
            int i = this.Days.Count - 1;
            while ((lResult == false) && (i >= 0))
            {
                Day day = this.Days[i];
                if (pInterval.ActiveDays.Contains(day))
                {
                    lResult = true;
                }
                i--;
            }
            return lResult;
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
            bool lResult = false;
            if ((pDate >= this.ActiveFrom) && (pDate <= this.ActiveUntil))
            {
                lResult = this.IsActiveAtDate(pDate);
                if (lResult)
                {
                    lResult = this.IsActiveAtTime(pDate.TimeOfDay);
                }
            }
            return lResult;
        }

        private bool IsActiveAtDate(DateTime pDate)
        {
            bool lResult = false;
            int lDay = (int)pDate.Day;
            int i = this.Days.Count - 1;
            while ((lResult == false) && (i >= 0))
            {
                int day = (int)this.Days[i].Value;
                lResult = (lDay == day);
                i--;
            }
            return lResult;
            //TODO ver si anda despues de los cambios
        }

        private bool IsActiveAtTime(TimeSpan pTime)
        {
            bool lResult = false;
            int i = this.TimeIntervals.Count - 1;
            while ((lResult == false) && (i >= 0))
            {
                ScheduleEntry pInterval = this.TimeIntervals[i];
                lResult = ((pTime > pInterval.Start) && (pTime < pInterval.End));
                i--;
            }
            return lResult;
        }


    }
}
