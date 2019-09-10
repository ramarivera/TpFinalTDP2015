using Cuestionario.Model;
using Cuestionario.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.Interfaces
{
    public interface IAnswerSessionServices
    {
        IQueryable<AnswerSession> GetAll();
        AnswerSession GetById(long pAnswerSessionId);
        AnswerSession Create(AnswerSessionDTO pAnswerSession);
        AnswerSession Update(long pAnswerSessionId, AnswerSessionDTO pUpdateAnswerSession);
        void Delete(long pAnswerSessionId);
    }
}
