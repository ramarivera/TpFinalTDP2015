using Autofac;
using System;
using IContainer = Questionnaire.Services.DependencyInjection.IContainer;

namespace Questionnaire.Handlers.DependencyInjection
{
    public class AutofacContainer : IContainer
    {
        private readonly Func<IComponentContext> iContainerFactory;

        public AutofacContainer(Func<IComponentContext> pContainerFactory)
        {
            this.iContainerFactory = pContainerFactory;
        }

        public TType Resolve<TType>()
        {
            return this.iContainerFactory.Invoke().Resolve<TType>();
        }

        public TType Resolve<TType>(string pConfigurationName)
        {
            return this.iContainerFactory.Invoke().ResolveNamed<TType>(pConfigurationName);
        }
    }
}
