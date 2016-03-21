using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Persistence;
using MarrSystems.TpFinalTDP2015.Persistence.EntityFramework;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IUnityContainer iContainer;
        private readonly IPersistenceFactory iFactory;

        public ServiceFactory(IPersistenceFactory pFactory)
        {
            this.iFactory = pFactory;
        }

        public ServiceFactory(IUnityContainer pContainer, IPersistenceFactory pFactory)
        {
            this.iFactory = pFactory;
            this.iContainer = pContainer.CreateChildContainer();
            iContainer.RegisterType(typeof(IRepository<>),
                new InjectionFactory((c, t, n) =>
                {
                    object lResult = new object();
                    var lRepoType = t.IsGenericType ? t.GenericTypeArguments[0] : null;
                    if (lRepoType != null)
                    {
                        lResult = this.iFactory.GetRepository(lRepoType);
                    }
                    return lResult;
                }
                ));
        }

        public IBusinessService GetBusinessService(Type pType)
        {
            return this.iContainer.Resolve(pType) as IBusinessService;
        }

        public T GetBusinessService<T>() where T : IBusinessService
        {
            return (T)this.GetBusinessService(typeof(T));
        }

        public IDomainService GetDomainService(Type pType)
        {
            return this.iContainer.Resolve(pType) as IDomainService;
        }

        public T GetDomainService<T>() where T : IDomainService
        {
            return (T)this.GetDomainService(typeof(T));
        }

    }
}
