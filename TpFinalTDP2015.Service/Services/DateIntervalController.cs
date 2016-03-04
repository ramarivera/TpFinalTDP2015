using AutoMapper;
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
    public class DateIntervalController : BaseService<DateIntervalDTO>
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<DateIntervalController>();

        public DateIntervalController(IUnitOfWork iUoW) : base(iUoW)
        {

        }

        /// <summary>
        /// CORREGIR EL CLEAR COMENTADO!!!!
        /// </summary>
        /// <param name="pDateInterval"></param>
        /// <returns></returns>
        public override int Save(DateIntervalDTO pDateInterval)
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
                        lOrigDateInt.AddTimeInterval(lHours);
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
                        lOrigDateInt.RemoveTimeInterval(lOrigTimeInt);
                        lTimeRepo.Delete(lOrigTimeInt.Id);
                    }
                }

                /*  foreach (Day day in lOrigDateInt.ActiveDays.Reverse())
                  {
                      lOrigDateInt.RemoveActiveDay(day);
                  }*/

                // lOrigDateInt.ActiveDays.Clear();

                lOrigDateInt.RemoveAllDays();

                foreach (int item in lDateInterval.ActiveDays.Select(d => d.Id))
                {

                    lOrigDateInt.AddDay(lDayRepo.GetByID(item));
                    //  lDayRepo.Update(item);
                }    
            }
            iUoW.Commit();
            return lDateInterval.Id;
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

        public override DateIntervalDTO Get(int pId)
        {
            DateIntervalDTO lResult = new DateIntervalDTO();

            IRepository<DateInterval> lRepo = iUoW.GetRepository<DateInterval>();

            var lTemp = lRepo.GetByID(pId);

            lResult = Mapper.Map<DateInterval, DateIntervalDTO>(lTemp);

            return lResult;
        }
    }
}
