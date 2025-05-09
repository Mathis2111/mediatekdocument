﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;
using System;

namespace MediatekDocuments_ModelTests
{
    /// <summary>
    /// Classe de test unitaire pour la classe métier Abonnement
    /// </summary>
    [TestClass]
    public class AbonnementTests
    {
        private const string id = "00005";
        private static readonly DateTime dateCommande = new DateTime(2025, 2, 22);
        private const double montant = 30;
        private static readonly DateTime dateFinAbonnement = new DateTime(2025, 1, 30);
        private const string idRevue = "10003";
        private const string titre = "Challenges";

        private static readonly Abonnement abonnement = new Abonnement(id, dateCommande, montant, dateFinAbonnement, idRevue, titre);

        /// <summary>
        /// Teste le constructeur de la classe Abonnement
        /// </summary>
        [TestMethod]
        public void AbonnementTest()
        {

            Assert.AreEqual(id, abonnement.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(dateCommande, abonnement.DateCommande, "devrait réussir : date de commande valorisée");
            Assert.AreEqual(montant, abonnement.Montant, "devrait réussir : montant valorisé");
            Assert.AreEqual(dateFinAbonnement, abonnement.DateFinAbonnement, "devrait réussir : date de fin d'abonnement valorisée");
            Assert.AreEqual(idRevue, abonnement.IdRevue, "devrait réussir : idRevue valorisé");
            Assert.AreEqual(titre, abonnement.Titre, "devrait réussir : titre valorisé");

        }
    }
}
