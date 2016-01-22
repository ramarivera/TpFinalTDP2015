using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class RSSItem : BaseEntity
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
                this.LastModified = DateTime.Now;
                this.iTitle = value;
            }
        }

        public string Description
        {
            get { return this.iDescription; }
            set
            {
                this.LastModified = DateTime.Now;
                this.iDescription = value;
            }
        }

        public string URL
        {
            get { return this.iURL; }
            set
            {
                this.LastModified = DateTime.Now;
                this.iURL = value;
            }
        }

        public DateTime? PublicationDate
        {
            get { return this.iPublicationDate; }
            set
            {
                this.LastModified = DateTime.Now;
                this.iPublicationDate = value;
            }
        }


    }
}
