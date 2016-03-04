using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using MarrSystems.TpFinalTDP2015.Model.Interfaces;

namespace MarrSystems.TpFinalTDP2015.Model
{
    [Serializable]
    public class Banner : BaseEntity, IHasSchedules
    {
        public Banner() : base()
        {
            this.BannerItems = new List<BaseBannerItem>();
            this.ActivePeriods = new List<Schedule>();
            this.RSSSources = new List<RssSource>();
        }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        protected virtual IList<Schedule> ActivePeriods { get; set; }
      
        protected virtual IList<BaseBannerItem> BannerItems { get; set; }

        protected virtual IList<RssSource> RSSSources { get; set; }


        public virtual IEnumerable<Schedule> Schedules
        {
            get
            {
                return this.ActivePeriods;
            }
        }

        public virtual IEnumerable<BaseBannerItem> Items
        {
            get
            {
                return this.BannerItems;
            }
        }

        public virtual IEnumerable<RssSource> RssSources
        {
            get
            {
                return this.RSSSources;
            }
        }

        public virtual void AddSchedule(IScheduleChecker pValidator, Schedule pInterval)
        {
            if (pInterval == null)
            {
                throw new ArgumentNullException();
            }
            else if (!pValidator.CanAddSchedule(this, pInterval))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.ActivePeriods.Add(pInterval);

                //TODO excepción si no es valido por interseccion, si es intervalo nulo. irian arriba
            }
        }

        public void RemoveSchedule(Schedule pSchedule)
        {
            this.ActivePeriods.Remove(pSchedule);
        }

        public void RemoveAllSchedules()
        {
            foreach (var sche in this.Schedules.Reverse())
            {
                RemoveSchedule(sche);
            }
        }

        public virtual void AddBannerItem(BaseBannerItem pItem)
        {
            if(pItem == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.BannerItems.Add(pItem);
            }
            //TODO verificar que ya no este? donde se llame al método
        }

        public virtual void RemoveBannerItem(BaseBannerItem pItem)
        {
            this.BannerItems.Remove(pItem);
        }

        public virtual void AddSource(RssSource pSource)
        {
            this.RSSSources.Add(pSource);
            //TODO verificar que ya no este? donde se llame al metodo
        }

        public virtual void RemoveSource(RssSource pSource)
        {
            this.RSSSources.Remove(pSource);
        }

        public bool IsActiveAt(IScheduleChecker pValidator, DateTime pDate)
        {
            return pValidator.IsActiveAt(this, pDate);
        }

    }
}
