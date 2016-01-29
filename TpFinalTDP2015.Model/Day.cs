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
        private Days iValue;
        private string iNameOfDay;

        public Day() : base()
        {
            this.iValue = default(Days);
            this.iNameOfDay = this.Value.ToString();
        }

        public virtual Days Value
        {
            get { return this.iValue; }
            set
            {
                this.UpdateModificationDate();
                this.iValue = value;
                this.iNameOfDay = this.Value.ToString();
            }
        }

        public virtual string NameOfDay
        {
            get
            {
                return this.iNameOfDay;
            }
            set {}
        }


    }
}
