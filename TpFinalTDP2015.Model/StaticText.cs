using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class StaticText : BaseBannerItem
    {
        private string iTitle;
        private string iDescription;
        private string iText;


        public StaticText() : base()
        {
            this.Type = "Text";
        }

        public virtual string Title
        {
            get { return this.iTitle; }
            set { this.iTitle = value; }
        }

        public virtual string Description
        {
            get { return this.iDescription; }
            set { this.iDescription = value; }
        }

        public virtual string Text
        {
            get { return this.iText; }
            set { this.iText = value; }
        }

        public override string GetText()
        {
            return this.Text;
        }

        public override string GetTitle()
        {
            return this.Title;
        }

    }
}
