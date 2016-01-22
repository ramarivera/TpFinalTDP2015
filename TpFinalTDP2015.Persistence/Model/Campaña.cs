using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class Campaign : BaseEntity
    {
        private string iName;
        private string iDescription;

        public string Name
        {
            get { return this.iName; }
            set
            {
                this.UpdateModificationDate();
                this.iName = value;
            }
        }
  
        public string Description
        {
            get { return this.iDescription; }
            set
            {
                this.UpdateModificationDate();
                this.iDescription = value;
            }
        }




    }
}
