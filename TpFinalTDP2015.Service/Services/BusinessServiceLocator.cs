using System;
using System.Collections.Generic;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{

    public class BusinessServiceLocator
    {
        private readonly static Dictionary<Type, Func<object>>  cServices = new Dictionary<Type, Func<object>>();

        public static void Register<T>(Func<T> resolver)
        {
            BusinessServiceLocator.cServices[typeof(T)] = () => resolver();
        }

        public static T Resolve<T>()
        {
            return (T)BusinessServiceLocator.cServices[typeof(T)]();
        }

        internal static void Reset()
        {
            BusinessServiceLocator.cServices.Clear();
        }
    }

}

