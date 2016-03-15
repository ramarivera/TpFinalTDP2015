using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model.Exceptiones
{
    public class DiaRepetidoException: Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="DiaRepetidoException"/>. Constructor por defecto
        /// </summary>
        public DiaRepetidoException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="DiaRepetidoException"/> con un mensaje de error especifico.
        /// </summary>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public DiaRepetidoException(string pMensaje) : base(pMensaje) { }
    }
}
