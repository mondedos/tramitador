﻿using System;
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
            XMLTramitadorFactory fact = new XMLTramitadorFactory();

            IFlujograma flujo = fact.ObtenerFlujograma("Mi entidad",0);

            //flujo.Nombre = "Mi flujo de pruebas";
            //flujo.Entidad = "Mi entidad";


            //IEstado origen = fact.CreateEstado(flujo);

            //origen.Descripcion = "Estado inicial";


            //IEstado destino = fact.CreateEstado(flujo);

            //destino.Descripcion = "Estado final";

            //ITransicion tr = fact.CreateTransicion(origen, destino);

            //flujo.Add(tr);

            //fact.Almacenar(flujo);
        }
    }
}