using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador
{
    /// <summary>
    /// Representa un estado de un flujograma
    /// </summary>
    public interface IEstado : IEquatable<IEstado>
    {
        string Descripcion { get; set; }
        int Estado { get; set; }
        IFlujograma Flujograma { get; set; }
        bool EsEstadoFinal { get; set; }

    }
}
