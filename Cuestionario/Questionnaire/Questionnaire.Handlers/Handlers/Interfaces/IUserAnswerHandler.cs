using Questionnaire.Services.DTO;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IUserAnswerHandler : IBaseHandler
    {
        int SaveUserAnswer(UserAnswerCreationData pUserAnswer, int pAnswerSessionId);
    }
}
