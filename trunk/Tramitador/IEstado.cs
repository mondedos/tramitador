using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador
{
    /// <summary>
    /// Representa un estado de un flujograma
    /// </summary>
    public interface IEstado : IEquatable<IEstado>, ICloneable<IEstado>
    {
        /// <summary>
        /// Nombre del estado
        /// </summary>
        string Nombre { get; set; }
        /// <summary>
        /// Identificador del estado
        /// </summary>
        int Estado { get; set; }
        /// <summary>
        /// Flujograma al que pertenece el estado
        /// </summary>
        IFlujograma Flujograma { get; set; }
        /// <summary>
        /// Indica si el estado representa un estado final
        /// </summary>
        bool EsEstadoFinal { get; set; }

    }
}
