using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.UI.Excepciones
{
    public class EntidadNulaException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EntidadNulaException"/>. Constructor por defecto
        /// </summary>
        public EntidadNulaException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EntidadNulaException"/> con un mensaje de error especifico.
        /// </summary>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public EntidadNulaException(string pMensaje) : base(pMensaje) { }
    }
}
