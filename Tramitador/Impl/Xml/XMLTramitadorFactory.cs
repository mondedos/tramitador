using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Tramitador.Impl.Xml
{
    public class XMLTramitadorFactory : ITramitadorFactory
    {
        public IFlujograma CreateFlujograma()
        {
            return new XMLFlujograma();
        }

        public bool Almacenar(IFlujograma flujograma)
        {
            bool solucion = false;

            if (flujograma is XMLFlujograma)
            {
                XMLFlujograma flujo = flujograma as XMLFlujograma;

                string nombreFichero = string.Format("{0}.xml", flujo.Entidad);

                // Serialization
                XmlSerializer s = new XmlSerializer(typeof(XMLFlujograma));
         
                using (TextWriter w = new StreamWriter(nombreFichero))
                {

                    s.Serialize(w, flujo);
                    w.Close();
                    solucion = true;
                }
            }

            return solucion;
        }

        public IFlujograma ObtenerFlujograma(string entidad, int idEntidad)
        {
            XmlSerializer s = new XmlSerializer(typeof(XMLFlujograma));
            
            IFlujograma solucion=null;

            using (TextReader r = new StreamReader(string.Format("{0}.xml", entidad)))
            {
                solucion = (XMLFlujograma)s.Deserialize(r);

                if (solucion.IdEntidad != idEntidad)
                    solucion = null;
                else
                {
                    RellenarFlujogramasNull(solucion);
                }

                r.Close();
            }

            return solucion;
        }

        private void RellenarFlujogramasNull(IFlujograma solucion)
        {
            SortedList<int, IEstado> estados = new SortedList<int, IEstado>();

            foreach (var item in solucion.Estados)
            {
                estados.Add(item.Estado, item);
            }

            foreach (var item in solucion.Transiciones)
            {
                if (item.Flujograma == null)
                {
                    item.Flujograma = solucion;
                }
                item.Origen = estados[item.Origen.Estado];
                item.Destino = estados[item.Destino.Estado];

                RellenarFlujogramasNull(solucion, item.Origen);
                RellenarFlujogramasNull(solucion, item.Destino);
            }
        }

        private void RellenarFlujogramasNull(IFlujograma solucion, IEstado iEstado)
        {
            if (iEstado.Flujograma == null)
                iEstado.Flujograma = solucion;
        }

        public IEstado CreateEstado(IFlujograma flujograma)
        {
            return new XMLEstado() { Flujograma = flujograma };
        }

        public IEstado ObtenerEstado(IFlujograma flujograma, int estado)
        {
            IEstado sol = null;

            foreach (var est in flujograma.Estados)
            {
                if (est.Estado == estado)
                {
                    sol = est;
                    break;
                }
            }

            return sol;
        }

        public ITransicion CreateTransicion(IEstado origen, IEstado destino)
        {
            if (!origen.Flujograma.Equals(destino.Flujograma))
                throw new NoMismoFlujogramaException();
            return new XMLTransicion() { Destino = destino, Origen = origen, Flujograma = origen.Flujograma };
        }
    }
}
