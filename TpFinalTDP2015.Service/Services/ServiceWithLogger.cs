using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class ServiceWithLogger
    {
        protected readonly ILog _logger;

        public ServiceWithLogger(ILog pLogger)
        {
            _logger = pLogger;
        }

    }
}
