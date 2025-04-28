using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using Serilog;
using System.Linq;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {
        /// <summary>
        /// adresse de l'API
        /// </summary>
        private static readonly string uriApi = ConfigurationManager.AppSettings["API_URI"];
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        private const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        private const string PUT = "PUT";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        private const string DELETE = "DELETE";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
            try
            {
                string apiUser = ConfigurationManager.AppSettings["API_USER"];
                string apiPassword = ConfigurationManager.AppSettings["API_PASSWORD"];
                string authenticationString = $"{apiUser}:{apiPassword}";
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Log.Error("Erreur d'accès à l'API");
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if(instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre", null);
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon", null);
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public", null);
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// Retourne tout les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre", null);
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd", null);
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue", null);
            return lesRevues;
        }


        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocument">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument, null);
            return lesExemplaires;
        }

        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire">exemplaire à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try
            {
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire", "champs=" + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de la création d'un exemplaire en base de données");
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
        /// <param name="message">information envoyée dans l'url</param>
        /// <param name="parametres">paramètres à envoyer dans le body, au format "chp1=val1&chp2=val2&..."</param>
        /// <returns>liste d'objets récupérés (ou liste vide)</returns>
        private List<T> TraitementRecup<T> (String methode, String message, String parametres)
        {
            // trans
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message, parametres);
                // extraction du code retourné
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Log.Error("Erreur lors de l'extraction du code retourné");
                    Console.WriteLine("code erreur = " + code + " message = " + (String)retour["message"]);
                }
            }catch(Exception e)
            {
                Log.Error("Erreur d'accès à l'API");
                Console.WriteLine("Erreur lors de l'accès à l'API : "+e.Message);
                Environment.Exit(0);
            }
            return liste;
        }

        /// <summary>
        /// Convertit en json un couple nom/valeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="valeur"></param>
        /// <returns>couple au format json</returns>
        private String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);

            return JsonConvert.SerializeObject(dictionary);
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

        /// <summary>
        /// Ajoute un livre en base de données via l'API.
        /// </summary>
        /// <param name="livre">Objet Livre à ajouter.</param>
        /// <returns>True si l'ajout a réussi, False sinon.</returns>
        public bool AjouterLivre(Livre livre)
        {
            if (livre == null)
            {
                return false;
            }

            string jsonLivre = JsonConvert.SerializeObject(livre); 
            try
            {
                List<Livre> liste = TraitementRecup<Livre>(POST, "ajout_livre", "champs=" + jsonLivre);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de l'ajout du livre");
                Console.WriteLine("Erreur lors de l'ajout du livre : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Retourne les services d'un utilisateur
        /// </summary>
        /// <param name="nomUtilisateur">nom d'utilisateur du service concerné</param>
        /// <returns>Liste d'objets Service</returns>
        public List<Service> GetServiceByUserName(string nomUtilisateur)
        {
            String jsonNomUtilisateur = convertToJson("utilisateur", nomUtilisateur);
            List<Service> lesServices = TraitementRecup<Service>(GET, "service/" + jsonNomUtilisateur, null);
            return lesServices;
        }

        /// <summary>
        /// Modifie un livre en base de données via l'API.
        /// </summary>
        /// <param name="livre">Objet Livre à modifier.</param>
        /// <returns>True si la modification a réussi, False sinon.</returns>
        public bool UpdateLivre(Livre livre)
        {
            if (livre == null)
            {
                return false;
            }

            string jsonLivre = JsonConvert.SerializeObject(livre);
            try
            {
                List<Livre> liste = TraitementRecup<Livre>(PUT, "modif_livre", "champs=" + jsonLivre);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de la modification du livre");
                Console.WriteLine("Erreur lors de la modification du livre : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Suppression d'un livre en base de données
        /// </summary>
        /// <param name="livre">Objet de type Livre à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerLivre(Livre livre)
        {
            string jsonSupprimerLivre = JsonConvert.SerializeObject(livre, new CustomDateTimeConverter());
            Console.WriteLine("jsonSupprimerLivre=" + jsonSupprimerLivre);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Livre> liste = TraitementRecup<Livre>(DELETE, "sup_livre/" + jsonSupprimerLivre, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerLivre catch jsonSupprimerLivre={0} erreur={1} ", jsonSupprimerLivre, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Ajoute un dvd en base de données via l'API.
        /// </summary>
        /// <param name="dvd">Objet Dvd à ajouter.</param>
        /// <returns>True si l'ajout a réussi, False sinon.</returns>
        public bool AjouterDvd(Dvd dvd)
        {
            if (dvd == null)
            {
                return false;
            }

            string jsonDvd = JsonConvert.SerializeObject(dvd);
            try
            {
                List<Dvd> liste = TraitementRecup<Dvd>(POST, "ajout_dvd", "champs=" + jsonDvd);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de l'ajout d'un dvd");
                Console.WriteLine("Erreur lors de l'ajout d'un dvd : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Modifie un dvd en base de données via l'API.
        /// </summary>
        /// <param name="dvd">Objet Dvd à modifier.</param>
        /// <returns>True si la modification a réussi, False sinon.</returns>
        public bool UpdateDvd(Dvd dvd)
        {
            if (dvd == null)
            {
                return false;
            }

            string jsonDvd = JsonConvert.SerializeObject(dvd);
            try
            {
                List<Dvd> liste = TraitementRecup<Dvd>(PUT, "modif_dvd", "champs=" + jsonDvd);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de la modification du dvd");
                Console.WriteLine("Erreur lors de la modification du dvd : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Suppression d'un dvd en base de données
        /// </summary>
        /// <param name="dvd">Objet de type Dvd à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            string jsonSupprimerDvd = JsonConvert.SerializeObject(dvd, new CustomDateTimeConverter());
            Console.WriteLine("jsonSupprimerDvd=" + jsonSupprimerDvd);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Dvd> liste = TraitementRecup<Dvd>(DELETE, "sup_dvd/" + jsonSupprimerDvd, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerDvd catch jsonSupprimerDvd={0} erreur={1} ", jsonSupprimerDvd, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Ajoute une revue en base de données via l'API.
        /// </summary>
        /// <param name="revue">Objet Revue à ajouter.</param>
        /// <returns>True si l'ajout a réussi, False sinon.</returns>
        public bool AjouterRevue(Revue revue)
        {
            if (revue == null)
            {
                return false;
            }

            string jsonRevue = JsonConvert.SerializeObject(revue);
            try
            {
                List<Revue> liste = TraitementRecup<Revue>(POST, "ajout_revue", "champs=" + jsonRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de l'ajout d'une revue");
                Console.WriteLine("Erreur lors de l'ajout d'une revue: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Modifie une revue en base de données via l'API.
        /// </summary>
        /// <param name="revue">Objet Revue à modifier.</param>
        /// <returns>True si la modification a réussi, False sinon.</returns>
        public bool UpdateRevue(Revue revue)
        {
            if (revue == null)
            {
                return false;
            }

            string jsonRevue = JsonConvert.SerializeObject(revue);
            try
            {
                List<Revue> liste = TraitementRecup<Revue>(PUT, "modif_revue", "champs=" + jsonRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Erreur lors de la modification de la revue");
                Console.WriteLine("Erreur lors de la modification de la revue : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Suppression d'une revue en base de données
        /// </summary>
        /// <param name="revue">Objet de type Revue à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerRevue(Revue revue)
        {
            string jsonSupprimerRevue = JsonConvert.SerializeObject(revue, new CustomDateTimeConverter());
            Console.WriteLine("jsonSupprimerRevue=" + jsonSupprimerRevue);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Revue> liste = TraitementRecup<Revue>(DELETE, "sup_revue/" + jsonSupprimerRevue, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerRevue catch jsonSupprimerRevue={0} erreur={1} ", jsonSupprimerRevue, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Retourne les commandes des documents
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets CommandeDocument</returns>

        public List<CommandeDocument> GetCommandesDocument(string idDocument)
        {
            
              string jsonIdDocument = convertToJson("Id", idDocument);
              List<CommandeDocument> lesCommandesDocument = TraitementRecup<CommandeDocument>(GET, "commandedocument/" + jsonIdDocument, null);
              return lesCommandesDocument;
            
        }

        /// <summary>
        /// Retourne les commandes
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets CommandeDocument</returns>

        public List<Commande> GetCommandes(string idDocument)
        {
            string jsonIdDocument = convertToJson("Id", idDocument);
            List<Commande> lesCommandes = TraitementRecup<Commande>(GET, "commande/" + jsonIdDocument, null);
            return lesCommandes;
        }

        /// <summary>
        /// Retourne les suivis d'un document
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetAllSuivis()
        {
            List<Suivi> lesSuivis = TraitementRecup<Suivi>(GET, "suivi", null);
            return lesSuivis;
        }

        /// <summary>
        /// Ecriture d'une commande en base de données
        /// </summary>
        /// <param name="commande">Objet de type Commande à insérer</param>
        /// <returns>True si l'insertion a pu se faire</returns>
        public bool CreerCommande(Commande commande)
        {
            string jsonCreerCommande = JsonConvert.SerializeObject(commande, new CustomDateTimeConverter());
            Console.WriteLine("jsonCreerCommande " + jsonCreerCommande);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Commande> liste = TraitementRecup<Commande>(POST, "ajout_commande", "champs=" + jsonCreerCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerCommande catch jsonCreerCommande={0} erreur={1} ", jsonCreerCommande, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Ecriture d'une commande de document en base de données
        /// </summary>
        /// <param name="id">Id de la commande de document à insérer</param>
        /// <param name="nbExemplaire">Nombre d'exemplaires de la commande de document</param>
        /// <param name="idLivreDvd">Id du livreDvd correspondant à la commande de document</param>
        /// <param name="idSuivi">Id de l'étape de suivi de la commande de document</param>
        /// <returns>True si l'insertion a pu se faire</returns>
        public bool CreerCommandeDocument(string id, int nbExemplaire, string idLivreDvd, string idSuivi)
        {
            String jsonCreerCommandeDocument = "{ \"Id\" : \"" + id + "\", \"NbExemplaire\" : \"" + nbExemplaire + "\", \"IdLivreDvd\" : \"" + idLivreDvd + "\", \"IdSuivi\" : \"" + idSuivi + "\"}";
            Console.WriteLine("jsonCreerCommandeDocument" + jsonCreerCommandeDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(POST, "ajout_commandeDocument", "champs=" + jsonCreerCommandeDocument);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerCommandeDocument catch jsonCreerCommandeDocument={0} erreur={1} ", jsonCreerCommandeDocument, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Modification de l'étape de suivi d'une commande de document en base de données
        /// </summary>
        /// <param name="id">Id de la commande de document à modifier</param>
        /// <param name="idSuivi">Id de l'étape de suivi</param>
        /// <returns>True si la modification a pu se faire</returns>
        public bool ModifierSuiviCommandeDocument(string id, string idSuivi)
        {
            string jsonModifierSuiviCommandeDocument = "{ \"Id\" : \"" + id + "\", \"IdSuivi\" : \"" + idSuivi + "\"}";
            Console.WriteLine("jsonModifierSuiviCommandeDocument" + jsonModifierSuiviCommandeDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(PUT, "modif_etatCommande", "champs=" + jsonModifierSuiviCommandeDocument);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.ModifierSuiviCommandeDocument catch jsonModifierSuiviCommandeDocument={0} erreur={1} ", jsonModifierSuiviCommandeDocument, ex.Message);

            }
            return false;
        }

        /// <summary>
        /// Suppression d'une commande de document en base de données
        /// </summary>
        /// <param name="commandesDocument">Objet de type CommandeDocument à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerCommandeDocument(CommandeDocument commandesDocument)
        {
            string jsonSupprimerCommandeDocument = JsonConvert.SerializeObject(commandesDocument, new CustomDateTimeConverter());
            Console.WriteLine("jsonSupprimerCommandeDocument=" + jsonSupprimerCommandeDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(DELETE, "sup_commande/" + jsonSupprimerCommandeDocument, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerCommandeDocument catch jsonSupprimerCommandeDocument={0} erreur={1} ", jsonSupprimerCommandeDocument, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Retourne les abonnements d'une revue
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets Abonnement</returns>
        public List<Abonnement> GetAbonnementRevue(string idDocument)
        {
            string jsonIdDocument = convertToJson("Id", idDocument);
            List<Abonnement> lesAbonnementsRevue = TraitementRecup<Abonnement>(GET, "abonnement/" + jsonIdDocument, null);
            return lesAbonnementsRevue;
        }

        /// <summary>
        /// Retourne les abonnements arrivants à échéance dans 30 jours
        /// </summary>
        /// <returns></returns>
        public List<Abonnement> GetAbonnementsEcheance()
        {
            List<Abonnement> lesAbonnementsAEcheance = TraitementRecup<Abonnement>(GET, "abonnementsecheance", null);
            return lesAbonnementsAEcheance;
        }

        /// <summary>
        /// Ecriture d'un abonnement à une revue en base de données
        /// </summary>
        /// <param name="id">Id de l'abonnement à une revue à insérer</param>
        /// <param name="dateFinAbonnement">Date de fin d'abonnement à une revue</param>
        /// <param name="idRevue">Id de la revue concernée par l'abonnement</param>
        /// <returns>True si l'insertion a pu se faire</returns>
        public bool CreerAbonnementRevue(string id, DateTime dateFinAbonnement, string idRevue)
        {
            String jsonDateCommande = JsonConvert.SerializeObject(dateFinAbonnement, new CustomDateTimeConverter());
            String jsonCreerAbonnementRevue = "{\"Id\":\"" + id + "\", \"DateFinAbonnement\" : " + jsonDateCommande + ", \"IdRevue\" :  \"" + idRevue + "\"}";
            Console.WriteLine("jsonCreerAbonnementRevue" + jsonCreerAbonnementRevue);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Abonnement> liste = TraitementRecup<Abonnement>(POST, "ajout_abonnement", "champs=" + jsonCreerAbonnementRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerAbonnementRevue catch jsonCreerAbonnementRevue={0} erreur={1} ", jsonCreerAbonnementRevue, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Suppression d'un abonnement de revue en base de données
        /// </summary>
        /// <param name="abonnement">Objet de type Abonnement à supprimer</param>
        /// <returns>True si la suppression a pu se faire</returns>
        public bool SupprimerAbonnementRevue(Abonnement abonnement)
        {
            string jsonSupprimerAbonnementRevue = JsonConvert.SerializeObject(abonnement, new CustomDateTimeConverter());
            Console.WriteLine("jsonSupprimerAbonnementRevue=" + jsonSupprimerAbonnementRevue);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Abonnement> liste = TraitementRecup<Abonnement>(DELETE, "sup_abonnement/" + jsonSupprimerAbonnementRevue, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerAbonnementRevue catch jsonSupprimerAbonnementRevue={0} erreur={1} ", jsonSupprimerAbonnementRevue, ex.Message);
            }
            return false;
        } 
    }
}
