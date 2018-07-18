using log4net;
using Microsoft.Practices.Unity.Configuration;
using System;
using Unity;

namespace MarrSystems.TpFinalTDP2015.CrossCutting.DependencyInjection
{
    //TOOD cambiar a internal
    public class IoCContainerLocator
    {
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<IoCContainerLocator>();

        /// <summary>
        /// Instancia lazy del contenedor de IoC.
        /// </summary>
        private static readonly Lazy<IUnityContainer> cInstance = new Lazy<IUnityContainer>(() =>
        {
            // Se crea la instancia del contenedor, configurando el mismo a través del archivo de configuración de la aplicación.

            IUnityContainer mUnityContainer = new UnityContainer();

            mUnityContainer.LoadConfiguration("Registrations");

            return mUnityContainer;
        });

        public static IUnityContainer Container
        {
            get { return cInstance.Value; }
        }
    }
}
