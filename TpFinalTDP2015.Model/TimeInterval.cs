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

        private readonly TimeSpan MIN_VALUE = new TimeSpan(0, 0, 0);
        private readonly TimeSpan MAX_VALUE = new TimeSpan(23, 59, 59);  

        public TimeInterval() : base()
        {
            this.Start = new TimeSpan(1);
            this.End = new TimeSpan(2);
        }

        public virtual TimeSpan Start
        {
            get { return this.iStartTime; }
            set
            {
                if ((value < this.iEndTime) && ((value > MIN_VALUE) && (value < MAX_VALUE)))
                {
                    this.UpdateModificationDate();
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
                if ((value > this.iStartTime) && ((value > MIN_VALUE) && (value < MAX_VALUE)))
                {
                    this.UpdateModificationDate();
                    this.iEndTime = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public bool IntersectionWith(TimeInterval pInterval)
        {
            bool lResult = false;
            if ((pInterval.iStartTime > this.iStartTime) 
                && (pInterval.iStartTime < this.iEndTime)) // hora de inicio de pInterval entre intervalo que llama
            {
                lResult = true;
            }
            else if ((pInterval.iEndTime > this.iStartTime) //hora de fin de pInteval entre intervalo que llama
                    && (pInterval.iEndTime < this.iEndTime))
            {
                lResult = true;
            }
            else if ((this.iStartTime > pInterval.iStartTime) //hora de inicio de intervalo que llama entre pInterval
                    && (this.iStartTime < pInterval.iEndTime))
            {
                lResult = true;
            }
            else if ((this.iEndTime > pInterval.iStartTime) //hora de fin de intervalo que llama entre pInterval
                    && (this.iEndTime < pInterval.iEndTime))
            {
                lResult = true;
            }
            else if ((this.iStartTime == pInterval.iStartTime)//intervalos iguales
                    &&(this.iEndTime == pInterval.iEndTime))
            {
                lResult = true;
            }
            return lResult;
        }
    }
}
