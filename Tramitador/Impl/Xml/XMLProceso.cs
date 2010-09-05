using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Tramitador.Impl.Xml
{
    public class XMLProceso : IProceso, IXmlSerializable
    {

        private static Type xmlEstadoType = typeof(XMLEstado);
        private static Type xmlTransicionType = typeof(XMLTransicion);
        private static Type xmlFlujogramaType = typeof(XMLFlujograma);

        #region IProceso Members
        [XmlIgnore]
        public IIdentificable EntidadIDentificable { get; set; }
        [XmlIgnore]
        public IFlujograma FlujogramaDef
        {
            get
            {
                return XMLFlujogramaDef;
            }
            set
            {
                XMLFlujogramaDef = XMLFlujograma.Transformar(value);
            }
        }
        public XMLFlujograma XMLFlujogramaDef { get; set; }
        [XmlIgnore]
        public IEstado EstadoActual
        {
            get
            {
                return XMLEstadoActual;
            }
            set
            {
                XMLEstadoActual = XMLEstado.Tranformar(value);
            }
        }
        public XMLEstado XMLEstadoActual { get; set; }
        [XmlIgnore]
        public ITransicion UltimaTransicion
        {
            get
            {
                return XMLUltimaTransicion; ;
            }
            set
            {
                XMLUltimaTransicion = XMLTransicion.Transformar(value);
            }
        }
        public XMLTransicion XMLUltimaTransicion { get; set; }
        [XmlIgnore]
        SortedList<DateTime, ITransicion> _procesosAnteriores = new SortedList<DateTime, ITransicion>();
        public SortedList<DateTime, ITransicion> ProcesosAnteriores
        {
            get { return _procesosAnteriores; }
        }

        #endregion

        public static XMLProceso Transformar(IProceso proceso)
        {
            XMLProceso sol = null;

            if (proceso is XMLProceso)
            {
                sol = proceso as XMLProceso;
            }
            else
            {
                sol = new XMLProceso();
                sol.EntidadIDentificable = proceso.EntidadIDentificable;
                sol.EstadoActual = proceso.EstadoActual;
                sol.FlujogramaDef = proceso.FlujogramaDef;
                //sol.ProcesosAnteriores = proceso.ProcesosAnteriores;
                sol.UltimaTransicion = proceso.UltimaTransicion;
            }

            return sol;
        }



        #region ICloneable<IProceso> Members

        public IProceso Clone()
        {
            XMLProceso sol = new XMLProceso();

            sol.EntidadIDentificable = EntidadIDentificable;
            sol.EstadoActual = EstadoActual.Clone();
            sol.FlujogramaDef = FlujogramaDef;
            //sol.ProcesosAnteriores = ProcesosAnteriores;
            sol.UltimaTransicion = UltimaTransicion.Clone();

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

            reader.ReadToFollowing(xmlFlujogramaType.Name);

            XmlSerializer serializer = new XmlSerializer(xmlFlujogramaType);

            FlujogramaDef = serializer.Deserialize(reader) as IFlujograma;


            //EntidadIDentificable.IdEntidad = FlujogramaDef.IdEntidad;
            //EntidadIDentificable.Entidad = FlujogramaDef.Entidad;
            reader.ReadToFollowing(xmlEstadoType.Name);
            if (reader.Name.Equals(xmlEstadoType.Name))
            {
                serializer = new XmlSerializer(xmlEstadoType);

                EstadoActual = serializer.Deserialize(reader) as IEstado;

                EstadoActual.Flujograma = FlujogramaDef;
            }
            reader.ReadToFollowing(xmlTransicionType.Name);
            if (reader.Name.Equals(xmlTransicionType.Name))
            {
                serializer = new XmlSerializer(xmlTransicionType);

                UltimaTransicion = serializer.Deserialize(reader) as ITransicion;
                UltimaTransicion.Flujograma = FlujogramaDef;
                UltimaTransicion.Origen = FlujogramaDef.Estados[UltimaTransicion.Origen.Estado];
                UltimaTransicion.Destino = FlujogramaDef.Estados[UltimaTransicion.Destino.Estado];
            }
            reader.ReadToFollowing("Historico");
            if (reader.Name.Equals("Historico"))
            {
                XmlReader hijos = reader.ReadSubtree();

                serializer = new XmlSerializer(xmlTransicionType);

                while (hijos.ReadToFollowing(xmlTransicionType.Name))
                {

                    ITransicion tran = serializer.Deserialize(hijos) as ITransicion;

                    tran.Flujograma = FlujogramaDef;
                    tran.Origen = FlujogramaDef.Estados[tran.Origen.Estado];
                    tran.Destino = FlujogramaDef.Estados[tran.Destino.Estado];

                    _procesosAnteriores.Add(tran.FechaTransicion, tran);
                }
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteComment("Definición del flujograma que debe seguir el proceso");

            XmlSerializer serializer = new XmlSerializer(xmlFlujogramaType);

            serializer.Serialize(writer, FlujogramaDef);

            writer.WriteComment("Estado Actual en el que se encuentra el proceso");

            serializer = new XmlSerializer(xmlEstadoType);
            serializer.Serialize(writer, EstadoActual);

            writer.WriteComment("Última transición que se realizó en el proceso");

            serializer = new XmlSerializer(xmlTransicionType);
            serializer.Serialize(writer, UltimaTransicion);


            if (Convert.ToBoolean(_procesosAnteriores.Count))
            {
                writer.WriteComment("Histórico de transiciones");

                writer.WriteStartElement("Historico");
                foreach (var item in _procesosAnteriores)
                {
                    serializer.Serialize(writer, item.Value);
                }
                writer.WriteEndElement();
            }

        }

        #endregion
    }
}
