﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model.Exceptiones
{
    public class FechaInvalidaException: Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FechaInvalidaException"/>. Constructor por defecto
        /// </summary>
        public FechaInvalidaException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FechaInvalidaException"/> con un mensaje de error especifico.
        /// </summary>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public FechaInvalidaException(string pMensaje) : base(pMensaje) { }
    }
}
