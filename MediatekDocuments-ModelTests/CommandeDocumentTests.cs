using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocuments_ModelTests
{
    /// <summary>
    /// Classe de test unitaire pour la classe métier CommandeDocument
    /// </summary>
    [TestClass]
    public class CommandeDocumentTests
    {
        private const string id = "00028";
        private static readonly DateTime dateCommande = new DateTime(2025, 02, 22);
        private const double montant = 30;
        private const int nbExemplaire = 2;
        private const string idLivreDvd = "00014";
        private const string idSuivi = "00001";
        private const string libelle = "en cours";

        private static readonly CommandeDocument commandeDocument = new CommandeDocument(id, dateCommande, montant, nbExemplaire, idLivreDvd, idSuivi, libelle);

        /// <summary>
        /// Teste le constructeur de la classe CommandeDocument
        /// </summary>
        [TestMethod()]
        public void CommandeDocumentTest()
        {
            Assert.AreEqual(id, commandeDocument.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(dateCommande, commandeDocument.DateCommande, "devrait réussir : date de commande valorisée");
            Assert.AreEqual(montant, commandeDocument.Montant, "devrait réussir : montant valorisé");
            Assert.AreEqual(nbExemplaire, commandeDocument.NbExemplaire, "devrait réussir : nombre d'exemplaires valorisé");
            Assert.AreEqual(idLivreDvd, commandeDocument.IdLivreDvd, "devrait réussir : idLivreDvd valorisé");
            Assert.AreEqual(idSuivi, commandeDocument.IdSuivi, "devrait réussir : idSuivi valorisé");
            Assert.AreEqual(libelle, commandeDocument.Libelle, "devrait réussir : libellé valorisé");
        }
    }
}
