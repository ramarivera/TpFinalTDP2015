using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    [Serializable]
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


        public virtual string Name
        {
            get { return this.iName; }
            set
            {
                this.UpdateModificationDate();
                this.iName = value;
            }
        }

        public virtual string Description
        {
            get { return this.iDescription; }
            set
            {
                this.UpdateModificationDate();
                this.iDescription = value;
            }
        }

        public virtual IList<DateInterval> ActiveIntervals
        {
            get
            {
                return this.iActiveIntervals;// TODO revisar los metodos add o delete ?     .Clone<IList<DateInterval>>();
            }
            set
            {
                this.UpdateModificationDate();
                this.iActiveIntervals = value;
            }
        }

       /* public Campaign Clone()
        {
            Campaign lResult = new Campaign
            {
                Id = this.Id,
                LastModified = this.LastModified,
                CreationDate = this.CreationDate,
                Name = this.Name,
                Description = this.Description
            };

            IList<DateInterval> lList = new List<DateInterval>();

            foreach (DateInterval interval in this.ActiveIntervals)
            {
                lList.Add(interval.Clone());
            }

            lResult.LastModified = this.LastModified;

            return lResult;

    }*/




    }
}
