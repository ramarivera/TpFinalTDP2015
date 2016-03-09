using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria.Criterion
{
    public class BeforeDateCriterion : Criteria<Evento>
    {
        private DateTime iFecha;

        public BeforeDateCriterion(DateTime pFecha)
        {
            iFecha = pFecha;
        }


        IList<Evento> Criteria<Evento>.MeetCriteria(IList<Evento> pEntidades)
        {
            var lResultado = from ent in pEntidades
                             where ent.FechaComienzo <= this.iFecha
                             select ent;

            return lResultado.ToList();
        }
    }
}
