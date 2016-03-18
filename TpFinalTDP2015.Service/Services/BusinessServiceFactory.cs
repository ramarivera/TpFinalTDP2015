using MarrSystems.TpFinalTDP2015.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class BusinessServiceFactory : IBusinessServiceFactory
    {
        private readonly IPersistenceFactory iFactory;

        public BusinessServiceFactory(IPersistenceFactory pFactory)
        {
            this.iFactory = pFactory;
        }

        public IBusinessService GetService(Type pType, IUnitOfWork pUoW)
        {
            Object lResult;
            var lCons = pType.GetConstructors().FirstOrDefault();
            if (lCons != null)
            {
                var lArgsInfo = lCons.GetParameters();
                int lArgsCount = lArgsInfo.Count();
                Object[] lArgs = new Object[lArgsCount];

                foreach (var info in lArgsInfo)
                {
                    object lDependency = new object();
                    Type lType = info.ParameterType;
                    bool isBusinessService = true;
                    bool isRepo = true;

                    if (isBusinessService)
                    {
                        lDependency =  this.GetService(lType,pUoW);
                    }
                    else if (isRepo)
                    {
                        lDependency = iFactory.
                            GetType().GetMethod("GetRepository").
                            MakeGenericMethod(info.ParameterType.GenericTypeArguments[1]).
                            Invoke(iFactory, new object[] { pUoW });
                    }


                    lArgs[info.Position] = lDependency;
                }

                lResult =  Activator.CreateInstance(pType, lArgs);
            }
            else
            {
                throw new Exception();
            }

            // aCA DE alguna manera magica CREO EL CONTROLADOR PEDIDO
            return (IBusinessService) lResult;
        }



        public T GetService<T>(IUnitOfWork pUoW) where T : IBusinessService
        {
            return (T)this.GetService(typeof(T), pUoW);

        }
    }
}
