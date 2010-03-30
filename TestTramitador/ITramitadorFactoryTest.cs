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
            Assert.IsNull( actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateTransicion
        ///</summary>
        [TestMethod()]
        public void CreateTransicionTest()
        {
            ITramitadorFactory target = CreateITramitadorFactory(); // TODO: Initialize to an appropriate value
            IEstado origen = null; // TODO: Initialize to an appropriate value
            IEstado destino = null; // TODO: Initialize to an appropriate value
            ITransicion expected = null; // TODO: Initialize to an appropriate value
            ITransicion actual;
            actual = target.CreateTransicion(origen, destino);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
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
            Assert.IsNotNull( actual);
            Assert.AreEqual<IFlujograma>(flujograma, actual.Flujograma);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual ITramitadorFactory CreateITramitadorFactory()
        {
            // TODO: Instantiate an appropriate concrete class.
            ITramitadorFactory target = new Tramitador.Impl.Xml.XMLTramitadorFactory() ;
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
