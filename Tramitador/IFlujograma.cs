using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador
{
    /// <summary>
    /// Representa un flujograma
    /// </summary>
    public interface IFlujograma : IIdentificable, IEquatable<IFlujograma>
    {
        /// <summary>
        /// Nombre que identifica al flujograma
        /// </summary>
        string Nombre { get; set; }

        void Add(ITransicion transicion);

         ITransicion[] Transiciones { get; }
    }
}
