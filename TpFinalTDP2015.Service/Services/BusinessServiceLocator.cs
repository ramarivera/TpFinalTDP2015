using System;
using System.Collections.Generic;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{

    public class BusinessServiceLocator
    {
        private static BusinessServiceLocator cInstance = null;
        private readonly Dictionary<Type, Func<object>> iServices;

        private BusinessServiceLocator()
        {
            iServices = new Dictionary<Type, Func<object>>();
        }


        public static BusinessServiceLocator Instance
        {
            get
            {
                if (cInstance == null)
                {
                    cInstance = new BusinessServiceLocator();
                }
                return cInstance;
            }
        }

        public void Register<T>(Func<T> resolver)
        {
            iServices[typeof(T)] = () => resolver();
        }

        public T Resolve<T>()
        {
            return (T)iServices[typeof(T)]();
        }

        internal void Reset()
        {
            iServices.Clear();
        }


    }

}

