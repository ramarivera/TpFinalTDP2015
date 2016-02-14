using AutoMapper;
using Common.Logging;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.CrossCutting;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Persistence.EntityFramework;
using TpFinalTDP2015.Persistence.Interfaces;
using TpFinalTDP2015.Service.DTO;

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
                    lDateRepo.Update(lDateInterval);


                 //   DateInterval lOrigDateInt = lDateRepo.GetAll(d => d.Id == lDateInterval.Id).Single();
                    DateInterval lOrigDateInt = lDateRepo.GetByID(lDateInterval.Id);




                    foreach (TimeInterval lHours in lDateInterval.ActiveHours)
                    {
                        if (lHours.Id == 0)
                        {
                            lOrigDateInt.AddActiveHours(lHours);
                        }
                        else
                        {
                            //lOrigDateInt.AddActiveHours(lHours);
                            lTimeRepo.Update(lHours);
                        }
                    }

                    //   lDateRepo.Update(lDateInterval);


                    foreach (TimeInterval lOrigTimeInt in lOrigDateInt.ActiveHours.Reverse<TimeInterval>())
                    {
                        if (!lDateInterval.ActiveHours.Any(ti => ti.Id == lOrigTimeInt.Id))
                        {
                            lOrigDateInt.RemoveActiveHours(lOrigTimeInt);
                            lTimeRepo.Delete(lOrigTimeInt.Id);
                        }
                    }

                    /*  foreach (Day day in lOrigDateInt.ActiveDays.Reverse())
                      {
                          lOrigDateInt.RemoveActiveDay(day);
                      }*/

                    lOrigDateInt.ActiveDays.Clear();

                    foreach (int item in lDateInterval.ActiveDays.Select(d => d.Id))
                    {
                        lOrigDateInt.AddActiveDay(lDayRepo.GetByID(item));
                        //  lDayRepo.Update(item);
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
