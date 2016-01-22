using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class FuenteRSS
    {
        private string iTitle;
        private string iDescription;
        private string iURL;
        private IList<RSSItem> iItems;

        public string Title
        {
            get { return this.iTitle; }
            set { this.iTitle = value; }
        }

        public string Description
        {
            get {return this.iDescription; }
            set { this.iDescription = value; }
        }
        public string URL
        {
            get { return this.iURL; }
            set {this.iURL = value; }
        }

        public IList<RSSItem> Items
        {
            get { return this.iItems; }
            set { this.iItems = value; }
        }
    }
}
