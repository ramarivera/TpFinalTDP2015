using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model.Exceptiones
{
    public class HoraInvalidaException: Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="HoraInvalidaException"/>. Constructor por defecto
        /// </summary>
        public HoraInvalidaException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="HoraInvalidaException"/> con un mensaje de error especifico.
        /// </summary>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public HoraInvalidaException(string pMensaje) : base(pMensaje) { }
    }
}
