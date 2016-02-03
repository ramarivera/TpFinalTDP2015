using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class Banner: BaseEntity
    {
        private string iName;
        private string iDescription;
        private IList<BaseBannerItem> iItems;
        private IList<DateInterval> iActiveIntervals;


        public Banner() : base()
        {
            this.iItems = new List<BaseBannerItem>();
            this.iActiveIntervals = new List<DateInterval>();
        }
        //TODO : accesores con actualizacion de la fecha de odificacion para listas de ibanner y campagininterval;

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

        public virtual IList<BaseBannerItem> Items
        {
            get
            {
                return this.iItems;// Clone<IList<BaseBannerItem>>();
            }
            private set
            {
                this.UpdateModificationDate();
                this.iItems = value;
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

        public virtual void AddBannerItem(BaseBannerItem pItem)
        {
            this.UpdateModificationDate();
            this.iItems.Add(pItem);
        }

        public virtual void RemoveBannerItem(BaseBannerItem pItem)
        {
            this.UpdateModificationDate();
            this.iItems.Remove(pItem);
        }

        public bool Active
        {
            get { return this.ActiveForDate(DateTime.Now); }
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
