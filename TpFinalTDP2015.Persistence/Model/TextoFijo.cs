using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class TextoFijo
    {
        private string iTitle;
        private string iDescription;
        private string iText;
        public string Title
        {
            get {return this.iTitle; }
            set {this.iTitle = value; }
        }
        public string Description
        {
            get {return this.iDescription; }
            set {this.iDescription=value; }
        }
        public string Text
        {
            get {return this.iText; }
            set {this.iText=value; }
        }
    }
}
