﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tramitador.Impl.Xml
{
    public class XMLEstado : IEstado, IEquatable<XMLEstado>
    {
        #region IEstado Members

        public string Nombre { get; set; }

        [XmlAttribute("IdEstado")]
        public int Estado { get; set; }

        [XmlIgnore]
        public IFlujograma Flujograma { get; set; }

        public bool EsEstadoFinal { get; set; }

        #endregion

        #region IEquatable<IEstado> Members

        public bool Equals(IEstado other)
        {
            return (!EsEstadoFinal || other.EsEstadoFinal) && (!other.EsEstadoFinal || EsEstadoFinal)
                && Estado == other.Estado && Nombre.Equals(other.Nombre)
                && Flujograma.Equals(other.Flujograma);
        }

        #endregion

        public static XMLEstado Tranformar(IEstado estado)
        {
            XMLEstado sol = null;

            if (estado is XMLEstado)
            {
                sol = estado as XMLEstado;
            }
            else
            {
                sol = new XMLEstado();

                sol.Nombre = estado.Nombre;
                sol.EsEstadoFinal = estado.EsEstadoFinal;
                sol.Estado = estado.Estado;
                sol.Flujograma = estado.Flujograma;
            }

            return sol;
        }

        #region IEquatable<XMLEstado> Members

        public bool Equals(XMLEstado other)
        {
            IEstado otro = other;

            return Equals(other as IEstado);
        }

        #endregion

        #region ICloneable<IEstado> Members

        public IEstado Clone()
        {
            XMLEstado sol = new XMLEstado();

            sol.EsEstadoFinal = EsEstadoFinal;
            sol.Estado = Estado;
            sol.Flujograma = Flujograma;
            sol.Nombre = Nombre;

            return sol;
        }

        #endregion
    }
}
