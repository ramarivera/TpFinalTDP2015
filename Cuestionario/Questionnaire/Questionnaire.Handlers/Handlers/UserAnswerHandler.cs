using AutoMapper;
using Microsoft.Extensions.Logging;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Model;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;

namespace Questionnaire.Handlers.Handlers
{
    /// <summary>
    /// Handler class for <see cref="Model.UserAnswer"/> related use cases such as: <see cref="SaveUserAnswer"/> 
    /// </summary>
    public class UserAnswerHandler : BaseHandler, IUserAnswerHandler
    {
        private readonly IUserAnswerServices iUserAnswerServices;
        private readonly IAnswerSessionServices iAnswerSessionServices;
        private readonly ILogger iLogger;

        public UserAnswerHandler(
            IUserAnswerServices pUserAnswerServices,
            IAnswerSessionServices pAnswerSessionServices,
            ILogger pLogger,
            IMapper pMapper)
            : base(pMapper)
        {
            iUserAnswerServices = pUserAnswerServices;
            iAnswerSessionServices = pAnswerSessionServices;
            this.iLogger = pLogger;
        }

        /// <summary>
        /// Saves a User Answer during an Answer Session
        /// </summary>
        /// <param name="pUserAnswer">User Answer data</param>
        /// <param name="pAnswerSessionId">Specific Answer Session</param>
        /// <returns>New User Answer Id</returns>
        [Transactional]
        public int SaveUserAnswer(UserAnswerCreationData pUserAnswer, int pAnswerSessionId)
        {
            this.iLogger.LogInformation("Request received for saving a new UserAnswer for AnswerSession with id {pAnswerSessionId}", pAnswerSessionId);

            var lAnswerSession = iAnswerSessionServices.GetById(pAnswerSessionId);
            var lUserAnswer = this.iUserAnswerServices.Create(pUserAnswer, lAnswerSession);

            this.iLogger.LogInformation("Request finished for saving UserAnswer with id {UserAnswerId}", lUserAnswer.Id);
            return lUserAnswer.Id;
        }
    }
}
