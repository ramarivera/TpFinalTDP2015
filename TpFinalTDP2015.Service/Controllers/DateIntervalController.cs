﻿using System;
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
using TpFinalTDP2015.Persistence.EntityFramework;
using System.Linq.Expressions;

namespace TpFinalTDP2015.Service.Controllers
{
    public class DateIntervalController : BaseController<DateIntervalDTO>
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<DateIntervalController>();



        public DateIntervalController(IUnitOfWork iUoW) : base(iUoW)
        {
            cLogger.Info("Fachada instanciada");

                iUoW.BeginTransaction();

                cLogger.InfoFormat("Usando {0} como implementacion de {1}", new[] { iUoW.GetType().Name, typeof(IUnitOfWork).Name });

                iUoW.Commit();
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

        public override void Save(DateIntervalDTO pDateInterval)
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




                iUoW.Commit();
            }
        }

        public override void Delete(DateIntervalDTO pDateInterval)
        {
                iUoW.BeginTransaction();
                IRepository<DateInterval> lRepo = iUoW.GetRepository<DateInterval>();
                DateInterval lDateInterval = Mapper.Map<DateIntervalDTO, DateInterval>(pDateInterval);
                lRepo.Delete(lDateInterval.Id);
                iUoW.Commit();
        }

        //TODO hacer que entre un Expression<Func<IDTO, bool>> pPredicate = null y se pueda usar en el getall del repo
        public override IList<DateIntervalDTO> GetAll()
        {
            IList<DateIntervalDTO> lResult = new List<DateIntervalDTO>();

                IRepository<DateInterval> lRepo = iUoW.GetRepository<DateInterval>();
                IList<DateInterval> lTemp = lRepo.GetAll().ToList();

                foreach (var dateInterval in lTemp)
                {
                    DateIntervalDTO lDto = Mapper.Map<DateInterval, DateIntervalDTO>(dateInterval);
                    lResult.Add(lDto);
                }
            return lResult.ToList<DateIntervalDTO>();
        }

    }
}
