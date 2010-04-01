﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tramitador.Impl.Xml
{
    public class XMLFlujograma : IFlujograma
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

            if(!_estados.Contains(XMLEstado.Tranformar(transicion.Origen)) 
                || !_estados.Contains(XMLEstado.Tranformar(transicion.Destino)))
                throw new NoSuchElementException();

            XMLTransicion tr = XMLTransicion.Transformar(transicion);
            if (!_transiciones.Contains(tr))
            {
                _transiciones.Add(tr);
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

        #region IFlujograma Members


        public bool EsValido(ITransicion transion)
        {
            return _transiciones.Contains(XMLTransicion.Transformar(transion));
        }

        #endregion

        #region IFlujograma Members


        public void Add(IEstado estado)
        {
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

        #endregion
    }
}