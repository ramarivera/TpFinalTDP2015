using System;
using System.Collections.Generic;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{

    public class BusinessServiceLocator
    {
        private readonly static Dictionary<Type, Func<object>>  cServices = new Dictionary<Type, Func<object>>();

        public static void Register<T>(Func<T> resolver)
        {
            cServices[typeof(T)] = () => resolver();
        }

        public static T Resolve<T>()
        {
            return (T)cServices[typeof(T)]();
        }

        internal static void Reset()
        {
            cServices.Clear();
        }
    }

}

