using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model.DomainServices;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class Campaign : BaseEntity, ICosoQueTieneDateInterval
    {
        private string iName;
        private string iDescription;
        private IList<DateInterval> iActiveIntervals;
        private IList<Slide> iSlides;

        public Campaign() : base()
        {
            this.iActiveIntervals = new List<DateInterval>();
        }


        public virtual string Name
        {
            get { return this.iName; }
            set { this.iName = value; }
        }

        public virtual string Description
        {
            get { return this.iDescription; }
            set { this.iDescription = value; }
        }

        public virtual IList<DateInterval> ActiveIntervals
        {
            get
            {
                return this.iActiveIntervals;// Clone<IList<DateInterval>>();
            }
            private set
            {
                this.iActiveIntervals = new List<DateInterval>(value);
            }
        }

        public virtual IList<Slide> Slides
        {
            get
            {
                return this.iSlides;// Clone<IList<Slides>();
            }
            private set
            {
                this.iSlides = new List<Slide>(value);
            }
        }

        public virtual void AddDateInterval(DateInterval pInterval, IIntervalValidator pValitador)
        {
            if (pInterval == null)
            {
                throw new ArgumentNullException();
            }
            else if (!pValitador.CanBeAdded(this,pInterval))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.iActiveIntervals.Add(pInterval);

                //TODO excepción si no es valido por interseccion, si es intervalo nulo. irian arriba
            }
        }

        public virtual void RemoveDateInterval(DateInterval pInterval)
        {
            this.iActiveIntervals.Remove(pInterval);
        }

        /*private bool CanBeAdded(DateInterval pInterval)
        {
            bool lResult = true;
            int i = this.ActiveIntervals.Count - 1;
            while ((lResult == true) && (i >= 0))
            {
                DateInterval lInterval = this.ActiveIntervals[i];
                if (!pInterval.IntersectsWith(lInterval))
                {
                    lResult = false;
                }
                i--;
            }
            return lResult;
        }*/

        public virtual void AddSlide(Slide pSlide)
        {
            this.iSlides.Add(pSlide);
        }

        public virtual void RemoveSlide(Slide pSlide)
        {
            this.iSlides.Remove(pSlide);
        }

        /*public bool IsActive
        {
            get { return this.IsActiveAt(DateTime.Now); }
        }

        public bool IsActiveAt(DateTime pDate)
        {
            bool lResult = false;
            int i = this.ActiveIntervals.Count - 1;
            while ((lResult == false) && (i >= 0))
            {
                DateInterval pInterval = this.ActiveIntervals[i];
                lResult = pInterval.IsActiveAt(pDate);
                i--;
            }
            return lResult;
        }*/
    }
}
