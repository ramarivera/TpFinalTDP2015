using Questionnaire.Services.DTO;

namespace Questionnaire.UI.WinForms
{
    public interface IQuestionViewer
    {
        bool CanProceed();

        AnswerData GetUserAnswer();
    }
}