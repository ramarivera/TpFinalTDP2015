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


        public Banner() : base()
        {
            this.iContentList = new List<IBannerItem>();
        }


        public string Name
        {
            get { return this.iName; }
            set { this.iName = value; }
        }
        public string Description
        {
            get { return this.iDescription; }
            set { this.iDescription = value; }
        }
        
        public List<CampaignInterval> CampaignIntervals { get; set; }
    }
}
