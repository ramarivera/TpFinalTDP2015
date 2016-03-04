using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model
{
    public abstract class BaseBannerItem : BaseEntity
    {
        private string iType;
        public BaseBannerItem() : base() { }

        public string Type
        {
            get { return this.iType; }
            set { this.iType = value; }
        }
        public abstract string GetText();

        public abstract string GetTitle();

    }
}
