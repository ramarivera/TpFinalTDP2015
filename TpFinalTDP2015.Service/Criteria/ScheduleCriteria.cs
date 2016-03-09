using MarrSystems.TpFinalTDP2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria
{
    public class ScheduleCriteria : Criteria<Schedule>
    {
        IList<Schedule> Criteria<Schedule>.MeetCriteria(IList<Schedule> pEntity)
        {
           return pEntity.Where("String").ToList();
        }
    }
}
