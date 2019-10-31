using AutoMapper;
using Questionnaire.Handlers.Handlers.Interfaces;

namespace Questionnaire.Handlers.Handlers
{
    public abstract class BaseHandler : IBaseHandler
    {
        private readonly IMapper iMapper;

        public BaseHandler(IMapper pMapper)
        {
            this.iMapper = pMapper;
        }

        protected IMapper Mapper => iMapper;
        public void Dispose()
        {
        }
    }
}
