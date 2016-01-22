using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class CampaignInterval : BaseEntity
    {
        private string iName;
        private DateTime iActiveFrom;
        private DateTime iActiveUntil;
        private TimeSpan iStartTime;
        private TimeSpan iEndTime;
        private IList<Days> iActiveDays;

        // TODO accesores con fecha de modifcacion para Days
        public CampaignInterval() : base()
        {
            this.DiasDeLaSemana = new List<Days>();
            this.ActiveFrom = new DateTime(1);
            this.ActiveUntil = new DateTime(2);
            this.StartTime = new TimeSpan(1);
            this.EndTime = new TimeSpan(2);
        }


        public DateTime ActiveFrom
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
        public DateTime ActiveUntil
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

        public IList<Days> DiasDeLaSemana { get; set; }

        public string Name
        {
            get { return this.iName; }
            set
            {
                this.UpdateModificationDate();
                this.iName = value;
            }
        }

        public bool OverlapsWith(CampaignInterval pLapse)
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
        }
    }
}
