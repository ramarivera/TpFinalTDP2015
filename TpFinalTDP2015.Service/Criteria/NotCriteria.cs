using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria
{

    internal class NotCriteria<T> : Criteria<T>
    {
        internal NotCriteria(Criteria<T> pUnCriterio)
        {
            this.iExpr = pUnCriterio.Predicate.Not();
        }
    }
}
