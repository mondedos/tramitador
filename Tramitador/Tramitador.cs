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


        public IProceso Realizar(ITransicion transicion, IIdentificable identificable)
        {
            if (!transicion.Origen.Flujograma.Equals(transicion.Destino.Flujograma))
                throw new NoMismoFlujogramaException();

            IProceso proceso = factoria.ObtenerProcesoActual(transicion.Flujograma, identificable);

            PrecondicionTransicionCancelableEventArgs precondicion = new PrecondicionTransicionCancelableEventArgs() { Transicion = transicion };
            if (OnAntesTransicion != null)
            {
                OnAntesTransicion(this, precondicion);
            }

            if (!proceso.FlujogramaDef.EsValido(transicion))
                throw new InvalidOperationException("Transición no definida.");

            if (proceso.UltimaTransicion != null && proceso.UltimaTransicion.Destino == null)
                throw new NoSuchElementException();


            if (proceso.UltimaTransicion != null && !proceso.UltimaTransicion.Destino.Equals(transicion.Origen))
                throw new InvalidOperationException("El estado origen tiene que ser el mismo que el estado destino de la última transición.");

            //vemos si el usuario ha cancelado la operación
            if (!precondicion.Cancelar)
            {
                //si hasta ahora todo va bien, realizamos el cambio de transicion

                //primero guardamos la ultima transición en el histórico

                if (proceso.UltimaTransicion != null)
                {
                    proceso.ProcesosAnteriores.Add(proceso.UltimaTransicion.FechaTransicion, proceso.Clone());
                }

                //actualizamos el proceso
                proceso.UltimaTransicion = transicion;
                proceso.EstadoActual = transicion.Destino;


                factoria.Almacenar(proceso);

                if (OnDespuesTransicion != null)
                {
                    OnDespuesTransicion(this, new TransicionEventArgs() { Trancion = transicion });
                }
            }
            return proceso;
        }
    }
}
