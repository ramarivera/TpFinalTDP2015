using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria.Criterion
{
    public  class DayOfWeekCriterion : Criteria<Evento>
    {
        private DayOfWeek iDiaSemana;

        public DayOfWeekCriterion(DayOfWeek pDia)
        {
            this.iDiaSemana = pDia;
        }

        IList<Evento> Criteria<Evento>.MeetCriteria(IList<Evento> pEntidades)
        {
            var lResultado = from ent in pEntidades
                            where ent.FechaComienzo.DayOfWeek == iDiaSemana
                            select ent;

            return lResultado.ToList();

        }
    }
}
