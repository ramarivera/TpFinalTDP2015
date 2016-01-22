using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    class RSSItem
    {
        private int iId;
        private DateTime iCreationDate;
        private DateTime iLastModified;

        private string iTitle;
        private string iDescription;
        private string iURL;
        private DateTime? iPublicationDate;

        public RSSItem()
        {
            this.iId = 0;
            this.iCreationDate = DateTime.Now;
            this.iLastModified = DateTime.Now;
        }

        public int Id
        {
            get { return this.iId; }
            set
            {
                this.iLastModified = DateTime.Now;
                this.iId = value;
            }
        }

        public DateTime CreationDate
        {
            get { return this.iCreationDate; }
            set
            {
                this.iLastModified = DateTime.Now;
                this.iCreationDate = value;
            }
        }

        public DateTime LastModified
        {
            get { return this.iLastModified; }
            set
            {
                this.iLastModified = value;
            }
        }

        public string Title
        {
            get { return this.iTitle; }
            set
            {
                this.iLastModified = DateTime.Now;
                this.iTitle = value;
            }
        }

        public string Description
        {
            get { return this.iDescription; }
            set
            {
                this.iLastModified = DateTime.Now;
                this.iDescription = value;
            }
        }

        public string URL
        {
            get { return this.iURL; }
            set
            {
                this.iLastModified = DateTime.Now;
                this.iURL = value;
            }
        }

        public DateTime? PublicationDate
        {
            get { return this.iPublicationDate; }
            set
            {
                this.iLastModified = DateTime.Now;
                this.iPublicationDate = value;
            }
        }


    }
}
