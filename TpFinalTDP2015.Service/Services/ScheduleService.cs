﻿using AutoMapper;
using Common.Logging;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Persistence.EntityFramework;
using MarrSystems.TpFinalTDP2015.Persistence;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class ScheduleService : BaseService<Schedule>
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<ScheduleService>();

        public ScheduleService(IUnitOfWork iUoW) : base(iUoW)
        {

        }

        /// <summary>
        /// CORREGIR EL CLEAR COMENTADO!!!!
        /// </summary>
        /// <param name="pSchedule"></param>
        /// <returns></returns>
        public override int Save(Schedule pSchedule)
        {
            iUoW.BeginTransaction();
            IRepository<ScheduleEntry> lTimeRepo = iUoW.GetRepository<ScheduleEntry>();
            IRepository<Schedule> lDateRepo = iUoW.GetRepository<Schedule>();
            IRepository<Day> lDayRepo = iUoW.GetRepository<Day>();


            if (pSchedule.Id == 0)
            {
                lDateRepo.Add(pSchedule);
            }
            else
            {
                lDateRepo.Update(pSchedule);


                //   DateInterval lOrigSchedule = lDateRepo.GetAll(d => d.Id == lDateInterval.Id).Single();
                Schedule lOrigSchedule = lDateRepo.GetByID(pSchedule.Id);




                foreach (ScheduleEntry lHours in pSchedule.ActiveHours)
                {
                    if (lHours.Id == 0)
                    {
                        lOrigSchedule.AddTimeInterval(lHours);
                    }
                    else
                    {
                        //lOrigSchedule.AddActiveHours(lHours);
                        lTimeRepo.Update(lHours);
                    }
                }

                //   lDateRepo.Update(lDateInterval);


                foreach (ScheduleEntry lOrigTimeInt in lOrigSchedule.ActiveHours.Reverse())
                {
                    if (!pSchedule.ActiveHours.Any(ti => ti.Id == lOrigTimeInt.Id))
                    {
                        lOrigSchedule.RemoveTimeInterval(lOrigTimeInt);
                        lTimeRepo.Delete(lOrigTimeInt.Id);
                    }
                }

                /*  foreach (Day day in lOrigSchedule.ActiveDays.Reverse())
                  {
                      lOrigSchedule.RemoveActiveDay(day);
                  }*/

                lOrigSchedule.RemoveAllDays();

                foreach (int item in pSchedule.ActiveDays.Select(d => d.Id))
                {
                    lOrigSchedule.AddDay(lDayRepo.GetByID(item));
                    //  lDayRepo.Update(item);
                }    
            }

            iUoW.Commit();

            return pSchedule.Id;
        }

        public override void Delete(int pId)
        {
            iUoW.BeginTransaction();
            iUoW.GetRepository<Schedule>().Delete(pId);
            iUoW.Commit();
        }

        //TODO hacer que entre un Expression<Func<IDTO, bool>> pPredicate = null y se pueda usar en el getall del repo
        public override IList<Schedule> GetAll()
        {

            IRepository<Schedule> lRepo = iUoW.GetRepository<Schedule>();
            IList<Schedule> lResult = lRepo.GetAll().ToList();
            
            return lResult;
        }

        public override Schedule Get(int pId)
        {
            Schedule lResult = null;
            IRepository<Schedule> lRepo = iUoW.GetRepository<Schedule>();

            lResult = lRepo.GetByID(pId);

            return lResult;
        }
    }
}