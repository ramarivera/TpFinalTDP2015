﻿using AutoMapper;
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


        public void AddSchedule(ScheduleDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<ScheduleService>())
            {
                Schedule lSchedule = Mapper.Map<ScheduleDTO, Schedule>(pDto);
                serv.Save(lSchedule);
            }
        }

        public void ModifySchedule(ScheduleDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<ScheduleService>())
            {
                Schedule lSchedule = Mapper.Map<ScheduleDTO, Schedule>(pDto);
                serv.Save(lSchedule);
            }
        }

        public void DeleteSchedule(int pId)
        {
            using (var serv = BusinessServiceLocator.Resolve<ScheduleService>())
            {
                serv.Delete(pId);
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
    }
}