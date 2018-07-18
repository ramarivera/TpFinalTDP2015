using log4net;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class ScheduleService : IScheduleService
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<ScheduleService>();
        private readonly IRepository<Schedule> iRepo;
        public ScheduleService(IRepository<Schedule> pRepo)
        {
            this.iRepo = pRepo;
        }

        int ICrudService<Schedule>.Create(Schedule pSchedule)
        {
            iRepo.Add(pSchedule);
            return pSchedule.Id;
        }

        Schedule ICrudService<Schedule>.Read(int pId)
        {
            return iRepo.GetByID(pId);
        }

        int ICrudService<Schedule>.Update(Schedule pSchedule)
        {
            iRepo.Update(pSchedule);
            return pSchedule.Id;
        }

        void ICrudService<Schedule>.Delete(int pId)
        {
            iRepo.Delete(pId);
        }

        IEnumerable<Schedule> ICrudService<Schedule>.GetAll()
        {
            return iRepo.GetAll().ToList();
        }

        //public void Insert(Schedule pSchedule)
        //{
        //    iUoW.BeginTransaction();
        //    IRepository<ScheduleEntry> lTimeRepo = iUoW.GetRepository<ScheduleEntry>();
        //    IRepository<Schedule> lDateRepo = iUoW.GetRepository<Schedule>();
        //    IRepository<Day> lDayRepo = iUoW.GetRepository<Day>();

        //    var dayList = pSchedule.ActiveDays.Select(d => d.Id).ToList();

        //    pSchedule.RemoveAllDays();

        //    lDateRepo.Add(pSchedule);

        //    foreach (ScheduleEntry lHours in pSchedule.ActiveHours)
        //    {
        //        if (lHours.Id != 0)
        //        {
        //            lTimeRepo.Update(lHours);
        //        }
        //    }

        //    foreach (int item in dayList)
        //    {
        //        pSchedule.AddDay(lDayRepo.GetByID(item));
        //    }

        //    iUoW.Commit();
        //}

        //public void Update(Schedule pSchedule)
        //{
        //    iUoW.BeginTransaction();
        //    Schedule lSchedule;
        //    IRepository<ScheduleEntry> lTimeRepo = iUoW.GetRepository<ScheduleEntry>();
        //    IRepository<Schedule> lDateRepo = iUoW.GetRepository<Schedule>();
        //    IRepository<Day> lDayRepo = iUoW.GetRepository<Day>();


        //    lDateRepo.Update(pSchedule);
        //    lSchedule = lDateRepo.GetByID(pSchedule.Id);

        //    foreach (ScheduleEntry lHours in pSchedule.ActiveHours)
        //    {
        //        if (lHours.Id == 0)
        //        {
        //            lSchedule.AddTimeInterval(lHours);
        //        }
        //        else
        //        {
        //            lTimeRepo.Update(lHours);
        //        }
        //    }

        //    foreach (ScheduleEntry lOrigTimeInt in lSchedule.ActiveHours.Reverse())
        //    {
        //        if (!pSchedule.ActiveHours.Any(ti => ti.Id == lOrigTimeInt.Id))
        //        {
        //            lSchedule.RemoveTimeInterval(lOrigTimeInt);
        //            lTimeRepo.Delete(lOrigTimeInt.Id);
        //        }
        //    }


        //    lSchedule.RemoveAllDays();

        //    foreach (int item in pSchedule.ActiveDays.Select(d => d.Id))
        //    {
        //        lSchedule.AddDay(lDayRepo.GetByID(item));
        //    }

        //    iUoW.Commit();

        //}

        ///// <summary>
        ///// CORREGIR EL CLEAR COMENTADO!!!!
        ///// </summary>
        ///// <param name="pSchedule"></param>
        ///// <returns></returns>
        //public override int Save(Schedule pSchedule)
        //{
        //    this.Update(pSchedule);
        //    return default(int);
        //}

        //public override void Delete(int pId)
        //{
        //    iUoW.BeginTransaction();
        //    iUoW.GetRepository<Schedule>().Delete(pId);
        //    iUoW.Commit();
        //}

        ////TODO hacer que entre un Expression<Func<IDTO, bool>> pPredicate = null y se pueda usar en el getall del repo
        //public override IList<Schedule> GetAll()
        //{

        //    IRepository<Schedule> lRepo = iUoW.GetRepository<Schedule>();
        //    IList<Schedule> lResult = lRepo.GetAll().ToList<Schedule>();

        //    return lResult;
        //}

        //public override Schedule Get(int pId)
        //{
        //    IRepository<Schedule> lRepo = iUoW.GetRepository<Schedule>();

        //    var lResult = lRepo.GetByID(pId);

        //    return (Schedule) lResult;
        //}


    }
}
