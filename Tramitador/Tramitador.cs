using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tramitador.EnventArgs;

namespace Tramitador
{
    public abstract class Tramitador
    {
        public event DAntesTransicion OnAntesTransicion;
        public event DDespuesTransicion OnDespuesTransicion;

        /// <summary>
        /// Obtiene un enumerado de las posibles transiciones definidas en un flujograma
        /// </summary>
        /// <param name="flujograma">Flujograma</param>
        /// <returns>Transiciones permitidas</returns>
        public IEnumerable<ITransicion> ObtenerTrancisionesPosibles(IFlujograma flujograma)
        {
            return flujograma.Transiciones;
        }
        /// <summary>
        /// Obtiene la transicion actual, en la que se encuentra el flujograma
        /// </summary>
        public ITransicion CurrentTransicion { get; private set; }


        public IProceso Realizar(ITransicion transicon)
        {
            IProceso proecso = null;

            PrecondicionTransicionCancelableEventArgs precondicion = new PrecondicionTransicionCancelableEventArgs() { Transicion = transicon };
            if (OnAntesTransicion != null)
            {
                OnAntesTransicion(this, precondicion);
            }

            //vemos si el usuario ha cancelado la operación
            if (!precondicion.Cancelar)
            {
                if (!transicon.Origen.Flujograma.Equals(transicon.Destino.Flujograma))
                    throw new NoMismoFlujogramaException();






                throw new NotImplementedException();


                if (OnDespuesTransicion != null)
                {
                    OnDespuesTransicion(this, new TransicionEventArgs() { Trancion = transicon });
                }
            }
            return proecso;
        }
    }
}
