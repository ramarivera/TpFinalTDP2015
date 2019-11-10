using Questionnaire.Model;
using Cuestionario.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.Interfaces
{
    public interface IUserAnswerServices
    {
        IQueryable<UserAnswer> GetAll();
        UserAnswer GetById(long pUserAnswerId);
        UserAnswer Create(UserAnswerCreationData pUserAnswerData, AnswerSession pAnswerSession);
        UserAnswer Update(long pUserAnswerId, UserAnswerData pUpdateUserAnswer);
        void Delete(long pUserAnswerId);
    }
}
