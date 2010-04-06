using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador
{
    /// <summary>
    /// Representa el estado actual de la maquina de estados.
    /// </summary>
    public interface IProceso
    {
        IIdentificable EntidadIDentificable { get; set; }
        IFlujograma FlujogramaDef { get; set; }
        IEstado EstadoActual { get; set; }
        ITransicion UltimaTransicion { get; set; }
        SortedList<DateTime, IProceso> ProcesosAnteriores { get;  }
    }
}
