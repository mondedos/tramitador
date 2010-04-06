using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tramitador.Impl.Xml
{
    public class XMLFlujograma : IFlujograma, IXmlSerializable
    {
        public XMLFlujograma()
        {
            Entidad = string.Empty;
            Nombre = string.Empty;
        }
        private List<XMLTransicion> _transiciones = new List<XMLTransicion>();
        private List<XMLEstado> _estados = new List<XMLEstado>();

        #region IFlujograma Members

        public string Nombre { get; set; }

        #endregion

        #region IIdentificable Members

        public int IdEntidad { get; set; }

        public string Entidad { get; set; }

        #endregion

        #region IEquatable<IFlujograma> Members

        public bool Equals(IFlujograma other)
        {
            return IdEntidad == other.IdEntidad && Entidad.Equals(other.Entidad) && Nombre.Equals(other.Nombre);
        }

        #endregion

        #region IFlujograma Members


        public void Add(ITransicion transicion)
        {
            if (!transicion.Flujograma.Equals(this))
                throw new NoMismoFlujogramaException();

            if (!_estados.Contains(XMLEstado.Tranformar(transicion.Origen))
                || !_estados.Contains(XMLEstado.Tranformar(transicion.Destino)))
                throw new NoSuchElementException();

            XMLTransicion tr = XMLTransicion.Transformar(transicion);
            if (!_transiciones.Contains(tr))
            {
                _transiciones.Add(tr);
            }
        }

        [XmlIgnore]
        public ITransicion[] Transiciones
        {
            get { return _transiciones.ToArray(); }
        }

        #endregion

        public XMLEstado[] XMLEstados
        {
            get
            {
                return _estados.ToArray();
            }
            set
            {
                _estados = new List<XMLEstado>(value);
            }
        }

        public XMLTransicion[] XMLTransiciones
        {
            get
            {
                return _transiciones.ToArray<XMLTransicion>();
            }
            set
            {
                _transiciones = new List<XMLTransicion>(value);
            }
        }

        #region IFlujograma Members


        public bool EsValido(ITransicion transion)
        {
            return _transiciones.Contains(XMLTransicion.Transformar(transion));
        }

        public void Add(IEstado estado)
        {
            foreach (var item in _estados)
            {
                if (item.Estado == estado.Estado)
                    throw new ClaveDuplicadaException();
            }
            _estados.Add(XMLEstado.Tranformar(estado));
        }

        public IEstado Remove(IEstado estado)
        {
            IEstado sol = null;

            if (_estados.Remove(Xml.XMLEstado.Tranformar(estado)))
                sol = estado;

            return sol;
        }
        [XmlIgnore]
        public IEstado[] Estados
        {
            get { return _estados.ToArray(); }
        }


        public ITransicion Remove(ITransicion transicion)
        {
            ITransicion sol = null;

            if (_transiciones.Remove(XMLTransicion.Transformar(transicion)))
                sol = transicion;

            return sol;
        }

        #endregion

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {

            SortedList<int, XMLEstado> estados = new SortedList<int, XMLEstado>();

            reader.ReadToFollowing("Nombre");
            Nombre = reader.ReadElementString("Nombre");
            IdEntidad = Convert.ToInt32(reader.ReadElementString("IdEntidad"));
            Entidad = reader.ReadElementString("Entidad");

            if (reader.Name.Equals("XMLEstados"))
            {
                reader.Read();
                do
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XMLEstado));


                    XMLEstado item = (XMLEstado)serializer.Deserialize(reader);

                    item.Flujograma = this;

                    estados.Add(item.Estado, item);
                    
                } while (reader.Name.Equals("XMLEstado"));

                XMLEstados = estados.Values.ToArray();

                reader.Read();
            }

            if (reader.Name.Equals("XMLTransiciones"))
            {
                List<XMLTransicion> est = new List<XMLTransicion>();

                reader.Read();
                do
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XMLTransicion));


                    XMLTransicion trans = (XMLTransicion)serializer.Deserialize(reader);

                    trans.Origen = estados[trans.Origen.Estado];
                    trans.Destino = estados[trans.Destino.Estado];

                    est.Add(trans);
                } while (reader.Name.Equals("XMLTransicion"));

                XMLTransiciones = est.ToArray();

                reader.Read();
            }

            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
