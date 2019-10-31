using Cuestionario.Model;
using Cuestionario.Services.DTO;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IDifficultyHandler : IBaseHandler
    {
        IEnumerable<DifficultyData> GetAll();
    }
}
