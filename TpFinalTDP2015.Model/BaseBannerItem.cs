using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    public abstract class BaseBannerItem : BaseEntity
    {
        public BaseBannerItem() : base() { }

        public abstract string GetText();

        public abstract string GetTitle();

    }
}
