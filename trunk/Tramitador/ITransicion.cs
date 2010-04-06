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
        /// <see cref="Tramitador.IEstado"/> Origen de la transicion
        /// </summary>
        IEstado Origen { get; set; }
        /// <summary>
        /// <see cref="Tramitador.IEstado"/> al que lleva esta <see cref="Tramitador.ITransicion"/>
        /// </summary>
        IEstado Destino { get; set; }
        /// <summary>
        /// Flujograma a la que pertenece la <see cref="Tramitador.ITransicion"/>
        /// </summary>
        IFlujograma Flujograma { get; set; }
        /// <summary>
        /// Indica si la <see cref="Tramitador.ITransicion"/> es automática
        /// </summary>
        bool EsAutomatica { get; set; }
        /// <summary>
        /// Fecha en la que se hace la <see cref="Tramitador.ITransicion"/>
        /// </summary>
        DateTime FechaTransicion { get; set; }
        /// <summary>
        /// Descripcion de la <see cref="Tramitador.ITransicion"/>
        /// </summary>
        string Descripcion { get; set; }
    }
}
