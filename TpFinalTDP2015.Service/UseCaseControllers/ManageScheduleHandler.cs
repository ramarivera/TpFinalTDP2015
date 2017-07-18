using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageScheduleHandler: IController
    {
        private IScheduleService serv;


        public ManageScheduleHandler(IScheduleService pService)
        {
            this.serv = pService;
        }


        public int AddSchedule(ScheduleDTO pDto)
        {
                Schedule lSchedule = Mapper.Map<ScheduleDTO, Schedule>(pDto);
                serv.Create(lSchedule);
                return lSchedule.Id;
        }

        public int ModifySchedule(ScheduleDTO pDto)
        {
                Schedule lSchedule = Mapper.Map<ScheduleDTO, Schedule>(pDto);
                serv.Update(lSchedule);
                return lSchedule.Id;
        }

        public void DeleteSchedule(ScheduleDTO pDto)
        {
                serv.Delete(pDto.Id);
        }


        public IList<ScheduleDTO> ListSchedules()
        {
            IList<ScheduleDTO> lResult = new List<ScheduleDTO>();

                foreach (var sche in serv.GetAll())
                {
                    ScheduleDTO lDto = Mapper.Map<Schedule, ScheduleDTO>(sche);
                    lResult.Add(lDto);
                }

            return lResult;
        }

        public ScheduleDTO GetSchedule(int pId)
        {
            ScheduleDTO lResult = new ScheduleDTO();
            Schedule lTemp;

                lTemp = serv.Read(pId);
                //lResult = MapperHelper.Map<Schedule, ScheduleDTO>(lTemp, lResult);
                lResult = Mapper.Map<Schedule, ScheduleDTO>(lTemp);

          //  lResult = MapperHelper.Map<Schedule,ScheduleDTO>(lTemp,lResult);
            return lResult;
        }
    }
}
    