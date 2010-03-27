using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Tramitador.Impl.Xml
{
    public class XMLTramitadorFactory
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

                r.Close();
            }

            return solucion;
        }

        public IEstado CreateEstado(IFlujograma flujograma)
        {
            return new XMLEstado() { Flujograma = flujograma };
        }

        public IEstado ObtenerEstado(IFlujograma flujograma, int estado)
        {
            throw new NotImplementedException();
        }

        public ITransicion CreateTransicion(IEstado origen, IEstado destino)
        {
            if (!origen.Flujograma.Equals(destino.Flujograma))
                throw new NoMismoFlujogramaException();
            return new XMLTransicion() { Destino = destino, Origen = origen, Flujograma = origen.Flujograma };
        }
    }
}
