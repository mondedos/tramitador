using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tramitador.Impl.Xml;
using Tramitador;

namespace ProbadorTramitador
{
    class Program
    {
        static void Main(string[] args)
        {
            ITramitadorFactory fact = new XMLTramitadorFactory();

            IFlujograma flujo = fact.ObtenerFlujograma("Mi entidad", 0);

            List<IEstado> estados = new List<IEstado>(fact.ObtenerEstados(flujo));
            //IEstado estado=fact.ObtenerEstado(
            //IFlujograma flujo = fact.CreateFlujograma();

            //flujo.Nombre = "Mi flujo de pruebas";
            //flujo.Entidad = "Mi entidad";


            IEstado origen = fact.CreateEstado(flujo);


            //origen.Descripcion = "Estado inicial";


            //IEstado destino = fact.CreateEstado(flujo);

            //destino.Estado = 1;

            //destino.Descripcion = "Estado final";

            ITransicion tr = fact.CreateTransicion(flujo.Estados[2], flujo.Estados[3]);

            trami.OnAntesTransicion += new Tramitador.EnventArgs.DAntesTransicion(trami_OnAntesTransicion);

            trami.Realizar(tr, new MiObjeto());
            //flujo.Add(origen);

            //flujo.Add(destino);

            //flujo.Add(tr);

            //fact.Almacenar(flujo);
        }

        static void trami_OnAntesTransicion(object sender, Tramitador.EnventArgs.PrecondicionTransicionCancelableEventArgs args)
        {
            //args.Cancelar = true;
        }
    }

    public class MiObjeto : Tramitador.IIdentificable
    {

        #region IIdentificable Members

        public int IdEntidad
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Entidad
        {
            get
            {
                return "MiActualProceso";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }

    public class MyTramitador : Tramitador.Tramitador
    {
        public MyTramitador()
        {
            factoria = new XMLTramitadorFactory();
        }
    }
}
