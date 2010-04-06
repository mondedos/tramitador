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


        #region ITramitadorFactory Members


        public IProceso ObtenerProcesoActual(IFlujograma iFlujograma, IIdentificable identificable)
        {
            XMLProceso proceso = null;

            string nombreFichero = string.Format("{0} {1}.{2}", identificable.Entidad, iFlujograma.Nombre, "xml");

            if (!File.Exists(nombreFichero))
            {
                proceso = new XMLProceso();

                proceso.EntidadIDentificable = identificable;
                proceso.FlujogramaDef = iFlujograma;
                
            }
            else
            {
                XmlSerializer s = new XmlSerializer(typeof(XMLProceso));



                using (TextReader r = new StreamReader(nombreFichero))
                {
                    proceso = (XMLProceso)s.Deserialize(r);

                    r.Close();
                }
            }

            return proceso;
        }

        public void Almacenar(IProceso proecso)
        {
            XMLProceso xmlpro = XMLProceso.Transformar(proecso);


            throw new NotImplementedException();
        }

        #endregion
    }
}
