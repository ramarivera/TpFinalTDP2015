using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class RSSItem : BaseEntity, IBannerItem
    {

        private string iTitle;
        private string iDescription;
        private string iURL;
        private DateTime? iPublicationDate;

        public RSSItem() : base()
        {
        }

        public string Title
        {
            get { return this.iTitle; }
            set
            {
                this.UpdateModificationDate();
                this.iTitle = value;
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

        public string URL
        {
            get { return this.iURL; }
            set
            {
                this.UpdateModificationDate();
                this.iURL = value;
            }
        }

        public DateTime? PublicationDate
        {
            get { return this.iPublicationDate; }
            set
            {
                this.UpdateModificationDate();
                this.iPublicationDate = value;
            }
        }

        string IBannerItem.GetText()
        {
            return this.Description;
        }

        string IBannerItem.GetTitle()
        {
            return this.Title;
        }
    }
}
