using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace TpFinalTDP2015.Service
{
    public class Facade
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<Facade>();

        public Facade()
        {
            cLogger.Info("Fachada instanciada");
        }
    }
}
