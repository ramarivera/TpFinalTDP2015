using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.UI.Excepciones
{
    public class CampoNuloOVacioException: Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="CampoNuloOVacioException"/>. Constructor por defecto
        /// </summary>
        public CampoNuloOVacioException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="CampoNuloOVacioException"/> con un mensaje de error especifico.
        /// </summary>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public CampoNuloOVacioException(string pMensaje) : base(pMensaje) { }
    }
}
