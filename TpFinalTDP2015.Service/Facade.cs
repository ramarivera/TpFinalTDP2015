using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using TpFinalTDP2015.Persistence.Interfaces;
using Microsoft.Practices.Unity;

namespace TpFinalTDP2015.Service
{
    public class Facade
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<Facade>();

        private IUnitOfWork iUoW;


        public Facade()
        {
            cLogger.Info("Fachada instanciada");
            this.iUoW = IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>();
            cLogger.InfoFormat("Usando {0} como implementacion de {1}", new [] { this.iUoW.GetType().Name, typeof(IUnitOfWork).Name });
        }
    }
}
