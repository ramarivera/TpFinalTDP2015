﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class RssItem : BaseBannerItem
    {

        private string iTitle;
        private string iDescription;
        private string iURL;
        private DateTime? iPublicationDate;

        public RssItem() : base()
        {
        }

        public virtual string Title
        {
            get { return this.iTitle; }
            set
            {
                this.UpdateModificationDate();
                this.iTitle = value;
            }
        }

        public virtual string Description
        {
            get { return this.iDescription; }
            set
            {
                this.UpdateModificationDate();
                this.iDescription = value;
            }
        }

        public virtual string URL
        {
            get { return this.iURL; }
            set
            {
                this.UpdateModificationDate();
                this.iURL = value;
            }
        }

        public virtual DateTime? PublicationDate
        {
            get { return this.iPublicationDate; }
            set
            {
                this.UpdateModificationDate();
                this.iPublicationDate = value;
            }
        }

        public override string GetText()
        {
            return this.Description;
        }

        public override string GetTitle()
        {
            return this.Title;
        }

    }
}
