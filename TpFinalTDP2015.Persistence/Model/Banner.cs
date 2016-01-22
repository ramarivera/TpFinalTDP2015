using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class Banner: BaseEntity
    {
        private string iName;
        private string iDescription;
        private IList<IBannerItem> iContentList;
        private IList<CampaignInterval> iActiveIntervals;


        public Banner() : base()
        {
            this.iContentList = new List<IBannerItem>();
            this.iActiveIntervals = new List<CampaignInterval>();
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
        
    }
}
