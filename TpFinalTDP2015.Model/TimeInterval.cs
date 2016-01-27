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
                if (value < this.iEndTime)
                {
                    this.UpdateModificationDate();
                    this.iStartTime = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }
        public virtual TimeSpan End
        {
            get { return this.iEndTime; }
            set
            {
                if (value > this.iStartTime)
                {
                    this.UpdateModificationDate();
                    this.iEndTime = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
