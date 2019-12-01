using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System.Collections.Generic;

namespace Questionnaire.Services.Interfaces
{
    public interface IUserAnswerServices
    {
        IEnumerable<UserAnswer> GetAll();

        UserAnswer GetById(int pUserAnswerId);

        UserAnswer Create(UserAnswerCreationData pUserAnswerData, AnswerSession pAnswerSession);
    }
}
