using Tramitador;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestTramitador
{


    /// <summary>
    ///This is a test class for ITramitadorFactoryTest and is intended
    ///to contain all ITramitadorFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ITramitadorFactoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for CreateFlujograma
        ///</summary>
        [TestMethod()]
        public void CreateFlujogramaTest()
        {
            ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
            //IFlujograma expected = null; // TODO: Initialize to an appropriate value
            IFlujograma actual;
            actual = target.CreateFlujograma();

            Assert.IsNotNull(actual);
            Assert.AreEqual<int>(actual.Entidad.Length, 0);
            Assert.AreEqual<int>(actual.Nombre.Length, 0);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }


        ///// <summary>
        /////A test for ObtenerFlujograma
        /////</summary>
        //[TestMethod()]
        //public void ObtenerFlujogramaTest()
        //{
        //    ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
        //    string entidad = string.Empty; // TODO: Initialize to an appropriate value
        //    int idEntidad = 0; // TODO: Initialize to an appropriate value
        //    IFlujograma expected = null; // TODO: Initialize to an appropriate value
        //    IFlujograma actual;
        //    actual = target.ObtenerFlujograma(entidad, idEntidad);
        //    Assert.IsNotNull(actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        /// <summary>
        ///A test for ObtenerEstado
        ///</summary>
        [TestMethod()]
        public void ObtenerEstadoTest()
        {
            ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
            IFlujograma flujograma = target.CreateFlujograma(); // TODO: Initialize to an appropriate value
            int estado = 0; // TODO: Initialize to an appropriate value
            IEstado expected = null; // TODO: Initialize to an appropriate value
            IEstado actual;
            actual = target.ObtenerEstado(flujograma, estado);
            Assert.IsNull(actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        /// <summary>
        ///A test for ObtenerEstado
        ///</summary>
        [TestMethod()]
        public void ObtenerEstadoTest2()
        {
            ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
            IFlujograma flujograma = target.CreateFlujograma(); // TODO: Initialize to an appropriate value
            int estado = 3; // TODO: Initialize to an appropriate value
            IEstado expected = target.CreateEstado(flujograma); // TODO: Initialize to an appropriate value
            expected.Estado = 3;
            flujograma.Add(expected);
            IEstado actual;
            actual = target.ObtenerEstado(flujograma, estado);
            Assert.IsNotNull(actual);
            Assert.AreEqual<IEstado>(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        /// <summary>
        ///A test for ObtenerEstado
        ///</summary>
        [TestMethod()]
        public void ObtenerEstadoTest3()
        {
            ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
            IFlujograma flujograma = target.CreateFlujograma(); // TODO: Initialize to an appropriate value
            int estado = 7; // TODO: Initialize to an appropriate value
            IEstado expected = target.CreateEstado(flujograma); // TODO: Initialize to an appropriate value
            expected.Estado = 3;
            flujograma.Add(expected);
            IEstado actual;
            actual = target.ObtenerEstado(flujograma, estado);
            Assert.IsNull(actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        /// <summary>
        ///A test for ObtenerEstado
        ///</summary>
        [TestMethod()]
        public void ObtenerEstadoTest4()
        {
            ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
            IFlujograma flujograma = target.CreateFlujograma(); // TODO: Initialize to an appropriate value
            int estado = 3; // TODO: Initialize to an appropriate value
            IEstado expected = target.CreateEstado(flujograma); // TODO: Initialize to an appropriate value
            expected.Estado = 3;
            IEstado actual;
            actual = target.ObtenerEstado(flujograma, estado);
            Assert.IsNull(actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateTransicion
        ///</summary>
        [TestMethod()]
        public void CreateTransicionTest()
        {
            ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
            IFlujograma flujograma = target.CreateFlujograma();
            flujograma.Nombre = "Flujograma pruebas";
            flujograma.Entidad = "Entidad pruebas";
            IEstado origen = target.CreateEstado(flujograma); // TODO: Initialize to an appropriate value
            origen.Nombre = "Descorigen";
            origen.Estado = 1;
            IEstado destino = target.CreateEstado(flujograma); // TODO: Initialize to an appropriate value
            destino.Nombre = "DesDestino";
            destino.EsEstadoFinal = true;
            destino.Estado = 2;
            ITransicion expected = null; // TODO: Initialize to an appropriate value
            ITransicion actual;
            actual = target.CreateTransicion(origen, destino);
            Assert.IsNotNull(origen);
            Assert.IsNotNull(destino);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Origen);
            Assert.IsNotNull(actual.Destino);
            Assert.AreEqual<IEstado>(actual.Origen, origen);
            Assert.AreEqual<IEstado>(actual.Destino, destino);
            Assert.AreEqual<int>(actual.Descripcion.Length, 0);
        }

        /// <summary>
        ///A test for CreateTransicion
        ///</summary>
        [TestMethod()]
        public void CreateTransicionTest2()
        {
            ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
            IFlujograma flujograma1 = target.CreateFlujograma();
            flujograma1.Nombre = "Flujograma pruebas 1";
            flujograma1.Entidad = "Entidad pruebas 1";
            IFlujograma flujograma2 = target.CreateFlujograma();
            flujograma2.Nombre = "Flujograma pruebas 2";
            flujograma2.Entidad = "Entidad pruebas 2";
            IEstado origen = target.CreateEstado(flujograma1); // TODO: Initialize to an appropriate value
            origen.Nombre = "Descorigen";
            origen.Estado = 1;
            IEstado destino = target.CreateEstado(flujograma2); // TODO: Initialize to an appropriate value
            destino.Nombre = "DesDestino";
            destino.EsEstadoFinal = true;
            destino.Estado = 2;
            ITransicion expected = null; // TODO: Initialize to an appropriate value
            ITransicion actual;
            try
            {
                actual = target.CreateTransicion(origen, destino);
                Assert.Fail("Debería haber elevado una excepcion Tramitador.NoMismoFlujogramaException");
            }
            catch (Tramitador.NoMismoFlujogramaException)
            {

            }

        }

        /// <summary>
        ///A test for CreateEstado
        ///</summary>
        [TestMethod()]
        public void CreateEstadoTest()
        {
            ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
            IFlujograma flujograma = target.CreateFlujograma(); // TODO: Initialize to an appropriate value
            flujograma.Nombre = "Mi flujo de pruebas";
            flujograma.Entidad = "Mi entidad";
            IEstado expected = null; // TODO: Initialize to an appropriate value
            IEstado actual;
            actual = target.CreateEstado(flujograma);
            Assert.IsNotNull(actual);
            Assert.AreEqual<IFlujograma>(flujograma, actual.Flujograma);
            Assert.AreEqual<int>(actual.Nombre.Length, 0);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual ITramitadorFactory CreateITramitadorFactory()
        {
            // TODO: Instantiate an appropriate concrete class.
            ITramitadorFactory target = new Tramitador.Impl.Xml.XMLTramitadorFactory();
            return target;
        }

        ///// <summary>
        /////A test for Almacenar
        /////</summary>
        //[TestMethod()]
        //public void AlmacenarTest()
        //{
        //    ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
        //    IFlujograma flujograma = null; // TODO: Initialize to an appropriate value
        //    bool expected = true; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.Almacenar(flujograma);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}
