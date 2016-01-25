using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    public class Campaign : BaseEntity
    {
        private string iName;
        private string iDescription;
        private IList<DateInterval> iActiveIntervals;
        //TODO accesores con modificacion de fecha para CampaginInterval

        public Campaign() : base()
        {
            this.iActiveIntervals = new List<DateInterval>();
        }


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
