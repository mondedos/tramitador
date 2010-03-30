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
        /// <summary>
        /// Añade una transicion al flujograma
        /// </summary>
        /// <param name="transicion"></param>
        void Add(ITransicion transicion);
        /// <summary>
        /// Indica si se puede realizar una transicion en nuestro flujograma
        /// </summary>
        /// <param name="transion">transicion</param>
        /// <returns>Cierto si es posible realizar la transicon</returns>
        bool EsValido(ITransicion transion);

        ITransicion[] Transiciones { get; }
        /// <summary>
        /// Añade un estado al flujogram
        /// </summary>
        /// <param name="estado">estado</param>
        void Add(IEstado estado);
        /// <summary>
        /// Elimina un estado del flujograma
        /// </summary>
        /// <param name="estado">estado</param>
        /// <returns>null si no existe previamente el estado en el flujograma</returns>
        IEstado Remove(IEstado estado);
        /// <summary>
        /// Obtiene los estados del flujograma
        /// </summary>
        IEstado[] Estados { get; }
    }
}
