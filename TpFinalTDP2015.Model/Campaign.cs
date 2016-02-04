using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class Campaign : BaseEntity
    {
        private string iName;
        private string iDescription;
        private IList<DateInterval> iActiveIntervals;
        private IList<Slide> iSlides;
        //TODO accesores con modificacion de fecha para CampaginInterval

        public Campaign() : base()
        {
            this.iActiveIntervals = new List<DateInterval>();
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

        public virtual string Description
        {
            get { return this.iDescription; }
            set
            {
                this.UpdateModificationDate();
                this.iDescription = value;
            }
        }

        public virtual IList<DateInterval> ActiveIntervals
        {
            get
            {
                return this.iActiveIntervals;// Clone<IList<DateInterval>>();
            }
            private set
            {
                this.UpdateModificationDate();
                this.iActiveIntervals = value;
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
                this.UpdateModificationDate();
                this.iSlides = value;
            }
        }

        public virtual void AddDateInterval(DateInterval pInterval)
        {

            //TODO agregar la verificacion de que no se choquen y bla bla bla
            this.UpdateModificationDate();
            this.iActiveIntervals.Add(pInterval);
        }

        public virtual void RemoveDateInterval(DateInterval pInterval)
        {
            this.UpdateModificationDate();
            this.iActiveIntervals.Remove(pInterval);
        }

        public virtual void AddSlide(Slide pSlide)
        {
            this.UpdateModificationDate();
            this.iSlides.Add(pSlide);
        }

        public virtual void RemoveSlide(Slide pSlide)
        {
            this.UpdateModificationDate();
            this.iSlides.Remove(pSlide);
        }

        public bool Active
        {
            get {return this.ActiveForDate(DateTime.Now); }
        }

        public bool ActiveForDate(DateTime pDate)
        {
            bool lResult = false;
            int i = this.ActiveIntervals.Count - 1;
            while ((lResult == false) && (i >= 0))
            {
                DateInterval pInterval = this.ActiveIntervals[i];
                lResult = pInterval.IsActive(pDate);
                i--;
            }
            return lResult;
        }
    }
}
