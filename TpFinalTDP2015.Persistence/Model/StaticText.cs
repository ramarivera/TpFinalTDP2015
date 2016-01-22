using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class StaticText : BaseEntity, IBannerItem
    {
        private string iTitle;
        private string iDescription;
        private string iText;


        public StaticText() :  base()
        {

        }

        public string Title
        {
            get {return this.iTitle; }
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

        public string Text
        {
            get {return this.iText; }
            set
            {
                this.UpdateModificationDate();
                this.iText = value;
            }
        }

        string IBannerItem.GetText()
        {
            return this.Text;
        }

        string IBannerItem.GetTitle()
        {
            return this.Title;
        }


    }
}
