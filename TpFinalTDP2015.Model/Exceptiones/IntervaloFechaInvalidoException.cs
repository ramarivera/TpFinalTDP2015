using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model.Exceptiones
{
    public class IntervaloFechaInvalidoException: Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="IntervaloFechaInvalidoException"/>. Constructor por defecto
        /// </summary>
        public IntervaloFechaInvalidoException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="IntervaloFechaInvalidoException"/> con un mensaje de error especifico.
        /// </summary>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public IntervaloFechaInvalidoException(string pMensaje) : base(pMensaje) { }
    }
}
