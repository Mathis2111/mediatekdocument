using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    public class FrmMediatekController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }


        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }

        /// <summary>
        /// Ajouter un livre dans la bdd
        /// </summary>
        /// <param name="livre">L'objet Livre concerné</param>
        /// <returns>True si l'ajout a pu se faire</returns>
        public bool AjouterLivre(Livre livre)
        {
            return access.AjouterLivre(livre);
        }

        /// <summary>
        /// getter sur la liste des services
        /// </summary>
        /// <returns>Liste d'objets Services</returns>
        public List<Service> GetServiceByUserName(string nomUtilisateur)
        {
            return access.GetServiceByUserName(nomUtilisateur);
        }

        /// <summary>
        /// Modifier un livre dans la bdd
        /// </summary>
        /// <param name="livre">L'objet Livre concerné</param>
        /// <returns>True si l'ajout a pu se faire</returns>
        public bool UpdateLivre(Livre livre)
        {
            return access.UpdateLivre(livre);
        }

        /// <summary>
        /// Supprimme un livre dans la bdd
        /// </summary>
        /// <param name="livre">>Objet de type Livre à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerLivre(Livre livre)
        {
            return access.SupprimerLivre(livre);
        }

        /// <summary>
        /// Ajouter un dvd dans la bdd
        /// </summary>
        /// <param name="dvd">L'objet Dvd concerné</param>
        /// <returns>True si l'ajout a pu se faire</returns>
        public bool AjouterDvd(Dvd dvd)
        {
            return access.AjouterDvd(dvd);
        }

        /// <summary>
        /// Modifier un dvd dans la bdd
        /// </summary>
        /// <param name="dvd">L'objet Dvd concerné</param>
        /// <returns>True si l'ajout a pu se faire</returns>
        public bool UpdateDvd(Dvd dvd)
        {
            return access.UpdateDvd(dvd);
        }

        /// <summary>
        /// Supprimme un dvd dans la bdd
        /// </summary>
        /// <param name="dvd">Objet de type Dvd à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            return access.SupprimerDvd(dvd);
        }

        /// <summary>
        /// Ajouter une revue dans la bdd
        /// </summary>
        /// <param name="revue">L'objet Revue concerné</param>
        /// <returns>True si l'ajout a pu se faire</returns>
        public bool AjouterRevue(Revue revue)
        {
            return access.AjouterRevue(revue);
        }

        /// <summary>
        /// Modifier une revue dans la bdd
        /// </summary>
        /// <param name="revue">L'objet Revue concerné</param>
        /// <returns>True si l'ajout a pu se faire</returns>
        public bool UpdateRevue(Revue revue)
        {
            return access.UpdateRevue(revue);
        }

        /// <summary>
        /// Supprimme une revue dans la bdd
        /// </summary>
        /// <param name="revue">Objet de type Revue à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerRevue(Revue revue)
        {
            return access.SupprimerRevue(revue);
        }

        /// <summary>
        /// récupère les commandes d'un document
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets CommandeDocument</returns>
        public List<CommandeDocument> GetCommandesDocument(string idDocument)
        {
            return access.GetCommandesDocument(idDocument);
        }

        /// <summary>
        /// récèpère toutes les commandes d'un document
        /// </summary>
        /// <param name="idDocument"></param>
        /// <returns></returns>

        public List<Commande> GetCommandes(string idDocument)
        {
            return access.GetCommandes(idDocument);
        }

        /// <summary>
        /// getter sur les suivis
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetAllSuivis()
        {
            return access.GetAllSuivis();
        }

        /// <summary>
        /// Créé une commande dans la bdd
        /// </summary>
        /// <param name="commande">Objet de type Commande à insérer</param>
        /// <returns>True si l'insertion a pu se faire</returns>
        public bool CreerCommande(Commande commande)
        {
            return access.CreerCommande(commande);
        }

        /// <summary>
        /// Créé une commande de document dans la bdd
        /// </summary>
        /// <param name="id">Id de la commande de document à insérer</param>
        /// <param name="nbExemplaire">Nombre d'exemplaires de la commande de document</param>
        /// <param name="idLivreDvd">Id du livreDvd correspondant à la commande de document</param>
        /// <param name="idSuivi">Id de l'étape de suivi de la commande de document</param>
        /// <returns>True si l'insertion a pu se faire</returns>
        public bool CreerCommandeDocument(string id, int nbExemplaire, string idLivreDvd, string idSuivi)
        {
            return access.CreerCommandeDocument(id, nbExemplaire, idLivreDvd, idSuivi);
        }

        /// <summary>
        /// Modifie l'étape de suivi d'une commande dans la bdd
        /// </summary>
        /// <param name="id">Id de la commande de document à modifier</param>
        /// <param name="idSuivi">Id de l'étape de suivi</param>
        /// <returns>True si la modification a pu se faire</returns>
        internal bool ModifierSuiviCommandeDocument(string id, string idSuivi)
        {
            return access.ModifierSuiviCommandeDocument(id, idSuivi);
        }

        /// <summary>
        /// Supprimme une commande de document dans la bdd
        /// </summary>
        /// <param name="commandesDocument">Objet de type CommandeDocument à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerCommandeDocument(CommandeDocument commandesDocument)
        {
            return access.SupprimerCommandeDocument(commandesDocument);
        }

        /// <summary>
        /// récupère les abonnements d'une revue
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets Abonnement</returns>
        public List<Abonnement> GetAbonnementRevue(string idDocument)
        {
            return access.GetAbonnementRevue(idDocument);
        }
        /// <summary>
        /// récupère les abonnements qui prennent fin dans 30 jours
        /// </summary>
        /// <returns></returns>
        public List<Abonnement> GetAbonnementsEcheance()
        {
            return access.GetAbonnementsEcheance();
        }

        /// <summary>
        /// Crée un abonnement de revue dans la bdd
        /// </summary>
        /// <param name="id">Id de l'abonnement à une revue à insérer</param>
        /// <param name="dateFinAbonnement">Date de fin d'abonnement à une revue</param>
        /// <param name="idRevue">Id de la revue concernée par l'abonnement</param>
        /// <returns>True si l'insertion pu se faire</returns>
        public bool CreerAbonnementRevue(string id, DateTime dateFinAbonnement, string idRevue)
        {
            return access.CreerAbonnementRevue(id, dateFinAbonnement, idRevue);
        }

        /// <summary>
        /// Supprimme un abonnement de revue dans la bdd
        /// </summary>
        /// <param name="abonnement">>Objet de type Abonnement à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerAbonnementRevue(Abonnement abonnement)
        {
            return access.SupprimerAbonnementRevue(abonnement);
        }
    }
}
