using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model.Enum;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class Day : BaseEntity
    {
        private Days iNameOfDay;

        public Day() : base()
        {
            this.iNameOfDay = default(Days);
        }

        public virtual Days NameOfDay
        {
            get { return this.iNameOfDay; }
            set
            {
                this.UpdateModificationDate();
                this.iNameOfDay = value;
            }
        }


    }
}
