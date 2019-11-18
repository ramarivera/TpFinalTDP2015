using AutoMapper;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers
{
    /// <summary>
    /// Handler class for <see cref="Model.AnswerSession"/> related use cases such as: <see cref="StartAnswerSession"/> 
    /// and <see cref="EndAnswerSession"/>
    /// </summary>
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

        /// <summary>
        /// Starts a new Answer Session, according to the data chosen by user
        /// </summary>
        /// <param name="pSessionStartData">Answer Session start data</param>
        /// <returns> New Answer Session Id</returns>
        [Transactional]
        public long StartAnswerSession(AnswerSessionStartData pSessionStartData)
        {
            var lAnswerSession = this.iAnswerSessionServices.StartSession(pSessionStartData);

            return lAnswerSession.Id;
        }

        /// <summary>
        /// Gets all Answer Sessions
        /// </summary>
        /// <returns>A list of <see cref="AnswerSessionData"/></returns>
        [Transactional]
        public IEnumerable<AnswerSessionData> GetAll()
        {
            var lAnswerSessions = iAnswerSessionServices.GetAll();

            var lResult = Mapper.Map<IList<AnswerSessionData>>(lAnswerSessions);
            return lResult;
        }

        /// <summary>
        /// Gets a specific Answer Session, according to a given Id
        /// </summary>
        /// <param name="pId">Answer Session Id</param>
        /// <returns><see cref="AnswerSessionData"/> for the given Id</returns>
        [Transactional]
        public AnswerSessionData GetById(long pId)
        {
            var lAnswerSession = iAnswerSessionServices.GetById(pId);

            var lResult = Mapper.Map<AnswerSessionData>(lAnswerSession);
            return lResult;
        }

        /// <summary>
        /// Finalizes a specific Answer Session, updating its data
        /// </summary>
        /// <param name="pId">Answer Session Id</param>
        /// <returns></returns>
        [Transactional]
        public long EndAnswerSession(long pId)
        {
            var lAnswerSession = this.iAnswerSessionServices.EndSession(pId);

            return lAnswerSession.Id;
        }
    }
}
