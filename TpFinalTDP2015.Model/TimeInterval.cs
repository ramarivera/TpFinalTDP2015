using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class TimeInterval: BaseEntity
    {
        private TimeSpan iStartTime;
        private TimeSpan iEndTime;

        private static readonly TimeSpan MIN_VALUE = new TimeSpan(0, 0, 0);
        private static readonly TimeSpan MAX_VALUE = new TimeSpan(23, 59, 59);  

        public TimeInterval() : base()
        {
            this.iStartTime = MIN_VALUE;
            this.iEndTime = MAX_VALUE;
        }

        public virtual TimeSpan Start
        {
            get { return this.iStartTime; }
            set
            {
                if ((value < this.iEndTime) && ((value >= MIN_VALUE) && (value <= MAX_VALUE)))
                {
                    this.iStartTime = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public virtual TimeSpan End
        {
            get { return this.iEndTime; }
            set
            {
                if ((value > this.iStartTime) && ((value >= MIN_VALUE) && (value <= MAX_VALUE)))
                {
                    this.iEndTime = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public bool IntersectsWith(TimeInterval pInterval)
        {
            bool lResult = false;
            if ((pInterval.Start > this.iStartTime) 
                && (pInterval.Start < this.iEndTime)) // hora de inicio de pInterval entre intervalo que llama
            {
                lResult = true;
            }
            else if ((pInterval.End > this.iStartTime) //hora de fin de pInteval entre intervalo que llama
                    && (pInterval.End < this.iEndTime))
            {
                lResult = true;
            }
            else if ((this.iStartTime > pInterval.Start) //hora de inicio de intervalo que llama entre pInterval
                    && (this.iStartTime < pInterval.Start))
            {
                lResult = true;
            }
            else if ((this.iEndTime > pInterval.Start) //hora de fin de intervalo que llama entre pInterval
                    && (this.iEndTime < pInterval.End))
            {
                lResult = true;
            }
            else if ((this.iStartTime == pInterval.Start)//intervalos iguales
                    &&(this.iEndTime == pInterval.End))
            {
                lResult = true;
            }
            return lResult;
        }
    }
}
