using Cuestionario.Services.DTO;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface ICategoryHandler : IBaseHandler
    {
        IEnumerable<CategoryData> GetAll();
    }
}
