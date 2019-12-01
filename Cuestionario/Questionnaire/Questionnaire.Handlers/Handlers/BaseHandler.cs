using AutoMapper;
using Microsoft.Extensions.Logging;
using Questionnaire.Handlers.Handlers.Interfaces;

namespace Questionnaire.Handlers.Handlers
{
    public abstract class BaseHandler : IBaseHandler
    {
        private readonly IMapper iMapper;
        private readonly ILogger iLogger;

        public BaseHandler(IMapper pMapper, ILogger pLogger)
        {
            this.iMapper = pMapper;
            this.iLogger = pLogger;
        }

        protected IMapper Mapper => iMapper;
        protected ILogger Logger => iLogger;
        public void Dispose()
        {
        }
    }
}
