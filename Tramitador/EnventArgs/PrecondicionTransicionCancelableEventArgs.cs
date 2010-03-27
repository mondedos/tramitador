using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador.EnventArgs
{
    /// <summary>
    /// Argumento de precondición, antes de una transicion
    /// </summary>
    public class PrecondicionTransicionCancelableEventArgs : EventArgs
    {
        /// <summary>
        /// Cancela la transicion
        /// </summary>
        public bool Cancelar { get; set; }
        /// <summary>
        /// Transicion que se va a llevar a cabo
        /// </summary>
        public ITransicion Transicion { get; set; }
    }
}
