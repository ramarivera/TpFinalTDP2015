using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria
{
    internal class AndCriteria<T> : Criteria<T>
    {
        internal AndCriteria(Criteria<T> pUnCriterio, Criteria<T> pOtroCriterio)
        {
            this.iExpr = pUnCriterio.Expression.And(pOtroCriterio.Expression);
        }
    }
}
