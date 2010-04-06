using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace Tramitador.Impl.Xml
{
    public class XMLTransicion : ITransicion, IXmlSerializable, IEquatable<XMLTransicion>
    {
        public XMLTransicion()
        {
            Descripcion = string.Empty;
        }
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
                //&& Descripcion.Equals(other.Descripcion)
                && FechaTransicion.Equals(other.FechaTransicion)
                && Flujograma.Equals(other.Flujograma)
                && Origen.Equals(other.Origen)
                && Destino.Equals(other.Destino);
        }

        #endregion


        public static XMLTransicion Transformar(ITransicion transicion)
        {
            XMLTransicion sol = null;

            if (transicion is XMLTransicion)
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


        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            
            reader.ReadToFollowing("origen");
            if (reader.HasAttributes)
            {
                XMLOrigen = new XMLEstado() { Estado = Convert.ToInt32(reader.GetAttribute("ref")) };
            }

            reader.ReadToFollowing("destino");
            if (reader.HasAttributes)
            {
                XMLDestino = new XMLEstado() { Estado = Convert.ToInt32(reader.GetAttribute("ref")) };
            }

            reader.ReadToFollowing("Descripcion");

            Descripcion = reader.ReadElementString("Descripcion");

            EsAutomatica = Convert.ToBoolean(reader.ReadElementString("EsAutomatica"));

            FechaTransicion = Convert.ToDateTime(reader.ReadElementString("FechaTransicion"));

            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("origen");
            writer.WriteAttributeString("ref", Convert.ToString(Origen.Estado));
            writer.WriteEndElement();

            writer.WriteStartElement("destino");
            writer.WriteAttributeString("ref", Convert.ToString(Destino.Estado));
            writer.WriteEndElement();

            writer.WriteElementString("Descripcion", Descripcion);
            writer.WriteElementString("EsAutomatica", Convert.ToString(EsAutomatica));
            writer.WriteElementString("FechaTransicion", Convert.ToString(FechaTransicion));
        }

        #endregion

        #region IEquatable<XMLTransicion> Members

        public bool Equals(XMLTransicion other)
        {
            return Equals(other as ITransicion);
        }

        #endregion

        #region ICloneable<ITransicion> Members

        public ITransicion Clone()
        {
            XMLTransicion sol = new XMLTransicion();

            sol.Descripcion = Descripcion;
            sol.Destino = Destino.Clone();
            sol.EsAutomatica = EsAutomatica;
            sol.FechaTransicion = FechaTransicion;
            sol.Flujograma = Flujograma;
            sol.Origen = Origen.Clone();

            return sol;
        }

        #endregion
    }
}
