using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageScheduleHandler
    {


        public void AddSchedule(DateIntervalDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<DateIntervalService>())
            {
                serv.Save(pDto);
            }
        }

        public void UpdateSchedule(DateIntervalDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<DateIntervalService>())
            {
                serv.Save(pDto);
            }
        }

        public void DeleteSchedule(DateIntervalDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<DateIntervalService>())
            {
                serv.Delete(pDto);
            }
        }


        public IList<DateIntervalDTO> ListSchedules()
        {
            IList<DateIntervalDTO> lResult = new List<DateIntervalDTO>();

            using (var serv = BusinessServiceLocator.Resolve<DateIntervalService>())
            {
                lResult = serv.GetAll();
            }

            return lResult;
        }
    }
}
