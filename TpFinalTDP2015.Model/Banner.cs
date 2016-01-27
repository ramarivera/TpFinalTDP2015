using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model.Interface;

namespace TpFinalTDP2015.Model
{
    public class Banner: BaseEntity
    {
        private string iName;
        private string iDescription;
        private IList<IBannerItem> iContentList;
        private IList<DateInterval> iActiveIntervals;


        public Banner() : base()
        {
            this.iContentList = new List<IBannerItem>();
            this.iActiveIntervals = new List<DateInterval>();
        }
        //TODO : accesores con actualizacion de la fecha de odificacion para listas de ibanner y campagininterval;

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

        public object CampaignIntervals { get; set; }
    }
}
