using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocuments_ModelTests
{
    /// <summary>
    /// Classe de test unitaire pour la classe métier Service
    /// </summary>
    [TestClass]
    public class ServiceTests
    {
        private const string libelle = "Administrateur";

        private static readonly Service service = new Service(libelle);

        /// <summary>
        ///  Teste le constructeur de la classe Service
        /// </summary>
        [TestMethod()]
        public void ServiceTest()
        {
            Assert.AreEqual(libelle, service.Libelle, "devrait réussir : libellé valorisé");
        }
    }
}
