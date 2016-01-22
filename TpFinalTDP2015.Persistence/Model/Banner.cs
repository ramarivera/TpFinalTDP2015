using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Model
{
    public class Banner
    {
        private string iName;
        private string iDescription;
        public string Name
        {
            get { return this.iName; }
            set { this.iName = value; }
        }
        public string Description
        {
            get { return this.iDescription; }
            set { this.iDescription = value; }
        }
        public List<TextoFijo> TextosFijos { get; set; }
        public List<FuenteRSS> FuentesRSS { get; set; }
        public List<IntervaloAplicacion> IntervalosAplicacion { get; set; }
    }
}
