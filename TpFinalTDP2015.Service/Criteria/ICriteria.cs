using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria
{
    public abstract class Criteria<T> : ICriteria<T>
    {
        protected Expression<Func<T, bool>> iExpr;

        internal Criteria() { }

        public Expression<Func<T, bool>> Predicate
        {
            get
            {
                return this.iExpr;
            }
        }

        public IQueryable<T> MeetCriteria(IQueryable<T> pEntities)
        {
            return pEntities.Where(this.Predicate);
        }
    }

    internal interface ICriteria<T>
    {
        Expression<Func<T, bool>> Predicate { get; }

        IQueryable<T> MeetCriteria(IQueryable<T> pEntities);
    }
}
