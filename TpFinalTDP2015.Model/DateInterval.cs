using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model.Enum;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class DateInterval : BaseEntity
    {
        private string iName;
        private DateTime iActiveFrom;
        private DateTime iActiveUntil;
        private IList<Day> iActiveDays;
        private IList<TimeInterval> iActiveHours;

        private readonly DateTime MIN_VALUE = new DateTime(1980, 1, 1);
        private readonly DateTime MAX_VALUE = new DateTime(2099, 12, 31);

        // TODO accesores con fecha de modifcacion para Days
        public DateInterval() : base()
        {
            this.ActiveFrom = new DateTime(1);
            this.ActiveUntil = new DateTime(2);
            this.ActiveHours = new List<TimeInterval>();
            this.ActiveDays = new List<Day>();
        }

        public virtual string Name
        {
            get { return this.iName; }
            set
            {
                this.UpdateModificationDate();
                this.iName = value;
            }
        }

        public virtual DateTime ActiveFrom
        {
            get { return this.iActiveFrom; }
            set
            {
                if ((value <= this.iActiveUntil) && ((value > MIN_VALUE) && (value < MAX_VALUE)))
                {
                    this.UpdateModificationDate();
                    this.iActiveFrom = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }
        public virtual DateTime ActiveUntil
        {
            get { return this.iActiveUntil; }
            set
            {
                if ((value >= this.iActiveFrom) && ((value > MIN_VALUE) && (value < MAX_VALUE)))
                {
                    this.UpdateModificationDate();
                    this.iActiveUntil = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }


        public virtual IList<Day> ActiveDays
        {
            get
            {
                return this.iActiveDays;// Clone<IList<Day>>();
            }
            private set
            {
                this.UpdateModificationDate();
                this.iActiveDays = value;
            }
        }

        public virtual IList<TimeInterval> ActiveHours
        {
            get
            {
                return this.iActiveHours;// Clone<IList<TimeInterval>>();
            }
            private set
            {
                this.UpdateModificationDate();
                this.iActiveHours = value;
            }
        }

        public virtual void AddActiveDay(Day pDay)
        {
            //TODO agregar la verificacion de que no se choquen y bla bla bla
            this.UpdateModificationDate();
            this.iActiveDays.Add(pDay);
        }

        public virtual void RemoveActiveDay(Day pDay)
        {
            this.UpdateModificationDate();
            this.iActiveDays.Remove(pDay);
        }

        public virtual void AddActiveHours(TimeInterval pInterval)
        {
            //TODO agregar la verificacion de que no se choquen y bla bla bla
            this.UpdateModificationDate();
            this.iActiveHours.Add(pInterval);
        }

        public virtual void RemoveActiveHours(TimeInterval pInterval)
        {
            this.UpdateModificationDate();
            this.iActiveHours.Remove(pInterval);
        }

        public bool IntersectionWith(DateInterval pInterval)
        {
            bool lResult = false;
            if ((pInterval.iActiveFrom > this.iActiveFrom)
                && (pInterval.iActiveFrom < this.iActiveUntil)) // fecha de inicio de pInterval entre intervalo que llama
            {
                lResult = true;
            }
            else if ((pInterval.iActiveUntil > this.iActiveFrom) //fecha de fin de pInteval entre intervalo que llama
                    && (pInterval.iActiveUntil < this.iActiveUntil))
            {
                lResult = true;
            }
            else if ((this.iActiveFrom > pInterval.iActiveFrom) //fecha de inicio de intervalo que llama entre pInterval
                    && (this.iActiveFrom < pInterval.iActiveUntil))
            {
                lResult = true;
            }
            else if ((this.iActiveUntil > pInterval.iActiveFrom) //fecha de fin de intervalo que llama entre pInterval
                    && (this.iActiveUntil < pInterval.iActiveUntil))
            {
                lResult = true;
            }
            else if ((this.iActiveFrom == pInterval.iActiveFrom)//intervalos iguales
                    && (this.iActiveUntil == pInterval.iActiveUntil))
            {
                lResult = true;
            }
            if (lResult)
            {
               lResult = this.SameDays(pInterval);
            }
            if (lResult)
            {
                lResult = this.TimeInteresctionWith(pInterval);
            }
            return lResult;
        }

        public bool SameDays(DateInterval pInterval)
        {
            bool lResult = false;
            int i = this.ActiveDays.Count-1;
            while ((lResult == false) && (i>=0))
            {
                Day day = this.ActiveDays[i];
                if (pInterval.ActiveDays.Contains(day))
                {
                    lResult = true;
                }
                i--;
            }
            return lResult;
        }

        public bool TimeInteresctionWith(DateInterval pInterval)
        {
            bool lResult = false;
            int i = this.ActiveHours.Count-1;
            while ((lResult == false) && (i >= 0))
            {
                TimeInterval pTimeInterval = this.ActiveHours[i];
                int j = pInterval.ActiveHours.Count-1;
                while ((lResult == false) && (j >= 0))
                {
                    lResult = pTimeInterval.IntersectionWith(pInterval.ActiveHours[j]);
                    j--;
                }
                i--;
            }
            return lResult;
        }

        public bool ActiveForDay()
        {
            bool lResult = false;
            int today = (int)DateTime.Now.DayOfWeek;
            int i = this.ActiveDays.Count - 1;
            while ((lResult == false) && (i >= 0))
            {
                int day = (int)this.ActiveDays[i].Value;
                lResult = (today == day);
                i--;
            }
            return lResult;
        }

        public bool ActiveForTime()
        {
            bool lResult = false;
            TimeSpan timeNow = DateTime.Now.TimeOfDay;
            int i = this.ActiveHours.Count - 1;
            while ((lResult == false) && (i >= 0))
            {
                TimeInterval pInterval = this.ActiveHours[i];
                lResult = ((timeNow > pInterval.Start) && (timeNow < pInterval.End));
                i--;
            }
            return lResult;
        }

        /*int i = this.ActiveDays.Count-1;
            while ((lResult == false) && (i>=0))
            {
                Day day = this.ActiveDays[i];
                if (pInterval.ActiveDays.Contains(day))
                {
                    lResult = true;
                }
                i--;
            }*/

        /*public bool OverlapsWith(DateInterval pLapse)
        {
            bool lResult = false;

            if (this.ActiveFrom > pLapse.ActiveUntil ||
                this.ActiveUntil < pLapse.ActiveFrom)
            {
                lResult = false;
            }
            else
            {
                int i = 0;

                while (!lResult)
                {
                    Days day = this.DiasDeLaSemana[i];

                    if (pLapse.DiasDeLaSemana.Contains(day))
                    {
                        if (this.StartTime > pLapse.EndTime ||
                            this.EndTime < pLapse.StartTime)
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
        }*/
        // TODO resivar esto, afecta tests
    }
}
