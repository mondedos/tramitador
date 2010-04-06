using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador
{
    /// <summary>
    /// Excepcion que es producida cuando se intenta hacer una operacion en distintos flujogramas
    /// y sólo debería ser posible realizarlo en un mismo flujograma.
    /// </summary>
    public class NoMismoFlujogramaException : Exception
    {

    }
}
