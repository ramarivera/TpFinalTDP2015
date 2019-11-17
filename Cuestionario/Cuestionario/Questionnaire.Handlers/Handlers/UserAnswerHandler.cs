using AutoMapper;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Model;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;

namespace Questionnaire.Handlers.Handlers
{
    // TODO missing documentation
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

        public long SaveUserAnswer(UserAnswerCreationData pUserAnswer, long pAnswerSessionId)
        {
            AnswerSession lAnswerSession = iAnswerSessionServices.GetById(pAnswerSessionId);
            var lUserAnswer = this.iUserAnswerServices.Create(pUserAnswer, lAnswerSession);

            return lUserAnswer.Id;
        }
    }
}
