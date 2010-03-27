using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador.EnventArgs
{
    /// <summary>
    /// Argumentos de transicion
    /// </summary>
    public class TransicionEventArgs : EventArgs
    {
        /// <summary>
        /// Transición que se ha llevado a cabo
        /// </summary>
        public ITransicion Trancion { get; set; }
    }
}
