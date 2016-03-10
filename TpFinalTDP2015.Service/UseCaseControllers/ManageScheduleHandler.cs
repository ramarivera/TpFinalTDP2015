﻿using AutoMapper;
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
    public class ManageScheduleHandler
    {


        public int AddSchedule(ScheduleDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<ScheduleService>())
            {
                Schedule lSchedule = Mapper.Map<ScheduleDTO, Schedule>(pDto);
                serv.Insert(lSchedule);
                return lSchedule.Id;
            }
        }

        public int ModifySchedule(ScheduleDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<ScheduleService>())
            {
                Schedule lSchedule = Mapper.Map<ScheduleDTO, Schedule>(pDto);
                serv.Save(lSchedule);
                return lSchedule.Id;
            }
        }

        public void DeleteSchedule(ScheduleDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<ScheduleService>())
            {
                serv.Delete(pDto.Id);
            }
        }


        public IList<ScheduleDTO> ListSchedules()
        {
            IList<ScheduleDTO> lResult = new List<ScheduleDTO>();

            using (var serv = BusinessServiceLocator.Resolve<ScheduleService>())
            {
                foreach (var sche in serv.GetAll())
                {
                    ScheduleDTO lDto = Mapper.Map<Schedule, ScheduleDTO>(sche);
                    lResult.Add(lDto);
                }
            }

            return lResult;
        }

        public ScheduleDTO GetSchedule(int pId)
        {
            ScheduleDTO lResult = new ScheduleDTO();
            Schedule lTemp;

            using (var serv = BusinessServiceLocator.Resolve<ScheduleService>())
            {
                lTemp = serv.Get(pId);
                //lResult = MapperHelper.Map<Schedule, ScheduleDTO>(lTemp, lResult);
                lResult = Mapper.Map<Schedule, ScheduleDTO>(lTemp);
            }

          //  lResult = MapperHelper.Map<Schedule,ScheduleDTO>(lTemp,lResult);
            return lResult;
        }
    }
}
    