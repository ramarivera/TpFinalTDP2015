using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria
{
    internal class OrCriteria<T> : Criteria<T>
    {
        internal OrCriteria(Criteria<T> pUnCriterio, Criteria<T> pOtroCriterio)
        {
            this.iExpr = pUnCriterio.Expression.Or(pOtroCriterio.Expression);
        }
    }
}
