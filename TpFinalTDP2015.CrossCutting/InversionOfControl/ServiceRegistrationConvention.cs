using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.CrossCutting.InversionOfControl
{
    public class ServiceRegistrationConvention : RegistrationConvention
    {
        /// <summary>
        /// Gets a function to get the types that will be requested for 
        /// each type to configure.
        /// </summary>
        public override Func<Type, IEnumerable<Type>> GetFromTypes()
        {
            return WithMappings.FromMatchingInterface;
        }

        /// <summary>
        /// Gets a function to get the additional 
        /// <see cref="T:Microsoft.Practices.Unity.InjectionMember" /> 
        /// objects for the registration of each type. Defaults to no injection members.
        /// </summary>
        public override Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers()
        {
            return GetServiceValidator;
        }

        /// <summary>
        /// Gets a function to get the 
        /// <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> 
        /// for the registration of each type. Defaults to no 
        /// lifetime management (e.g. transient).
        /// </summary>
        public override Func<Type, LifetimeManager> GetLifetimeManager()
        {
            // Where I work, we use this lifetime manager for everyting.
            // I wouldn't recommend this right off the bat--I'm looking 
            // into changing this, personally, but right now, this is 
            // what we use and it works for our MVC application.
            return WithLifetime.PerResolve;
        }

        /// <summary>
        /// Gets a function to get the name to use for the registration of each type.
        /// </summary>
        public override Func<Type, string> GetName()
        {
            return WithName.Default;
        }

        /// <summary>
        /// Gets types to register.
        /// </summary>
        public override IEnumerable<Type> GetTypes()
        {
            // You may want to further restrict the search for classes to register
            // by doing some sort of namespace matching:
            //
            //     t.Namespace.StartsWith(
            //         "MyCompanyNamespacePrefix", StringComparison.Ordinal
            //     )
            //
            // for example.
            return AllClasses.FromAssembliesInBasePath()
                .Where(t => t.Namespace.Contains("BusinessLogic.Services"));
        }

        /// <summary>
        /// Given a type, get the type's corresponding validator, if any.
        /// </summary>
        private IEnumerable<InjectionMember> GetServiceValidator(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            return new List<InjectionMember>()
            {
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<PolicyInjectionBehavior>()
            };

        }

    }
}
