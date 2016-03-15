using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model.Exceptiones
{
    public class IntervaloTiempoInvalidoException: Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="IntervaloTiempoInvalidoException"/>. Constructor por defecto
        /// </summary>
        public IntervaloTiempoInvalidoException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="IntervaloTiempoInvalidoException"/> con un mensaje de error especifico.
        /// </summary>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public IntervaloTiempoInvalidoException(string pMensaje) : base(pMensaje) { }
    }
}
