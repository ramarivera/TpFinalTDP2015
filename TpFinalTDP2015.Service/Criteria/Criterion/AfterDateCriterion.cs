using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria.Criterion
{
    public class AfterDateCriterion : Criteria<Evento>
    {
        private DateTime iFecha;

        public AfterDateCriterion(DateTime pFecha)
        {
            iFecha = pFecha;
        }


        IEnumerable<Evento> Criteria<Evento>.MeetCriteria(IEnumerable<Evento> pEntidades)
        {
            var lResultado = from ent in pEntidades
                             where ent.FechaComienzo >= this.iFecha
                             select ent;

            return lResultado.ToList();
        }
    }
}
