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
        public IEstado Origen { get {
            return XMLOrigen;
        }
            set { XMLOrigen = value as XMLEstado; }
        }
        [XmlIgnore]
        public IEstado Destino
        {
            get
            {
                return XMLDestino;
            }
            set
            {
                XMLDestino = value as XMLEstado;
            }
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
    }
}
