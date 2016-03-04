using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.UI
{
    public static class ExtensionMethod
    {
        internal static IList<IDTO> ToDTOList<T>(this IList<T> source) where T : class
        {

            //TODO ver que T realmente implemente IDTO


            IList<IDTO> lResult = new List<IDTO>();

            foreach (var item in source)
            {
                lResult.Add((IDTO)item);
            }


            return lResult;


        }
    }
}
