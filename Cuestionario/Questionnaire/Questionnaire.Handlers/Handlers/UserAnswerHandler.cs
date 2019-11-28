using AutoMapper;
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

        public UserAnswerHandler(
            IUserAnswerServices pUserAnswerServices,
            IAnswerSessionServices pAnswerSessionServices,
            IMapper pMapper)
            : base(pMapper)
        {
            iUserAnswerServices = pUserAnswerServices;
            iAnswerSessionServices = pAnswerSessionServices;
        }

        /// <summary>
        /// Saves a User Answer during an Answer Session
        /// </summary>
        /// <param name="pUserAnswer">User Answer data</param>
        /// <param name="pAnswerSessionId">Specific Answer Session</param>
        /// <returns>New User Answer Id</returns>
        [Transactional]
        public long SaveUserAnswer(UserAnswerCreationData pUserAnswer, long pAnswerSessionId)
        {
            AnswerSession lAnswerSession = iAnswerSessionServices.GetById(pAnswerSessionId);
            var lUserAnswer = this.iUserAnswerServices.Create(pUserAnswer, lAnswerSession);

            return lUserAnswer.Id;
        }
    }
}
