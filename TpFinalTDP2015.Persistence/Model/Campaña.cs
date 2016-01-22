using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class Campaña
    {
        private string iTitle;
        private string iDescription;
        private int iDuration;
        public string Title
        {
            get { return this.iTitle; }
            set { this.iTitle = value; }
        }
  
        public string Description
        {
            get { return this.iDescription; }
            set {this.iDescription=value; }
        }

        public int Duration
        {
            get { return this.iDuration; }
            set { this.iDuration = value; }
        }
    }
}
