using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocuments_ModelTests
{
    /// <summary>
    /// Classe de test unitaire pour la classe métier Id_Genre_Public_Rayon
    /// </summary>
    [TestClass]
    public class IdGenrePublicRayonTests
    {
        private const string id = "00023";

        private static readonly Id_Genre_Public_Rayon id_Genre_Public_Rayon = new Id_Genre_Public_Rayon(id);

        /// <summary>
        /// Teste le constructeur de la classe Livre
        /// </summary>
        [TestMethod()]
        public void IdGenrePublicRayonTest()
        {
            Assert.AreEqual(id, id_Genre_Public_Rayon.TypeId, "devrait réussir : id valorisé");
        }
    }
}
