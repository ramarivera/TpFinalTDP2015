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

        // TODO accesores con fecha de modifcacion para Days
        public DateInterval() : base()
        {
            this.ActiveFrom = new DateTime(1);
            this.ActiveUntil = new DateTime(2);
            this.ActiveHours = new List<TimeInterval>();
            this.ActiveDays = new List<Day>();
            //this.StartTime = new TimeSpan(1);
            //this.EndTime = new TimeSpan(2);
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
                if (value <= this.iActiveUntil)
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
                if (value >= this.iActiveFrom)
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
