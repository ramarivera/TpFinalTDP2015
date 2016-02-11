using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using TpFinalTDP2015.Persistence.Interfaces;
using Microsoft.Practices.Unity;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Service.DTO;
using AutoMapper;

namespace TpFinalTDP2015.Service.Controllers
{
    public class DateIntervalController
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<DateIntervalController>();

        private IUnitOfWork iUoW;


        public DateIntervalController()
        {
            cLogger.Info("Fachada instanciada");

            using (iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();

                cLogger.InfoFormat("Usando {0} como implementacion de {1}", new[] { iUoW.GetType().Name, typeof(IUnitOfWork).Name });

                iUoW.Commit();
            }
        }

        private IUnitOfWork GetUnitOfWork()
        {
            return IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>();
        }
        public IList<DateIntervalDTO> GetDateIntervals()
        {
            IList<DateIntervalDTO> lResult = new List<DateIntervalDTO>();

            using (this.iUoW = GetUnitOfWork())
            {
                IRepository<DateInterval> lRepo = iUoW.GetRepository<DateInterval>();
                IList<DateInterval> lTemp = lRepo.GetAll().ToList();

                foreach (var dateInterval in lTemp)
                {
                    DateIntervalDTO lDto = Mapper.Map<DateInterval, DateIntervalDTO>(dateInterval);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public IList<TimeIntervalDTO> GetTimeIntervals(DateIntervalDTO pDateInterval)
        {
            IList<TimeIntervalDTO> lResult = new List<TimeIntervalDTO>();
            foreach (TimeIntervalDTO timeInterval in pDateInterval.ActiveHours)
            {
                lResult.Add(timeInterval);
            }
            return lResult;
        }

        public void SaveDateInterval(DateIntervalDTO pDateInterval)
        {
            using (this.iUoW = GetUnitOfWork())
            {

                iUoW.BeginTransaction();
                IRepository<TimeInterval> lTimeRepo = iUoW.GetRepository<TimeInterval>();
                IRepository<DateInterval> lDateRepo = iUoW.GetRepository<DateInterval>();
               IRepository<Day> lDayRepo = iUoW.GetRepository<Day>();

                DateInterval lDateInterval = Mapper.Map<DateIntervalDTO, DateInterval>(pDateInterval);

                if (pDateInterval.Id == 0)
                {
                    lDateRepo.Add(lDateInterval);
                }
                else
                {
                    DateInterval lOrigDateInt = (from date in lDateRepo.GetAll()
                                                 where date.Id == lDateInterval.Id
                                                 select date).FirstOrDefault();


                    foreach (TimeInterval lHours in lDateInterval.ActiveHours)
                    {
                        if (lHours.Id == 0)
                        {
                            lTimeRepo.Add(lHours);
                        }
                        else
                        {
                            lTimeRepo.Update(lHours);
                        }
                    }

                    lDateRepo.Update(lDateInterval);


                    foreach (TimeInterval lOrigTimeInt in lOrigDateInt.ActiveHours.Reverse<TimeInterval>())
                    {
                        if (!lDateInterval.ActiveHours.Any(ti => ti.Id == lOrigTimeInt.Id))
                        {
                            lTimeRepo.Delete(lOrigTimeInt.Id);
                        }
                    }


                    IList<int> lDayCopy = new List<int>(lDateInterval.ActiveDays.Select(d => d.Id));
                    // IList<Day> lDayList = lDayRepo.GetAll().ToList();

                    foreach (Day day in lDateInterval.ActiveDays.Reverse())
                    {
                        lDateInterval.ActiveDays.Remove(day);
                    }

                    foreach (int  lDay in lDayCopy)
                    {
                        lDateInterval.ActiveDays.Add(lDayRepo.GetByID(lDay));
                    }


                }

                iUoW.Commit();
            }
        }

        public void DeleteDateInterval(DateIntervalDTO pDateInterval)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<DateInterval> lRepo = iUoW.GetRepository<DateInterval>();
                DateInterval lDateInterval = Mapper.Map<DateIntervalDTO, DateInterval>(pDateInterval);
                lRepo.Delete(lDateInterval.Id);
                iUoW.Commit();
            }

        }
    }
}
