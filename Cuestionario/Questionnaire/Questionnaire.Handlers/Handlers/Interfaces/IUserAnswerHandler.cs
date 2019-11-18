using Questionnaire.Services.DTO;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IUserAnswerHandler : IBaseHandler
    {
        long SaveUserAnswer(UserAnswerCreationData pUserAnswer, long pAnswerSessionId);
    }
}
