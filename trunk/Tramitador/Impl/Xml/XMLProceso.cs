using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tramitador.Impl.Xml
{
    public class XMLProceso : IProceso
    {

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
        public SortedList<DateTime, IProceso> ProcesosAnteriores
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        public static XMLProceso Transformar(IProceso proceso)
        {
            XMLProceso sol = null;

            //if (sol is XMLProceso)
            //{
            //    sol = proceso as XMLProceso;
            //}
            //else
            //{
            sol.EntidadIDentificable = proceso.EntidadIDentificable;
            sol.EstadoActual = proceso.EstadoActual;
            sol.FlujogramaDef = proceso.FlujogramaDef;
            //sol.ProcesosAnteriores = proceso.ProcesosAnteriores;
            sol.UltimaTransicion = proceso.UltimaTransicion;
            //}

            return sol;
        }


    }
}
