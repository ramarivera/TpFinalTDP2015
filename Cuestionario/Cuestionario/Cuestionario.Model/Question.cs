using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class Question
    {
        public virtual int pId { get; set; }
        public virtual int pCategoryId { get; set; }
        public virtual int pDifficultyId { get; set; }
        public virtual string pDescription { get; set; }
        public virtual IList<Answer> pAnswers { get; set; }
    }
}
