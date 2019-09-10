using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuestionario.Model;
using Cuestionario.Services.DTO;

namespace Cuestionario.Services.Interfaces
{
    public interface IAnswerServices
    {
        IQueryable<Answer> GetAll();
        Answer GetById(long pAnswerId);
        Answer Create(AnswerDTO pAnswer);
        Answer Update(long pAnswerId, AnswerDTO pUpdateAnswer);
        void Delete(long pAnswerId);
    }
}
