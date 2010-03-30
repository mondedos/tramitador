using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace Tramitador.Impl.Xml
{
    public class XMLTransicion : ITransicion
    {
        #region ITransicion Members
        [XmlIgnore]
        public IEstado Origen
        {
            get { return XMLOrigen; }
            set { XMLOrigen = XMLEstado.Tranformar(value); }
        }
        [XmlIgnore]
        public IEstado Destino
        {
            get { return XMLDestino; }
            set { XMLDestino = XMLEstado.Tranformar(value); }
        }


        public XMLEstado XMLOrigen { get; set; }

        public XMLEstado XMLDestino { get; set; }


        [XmlIgnore]
        public IFlujograma Flujograma { get; set; }

        public bool EsAutomatica { get; set; }

        public DateTime FechaTransicion { get; set; }

        public string Descripcion { get; set; }

        #endregion

        #region IEquatable<ITransicion> Members

        public bool Equals(ITransicion other)
        {
            return (!EsAutomatica || other.EsAutomatica) && (!other.EsAutomatica || EsAutomatica)
                && Descripcion.Equals(other.Descripcion)
                && FechaTransicion.Equals(other.FechaTransicion)
                && Flujograma.Equals(other.Flujograma)
                && Origen.Equals(other.Origen)
                && Destino.Equals(other.Destino);
        }

        #endregion


        public static XMLTransicion Transformar(ITransicion transicion)
        {
            XMLTransicion sol = null;

            if (sol is XMLTransicion)
            {
                sol = transicion as XMLTransicion;
            }
            else
            {
                sol = new XMLTransicion();

                sol.Descripcion = transicion.Descripcion;
                sol.Destino = transicion.Destino;
                sol.EsAutomatica = transicion.EsAutomatica;
                sol.FechaTransicion = transicion.FechaTransicion;
                sol.Flujograma = transicion.Flujograma;
                sol.Origen = transicion.Origen;
            }

            return sol;
        }

    }
}
