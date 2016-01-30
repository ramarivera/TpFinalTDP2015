﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public class RssSource : BaseEntity
    {
        private string iTitle;
        private string iDescription;
        private string iURL;
        private IList<RssItem> iItems;

        public RssSource() : base ()
        {
            this.Items = new List<RssItem>();
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
            get {return this.iDescription; }
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

        public virtual IList<RssItem> Items
        {
            get
            {
                return this.iItems;// TODO revisar los metodos add o delete ?     .Clone<IList<RssItem>>();
            }
            set
            {
                this.UpdateModificationDate();
                this.iItems = value;
            }
        }
        //TODO cambiar accesores Items
    }
}
