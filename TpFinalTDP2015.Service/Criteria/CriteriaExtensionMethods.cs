using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria
{
    public static class CriteriaExtensionMethods
    {
        internal static Criteria<T> And<T>(this Criteria<T> pUnCriterio, Criteria<T> pOtroCriterio)
        {
            return new AndCriteria<T>(pUnCriterio, pOtroCriterio);
        }

        internal static Criteria<T> Or<T>(this Criteria<T> pUnCriterio, Criteria<T> pOtroCriterio)
        {
            return new OrCriteria<T>(pUnCriterio, pOtroCriterio);
        }

        internal static Criteria<T> Not<T>(this Criteria<T> pUnCriterio)
        {
            return new NotCriteria<T>(pUnCriterio);
        }
    }
}
