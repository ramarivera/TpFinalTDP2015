using Cuestionario.Services.DTO;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IAnswerSessionHandler : IBaseHandler
    {
        int StartAnswerSession(AnswerSessionStartData pSessionStartData);

        //int StartAnswerSession2();
    }
}
