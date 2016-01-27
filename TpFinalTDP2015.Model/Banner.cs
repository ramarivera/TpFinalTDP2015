using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model.Interface;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class Banner: BaseEntity
    {
        private string iName;
        private string iDescription;
        private IList<IBannerItem> iItems;
        private IList<DateInterval> iActiveIntervals;


        public Banner() : base()
        {
            this.iItems = new List<IBannerItem>();
            this.iActiveIntervals = new List<DateInterval>();
        }
        //TODO : accesores con actualizacion de la fecha de odificacion para listas de ibanner y campagininterval;

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
                return this.iActiveIntervals.Clone<IList<DateInterval>>();
            }
            set
            {
                this.UpdateModificationDate();
                this.iActiveIntervals = value;
            }
        }

        public virtual IList<IBannerItem> Items
        {
            get
            {
                return this.iItems.Clone<IList<IBannerItem>>();
            }
            set
            {
                this.UpdateModificationDate();
                this.iItems = value;
            }
        }
    }
}
