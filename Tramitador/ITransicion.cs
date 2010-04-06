using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador
{
    /// <summary>
    /// Representa una transicion de un flujograma
    /// </summary>
    public interface ITransicion : IEquatable<ITransicion>, ICloneable<ITransicion>
    {
        /// <summary>
        /// Origen de la transicion
        /// </summary>
        IEstado Origen { get; set; }
        /// <summary>
        /// Estado al que lleva esta transicion
        /// </summary>
        IEstado Destino { get; set; }
        /// <summary>
        /// Flujograma a la que pertenece la transicion
        /// </summary>
        IFlujograma Flujograma { get; set; }
        /// <summary>
        /// Indica si la transicion es automática
        /// </summary>
        bool EsAutomatica { get; set; }
        /// <summary>
        /// Fecha en la que se hace la transicion
        /// </summary>
        DateTime FechaTransicion { get; set; }
        /// <summary>
        /// Descripcion de la transicion
        /// </summary>
        string Descripcion { get; set; }
    }
}
