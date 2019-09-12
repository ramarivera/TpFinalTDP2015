using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.DTO
{
    public class CategoryCreationData
    {
        public string Description { get; set; }
        public IList<QuestionData> Questions { get; set; }
    }
}
