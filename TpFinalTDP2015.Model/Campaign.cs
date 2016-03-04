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
    public class Campaign : BaseEntity, IHasSchedules
    {
        private IList<Slide> iSlides;

        public Campaign() : base()
        {
            this.ActivePeriods = new List<Schedule>();
            
        }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        protected virtual IList<Schedule> ActivePeriods { get; set; }

        public virtual IEnumerable<Schedule> Schedules
        {
            get
            {
                return this.ActivePeriods;
            }
        }

        public virtual IList<Slide> Slides
        {
            get
            {
                return this.iSlides;
            }
            private set
            {
                this.iSlides = new List<Slide>(value);
            }
        }

        public virtual void AddSchedule(Schedule pInterval, IScheduleChecker pValitador)
        {
            if (pInterval == null)
            {
                throw new ArgumentNullException();
            }
            else if (!pValitador.CanAddSchedule(this,pInterval))
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

        public virtual void AddSlide(Slide pSlide)
        {
            this.iSlides.Add(pSlide);
        }

        public virtual void RemoveSlide(Slide pSlide)
        {
            this.iSlides.Remove(pSlide);
        }

        
    }
}
