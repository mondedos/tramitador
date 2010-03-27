using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tramitador.Impl.Xml
{
    public class XMLFlujograma : IFlujograma
    {

        private List<XMLTransicion> _transiciones = new List<XMLTransicion>();

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

            if (transicion is XMLTransicion)
            {
                XMLTransicion tr = transicion as XMLTransicion;
                if (!_transiciones.Contains(tr))
                {
                    _transiciones.Add(tr);
                }
            }
        }

        #endregion

        #region IFlujograma Members

        [XmlIgnore]
        public ITransicion[] Transiciones
        {
            get { return _transiciones.ToArray(); }
        }

        #endregion

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
    }
}
