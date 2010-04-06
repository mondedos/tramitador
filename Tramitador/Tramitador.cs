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

        protected ITramitadorFactory factoria = null;
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


        public IProceso Realizar(ITransicion transicon, IIdentificable identificable)
        {
            if (!transicon.Origen.Flujograma.Equals(transicon.Destino.Flujograma))
                throw new NoMismoFlujogramaException();

            IProceso proecso = factoria.ObtenerProcesoActual(transicon.Flujograma, identificable);

            PrecondicionTransicionCancelableEventArgs precondicion = new PrecondicionTransicionCancelableEventArgs() { Transicion = transicon };
            if (OnAntesTransicion != null)
            {
                OnAntesTransicion(this, precondicion);
            }

            if (!proecso.FlujogramaDef.EsValido(transicon))
                throw new NoSuchElementException();

            //vemos si el usuario ha cancelado la operación
            if (!precondicion.Cancelar)
            {

                throw new NotImplementedException();


                factoria.Almacenar(proecso);

                if (OnDespuesTransicion != null)
                {
                    OnDespuesTransicion(this, new TransicionEventArgs() { Trancion = transicon });
                }
            }
            return proecso;
        }
    }
}
