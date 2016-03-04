using MarrSystems.TpFinalTDP2015.CrossCutting.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;


namespace MarrSystems.TpFinalTDP2015.Model.DomainServices
{
    public class DomainServiceLocator
    {
        private readonly static IDictionary<Type, Object> cServices = new Dictionary<Type, Object>();

        public static T Resolve<T>()
        {
            dynamic lResult;
            Type lType = typeof(T);
            if (cServices.ContainsKey(lType))
            {
                lResult = cServices[lType];
            }
            else
            {
                lResult = IoCContainerLocator.Container.Resolve(lType);
                cServices.Add(lType, lResult);
            }

            return lResult;
        }

    }


}
