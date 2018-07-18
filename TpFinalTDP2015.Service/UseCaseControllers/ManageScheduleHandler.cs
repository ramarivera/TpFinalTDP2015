using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Persistence;
using System;
using System.Collections.Generic;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageScheduleHandler: IController, IDisposable
    {
        private readonly IScheduleService iServ;
        private readonly IUnitOfWork iUoW;


        public ManageScheduleHandler(IScheduleService pService, IUnitOfWork pUoW)
        {
            this.iUoW = pUoW;
            this.iServ = pService;
        }


        public int AddSchedule(ScheduleDTO pDto)
        {
            iUoW.BeginTransaction();
            try
            {
                Schedule lSchedule = Mapper.Map<ScheduleDTO, Schedule>(pDto);
                iServ.Create(lSchedule);
                iUoW.Commit();
                return lSchedule.Id;
            }
            catch (Exception)
            {
                iUoW.Rollback();
                throw;
            }
                
        }

        public void ModifySchedule(ScheduleDTO pDto)
        {
            iUoW.BeginTransaction();
            try
            {
                Schedule lSchedule = Mapper.Map<ScheduleDTO, Schedule>(pDto);
                iServ.Update(lSchedule);
                iUoW.Commit();
            }
            catch (Exception)
            {
                iUoW.Rollback();
                throw;
            }
        }

        public void DeleteSchedule(ScheduleDTO pDto)
        {
            iUoW.BeginTransaction();
            try
            {
                Schedule lSchedule = Mapper.Map<ScheduleDTO, Schedule>(pDto);
                iServ.Delete(pDto.Id);
                iUoW.Commit();
            }
            catch (Exception)
            {
                iUoW.Rollback();
                throw;
            }
        }


        public IList<ScheduleDTO> ListSchedules()
        {
            IList<ScheduleDTO> lResult = new List<ScheduleDTO>();

            iUoW.BeginTransaction(); 
            try
            {
                foreach (var sche in iServ.GetAll())
                {
                    ScheduleDTO lDto = Mapper.Map<Schedule, ScheduleDTO>(sche);
                    lResult.Add(lDto);
                }
            }
            finally
            {
                iUoW.Rollback();
            }

            return lResult;
        }

        public ScheduleDTO GetSchedule(int pId)
        {
            ScheduleDTO lResult = new ScheduleDTO();

            iUoW.BeginTransaction();
            try
            {
                lResult = Mapper.Map<Schedule, ScheduleDTO>(iServ.Read(pId));
            }
            finally
            {
                iUoW.Rollback();
            }

            return lResult;
            //TODO esto lo comenté y no lo borré por el tema del helper, por las dudas
            //  Schedule lTemp;

            //      lTemp = serv.Read(pId);
            //      //lResult = MapperHelper.Map<Schedule, ScheduleDTO>(lTemp, lResult);
            //      lResult = Mapper.Map<Schedule, ScheduleDTO>(lTemp);

            ////  lResult = MapperHelper.Map<Schedule,ScheduleDTO>(lTemp,lResult);
            //  return lResult;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.iUoW.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
    