using System;
namespace Tramitador
{
    /// <summary>
    /// Factoría de tramitador
    /// </summary>
    public interface ITramitadorFactory
    {
        /// <summary>
        /// Persiste un flujograma en un lugar determinado
        /// </summary>
        /// <param name="flujograma"></param>
        /// <returns></returns>
        bool Almacenar(IFlujograma flujograma);
        /// <summary>
        /// Crea un estado asignable a un flujograma
        /// </summary>
        /// <param name="flujograma"></param>
        /// <returns></returns>
        IEstado CreateEstado(IFlujograma flujograma);
        /// <summary>
        /// Crea un flujograma
        /// </summary>
        /// <returns></returns>
        IFlujograma CreateFlujograma();
        /// <summary>
        /// Crea una transición entre dos estados
        /// </summary>
        /// <param name="origen"><see cref="Tramitador.IEstado"/> origen</param>
        /// <param name="destino"><see cref="Tramitador.IEstado"/> destino</param>
        /// <returns>Nueva <see cref="Tramitador.ITransicion"/></returns>
        ITransicion CreateTransicion(IEstado origen, IEstado destino);
        /// <summary>
        /// Obtiene el estado i-esimo de un flujograma
        /// </summary>
        /// <param name="flujograma"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        IEstado ObtenerEstado(IFlujograma flujograma, int estado);
        IFlujograma ObtenerFlujograma(string entidad, int idEntidad);
        /// <summary>
        /// Obtiene el proceso actual de un identificable
        /// </summary>
        /// <param name="iFlujograma"></param>
        /// <param name="identificable"></param>
        /// <returns></returns>
        IProceso ObtenerProcesoActual(IFlujograma iFlujograma, IIdentificable identificable);

        void Almacenar(IProceso proecso);
    }
}
