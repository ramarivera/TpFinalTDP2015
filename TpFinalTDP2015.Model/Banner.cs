using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    public class Banner
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<TextoFijo> TextosFijos { get; set; }
        public List<FuenteRSS> FuentesRSS { get; set; }

        public List<IntervaloAplicacion> IntervalosAplicacion { get; set; }
    }
}
