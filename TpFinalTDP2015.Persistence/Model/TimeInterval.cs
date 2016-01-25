using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class TimeInterval: BaseEntity
    {
        private string iName;
        private TimeSpan iStartTime;
        private TimeSpan iEndTime;

        public string Name
        {
            get { return this.iName; }
            set
            {
                this.UpdateModificationDate();
                this.iName = value;
            }
        }

        public TimeSpan StartTime
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
        public TimeSpan EndTime
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
