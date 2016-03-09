using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria.Criterion
{
    public class FrequencyCriterion : Criteria<Evento>
    {
        private FrecuenciaRepeticion iFrecuencia;

        public FrequencyCriterion(FrecuenciaRepeticion pFrecuencia)
        {
            iFrecuencia = pFrecuencia;
        }


        IList<Evento> Criteria<Evento>.MeetCriteria(IList<Evento> pEntidades)
        {
            var lResultado = from ent in pEntidades
                             where ent.Frecuencia == this.iFrecuencia
                             select ent;

            return lResultado.ToList();
        }
    }
}
