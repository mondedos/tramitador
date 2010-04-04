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
        /// Añade una <see cref="Tramitador.ITransicion"/> al flujograma
        /// </summary>
        /// <param name="transicion"></param>
        void Add(ITransicion transicion);
        /// <summary>
        /// Elimina una <see cref="Tramitador.ITransicion"/> del flujograma
        /// </summary>
        /// <param name="transicion"><see cref="Tramitador.ITransicion"/> a eliminar</param>
        /// <returns><see cref="Tramitador.ITransicion"/> eliminada o null si no existe</returns>
        ITransicion Remove(ITransicion transicion);
        /// <summary>
        /// Indica si se puede realizar una <see cref="Tramitador.ITransicion"/> en nuestro flujograma, es decir, si existe tal <see cref="Tramitador.ITransicion"/>.
        /// </summary>
        /// <param name="transion"><see cref="Tramitador.ITransicion"/></param>
        /// <returns>Cierto si es posible realizar la <see cref="Tramitador.ITransicion"/></returns>
        bool EsValido(ITransicion transion);
        /// <summary>
        /// Transiciones del flujograma.
        /// </summary>
        ITransicion[] Transiciones { get; }
        /// <summary>
        /// Añade un <see cref="Tramitador.IEstado"/> al flujogram
        /// </summary>
        /// <param name="estado">estado</param>
        void Add(IEstado estado);
        /// <summary>
        /// Elimina un <see cref="Tramitador.IEstado"/> del flujograma
        /// </summary>
        /// <param name="estado"><see cref="Tramitador.IEstado"/></param>
        /// <returns>null si no existe previamente el <see cref="Tramitador.IEstado"/> en el flujograma</returns>
        IEstado Remove(IEstado estado);
        /// <summary>
        /// Obtiene los estados del flujograma
        /// </summary>
        IEstado[] Estados { get; }
    }
}
