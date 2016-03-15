using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using MarrSystems.TpFinalTDP2015.Model.Interfaces;
using MarrSystems.TpFinalTDP2015.Model.Exceptiones;

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

        public bool IsActiveAt(IScheduleChecker pValidator, DateTime pDate)
        {
            return pValidator.IsActiveAt(this, pDate);
        }

        public virtual void AddSchedule(IScheduleChecker pValidator, Schedule pInterval)
        {
            if (pInterval == null)
            {
                throw new EntidadNulaException("El intervalo de fechas indicado es nulo");
            }
            else if (!pValidator.CanAddSchedule(this, pInterval))
            {
                throw new IntervaloFechaInvalidoException("El intervalo de fechas indicado no puede ser agregado al Banner debido a que se superpone con un intervalo existente");
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
