using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tramitador.EnventArgs
{
    public delegate void DAntesTransicion(object sender, PrecondicionTransicionCancelableEventArgs args);

    public delegate void DDespuesTransicion(object sender, TransicionEventArgs args);
}
