using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;

namespace MarrSystems.TpFinalTDP2015.Model
{
    [Serializable]
    public class Banner : BaseEntity, ICosoQueTieneDateInterval
    {
        private string iName;
        private string iDescription;
        private IList<BaseBannerItem> iItems;
        private IList<RssSource> iRssSources;
        private IList<DateInterval> iActiveIntervals;


        public Banner() : base()
        {
            this.iItems = new List<BaseBannerItem>();
            this.iActiveIntervals = new List<DateInterval>();
            this.iRssSources = new List<RssSource>();
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
                return this.iActiveIntervals;
            }
            private set
            {
                this.iActiveIntervals = value;
            }
        }

        public virtual IList<BaseBannerItem> Items
        {
            get
            {
                return this.iItems;
            }
            private set
            {
                this.iItems = value;
            }
        }

        public virtual IList<RssSource> RssSources
        {
            get
            {
                return this.iRssSources;
            }
            private set
            {
                this.iRssSources = value;
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
            }
                //TODO excepción si no es valido por interseccion, si es intervalo nulo. irian arriba
        }

        public virtual void RemoveDateInterval(DateInterval pInterval)
        {
            this.iActiveIntervals.Remove(pInterval);
        }

       /* private bool CanBeAdded(DateInterval pInterval)
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

        public virtual void AddBannerItem(BaseBannerItem pItem)
        {
            if(pItem == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.iItems.Add(pItem);
            }
            //TODO verificar que ya no este? donde se llame al método
        }

        public virtual void RemoveBannerItem(BaseBannerItem pItem)
        {
            this.iItems.Remove(pItem);
        }

        public virtual void AddSource(RssSource pSource)
        {
            this.iRssSources.Add(pSource);
            //TODO verificar que ya no este? donde se llame al metodo
        }

        public virtual void RemoveSource(RssSource pSource)
        {
            this.iRssSources.Remove(pSource);
        }

       /* public bool IsActive
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
