using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador
{
    /// <summary>
    /// Interface que debe cumplir cualquier identidad identificable
    /// </summary>
    public interface IIdentificable
    {
        /// <summary>
        /// Identificador único
        /// </summary>
         int IdEntidad { get; set; }
        
         string Entidad { get; set; }
    }
}
