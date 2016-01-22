using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class CampaignInterval
    {
        private string iName;
        private DateTime iStartDate;
        private DateTime iEndDate;
        private TimeSpan iStartTime;
        private TimeSpan iEndTime;



        public DateTime StartDate
        {
            get { return this.iStartDate; }
            set
            {
                if (value <= this.iEndDate)
                {
                    this.iStartDate = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }
        public DateTime EndDate
        {
            get { return this.iEndDate; }
            set
            {
                if (value >= this.iStartDate)
                {
                    this.iEndDate = value;
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
                    this.iEndTime = value;
                }
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }
        public List<Dia> DiasDeLaSemana { get; set; }

        public string Name
        {
            get { return this.iName; }
            set { this.iName = value; }
        }

        public CampaignInterval()
        {
            this.DiasDeLaSemana = new List<Dia>();
            this.StartDate = new DateTime(1);
            this.EndDate = new DateTime(2);
            this.StartTime = new TimeSpan(1);
            this.EndTime = new TimeSpan(2);

        }

        public bool OverlapsWith(CampaignInterval pLapse)
        {
            bool lResult = false;

            if (this.StartDate > pLapse.EndDate ||
                this.EndDate < pLapse.StartDate)
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
