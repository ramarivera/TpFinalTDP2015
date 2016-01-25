using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    public class RSSSource : BaseEntity
    {
        private string iTitle;
        private string iDescription;
        private string iURL;
        private IList<RSSItem> iItems;

        public RSSSource() : base ()
        {
            this.Items = new List<RSSItem>();
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
            get {return this.iDescription; }
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

        public IList<RSSItem> Items
        {
            get { return this.iItems; }
            set { this.iItems = value; }
        }
        //TODO cambiar accesores Items
    }
}
