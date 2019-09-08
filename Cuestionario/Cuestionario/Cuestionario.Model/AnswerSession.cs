using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class AnswerSession
    {
        public virtual int pId { get; set; }
        public virtual string pUsername { get; set; }
        public virtual int pCategoryId { get; set; }
        public virtual int pDifficultyId { get; set; }
        public virtual int pAnswerTime { get; set; }
        public virtual int pScore { get; set; }
        public virtual DateTime pDate { get; set; }
        public virtual IList<UserAnswer> pUserAnswers { get; set; }
    }
}
