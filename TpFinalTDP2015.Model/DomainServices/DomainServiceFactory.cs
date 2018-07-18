using MarrSystems.TpFinalTDP2015.CrossCutting.DependencyInjection;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;

namespace MarrSystems.TpFinalTDP2015.Model.DomainServices
{
    public class DomainServiceLocator
    {
        private readonly static IDictionary<Type, Object> cServices = new Dictionary<Type, Object>();

        public static T Resolve<T>()
            where T : class
        {
            T lResult;
            Type lType = typeof(T);
            if (cServices.ContainsKey(lType))
            {
                lResult = cServices[lType] as T;
            }
            else
            {
                lResult = IoCContainerLocator.Container.Resolve(lType) as T;
                cServices.Add(lType, lResult);
            }

            return lResult;
        }

    }


}
