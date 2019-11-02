using Cuestionario.Services.DTO;

namespace Cuestionario.UI.WinForms
{
    public interface IQuestionViewer
    {
        bool CanProceed();

        AnswerData GetUserAnswer();
    }
}