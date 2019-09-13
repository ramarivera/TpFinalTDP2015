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
        AnswerSession Create(AnswerSessionCreationData pAnswerSessionData);
        AnswerSession Update(long pAnswerSessionId, AnswerSessionData pUpdateAnswerSession);
        void Delete(long pAnswerSessionId);
    }
}
