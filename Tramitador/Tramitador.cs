using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tramitador.EnventArgs;

namespace Tramitador
{
 public abstract   class Tramitador
    {
     public event DAntesTransicion OnAntesTransicion;
     public event DDespuesTransicion OnDespuesTransicion;

     /// <summary>
     /// Obtiene un enumerado de las posibles transiciones definidas en un flujograma
     /// </summary>
     /// <param name="flujograma">Flujograma</param>
     /// <returns>Transiciones permitidas</returns>
     public abstract IEnumerable<ITransicion> ObtenerTrancisionesPosibles(IFlujograma flujograma);
     /// <summary>
     /// Obtiene la transicion actual, en la que se encuentra el flujograma
     /// </summary>
     public ITransicion CurrentTransicion { get; private set; }


     public bool Realizar(ITransicion transicon)
     {
         throw new NotImplementedException();
     }
    }
}
