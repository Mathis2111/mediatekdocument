# MediatekDocuments README Complémentaire
Cette application permet de gérer les documents (livres, DVD, revues) d'une médiathèque. Elle a été codée en C# sous Visual Studio 2019. C'est une application de bureau, prévue d'être installée sur plusieurs postes accédant à la même base de données.<br>
L'application exploite une API REST pour accéder à la BDD MySQL. Voici le lien du dépôt d'origine de l'application : https://github.com/CNED-SLAM/MediaTekDocuments
## Ajouts réalisés
### Gestion des commandes de livres et DVD
<br>
Ajout de la table Suivi dans la base de données, reliée à CommandeDocument.<br>

![img1](https://monportefolioanis.go.yj.fr/photo_readme_AP2/commandedocument_idsuivi.png)<br>

Nouvelle interface graphique pour gérer les commandes de livres et de DVD.<br>
![img2](https://github.com/Mathis2111/mediatekdocument/blob/main/Image%20README/CommandeLivres.png)<br>
Tri des listes sur les colonnes disponibles.<br>

Affichage des informations d'un livre/DVD et des commandes associées.<br>

Ajout d'une nouvelle commande via un groupbox.<br>

Modification de l'étape de suivi avec des règles de progression stricte.<br>
![img3](https://github.com/Mathis2111/mediatekdocument/blob/main/Image%20README/SuiviLivre.png)<br>

Suppression de commande uniquement si elle n'est pas livrée.<br>

Ajout d'un trigger qui, lorsque la commande est marquée comme "livrée", génère les exemplaires correspondants dans Exemplaire.<br>

### Gestion des commandes de revues
<br>
Possibilité de sélectionner une revue et d'afficher les abonnements associés.<br>

Suppression d'une commande de revue uniquement si aucun exemplaire n'y est rattaché.<br>

Ajout d'une alerte automatique affichant les abonnements se terminant dans moins de 30 jours.<br>
![img7](https://github.com/Mathis2111/mediatekdocument/blob/main/Image%20README/dateExpiration.png)<br>

### Mise en place de l'authentification
<br>

Fenêtre d'authentification à l'ouverture de l'application.<br>
![img9](https://github.com/Mathis2111/mediatekdocument/blob/main/Image%20README/PageConnexion.png)<br>
Gestion des droits d'accès : certains onglets deviennent invisibles ou inactifs selon l'utilisateur.<br>

Blocage complet pour le service "Culture" avec fermeture automatique de l'application.<br>

Restriction de l'alerte de fin d'abonnement aux utilisateurs concernés.<br>

### Télécharegement de l'applcation
<br>
Pour télécharger l'application, il vous suffit de cliquer sur le fichier "MediatekDocument2025Installeur" situé dans les fichiers plus haut, puis cliqué sur " view Raw.<br>
- La fenêtre "Bienvenue dans l'Assistant Installation de Setup" s'ouvre. Cliquez sur "Suivant".<br>
- Garder le dossier proposé, sélectionner "Tout le monde" puis cliquer sur Suivant.<br>
- Confirmer en cliquant à nouveau sur Suivant.<br>
- A la fin de l'installation, cliquer sur "Fermer".<br>

### Corrections de Sécurité<br>

### Problème 1 : Stockage des informations sensibles
<br>
Sécurisation des identifiants de connexion en les stockant dans App.config plutôt que directement dans le code.<br>

#### Problème 2 : Protection des routes
<br>
Ajout d'une règle dans le fichier .htaccess pour retourner une erreur 400 en cas d'URL vide<br>
