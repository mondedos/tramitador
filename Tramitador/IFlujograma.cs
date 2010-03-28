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
        /// <summary>
        /// Indica si se puede realizar una transicion en nuestro flujograma
        /// </summary>
        /// <param name="transion">transicion</param>
        /// <returns>Cierto si es posible realizar la transicon</returns>
        bool EsValido(ITransicion transion);

         ITransicion[] Transiciones { get; }
    }
}
