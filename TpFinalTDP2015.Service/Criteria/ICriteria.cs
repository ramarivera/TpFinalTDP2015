using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria
{
    internal abstract class Criteria<T>
    {
        protected Expression<Func<T, bool>> iExpr;

        internal Expression<Func<T, bool>> Expression
        {
            get
            {
                return this.iExpr;
            }
        }

        internal IQueryable<T> MeetCriteria(IQueryable<T> pEntities)
        {
            return pEntities.Where(this.Expression);
        }
    }
}
