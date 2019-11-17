using AutoMapper;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers
{
    // TODO missing documentation
    public class AnswerSessionHandler : BaseHandler, IAnswerSessionHandler
    {
        private readonly IAnswerSessionServices iAnswerSessionServices;

        public AnswerSessionHandler(
            IAnswerSessionServices pAnswerSessionServices,
            IMapper pMapper)
            : base(pMapper)
        {
            this.iAnswerSessionServices = pAnswerSessionServices;
        }

        [Transactional]
        public long StartAnswerSession(AnswerSessionStartData pSessionStartData)
        {
            var lAnswerSession = this.iAnswerSessionServices.StartSession(pSessionStartData);

            return lAnswerSession.Id;
        }

        [Transactional]
        public IEnumerable<AnswerSessionData> GetAll()
        {
            var lAnswerSessions = iAnswerSessionServices.GetAll();

            var lResult = Mapper.Map<IList<AnswerSessionData>>(lAnswerSessions);
            return lResult;
        }

        [Transactional]
        public AnswerSessionData GetById(long pId)
        {
            var lAnswerSession = iAnswerSessionServices.GetById(pId);

            var lResult = Mapper.Map<AnswerSessionData>(lAnswerSession);
            return lResult;
        }

        [Transactional]
        public long EndAnswerSession(long pId)
        {
            var lAnswerSession = this.iAnswerSessionServices.EndSession(pId);

            return lAnswerSession.Id;
        }
    }
}
