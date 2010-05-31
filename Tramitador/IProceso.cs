using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador
{
    /// <summary>
    /// Representa el estado actual de la maquina de estados.
    /// </summary>
    public interface IProceso: ICloneable<IProceso>
    {
        IIdentificable EntidadIDentificable { get; set; }
        IFlujograma FlujogramaDef { get; set; }
        /// <summary>
        /// <see cref="Tramitador.IEstado"/> actual del proceso
        /// </summary>
        IEstado EstadoActual { get; set; }
        /// <summary>
        /// <see cref="Tramitador.ITransicion"/> actual del proceso
        /// </summary>
        ITransicion UltimaTransicion { get; set; }
        SortedList<DateTime, ITransicion> ProcesosAnteriores { get;  }
    }
}
