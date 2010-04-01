﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tramitador.Impl.Xml
{
    public class XMLEstado : IEstado
    {
        #region IEstado Members

        public string Descripcion { get; set; }

        public int Estado { get; set; }

        [XmlIgnore]
        public IFlujograma Flujograma { get; set; }

        public bool EsEstadoFinal { get; set; }

        #endregion

        #region IEquatable<IEstado> Members

        public bool Equals(IEstado other)
        {
            return (!EsEstadoFinal || other.EsEstadoFinal) && (!other.EsEstadoFinal || EsEstadoFinal)
                && Estado == other.Estado && Descripcion.Equals(other.Descripcion)
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

                sol.Descripcion = estado.Descripcion;
                sol.EsEstadoFinal = estado.EsEstadoFinal;
                sol.Estado = estado.Estado;
                sol.Flujograma = estado.Flujograma;
            }

            return sol;
        }
    }
}