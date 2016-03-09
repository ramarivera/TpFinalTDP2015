using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria.Criterion
{
    public class StartsBefore : ScheduleCriteria
    {
        public StartsBefore(DateTime pStart) : base()
        {
            this.iExpr = (sche) => sche.ActiveFrom > pStart;
        }
    }
}
