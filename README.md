# MediatekDocuments README Complémentaire
Cette application permet de gérer les documents (livres, DVD, revues) d'une médiathèque. Elle a été codée en C# sous Visual Studio 2019. C'est une application de bureau, prévue d'être installée sur plusieurs postes accédant à la même base de données.<br>
L'application exploite une API REST pour accéder à la BDD MySQL. Des explications sont données plus loin, ainsi que le lien de récupération.
## Ajouts réalisés
### Gestion des commandes de livres et DVD
<br>
Ajout de la table Suivi dans la base de données, reliée à CommandeDocument.<br>

![img1](https://monportefolioanis.go.yj.fr/photo_readme_AP2/commandedocument_idsuivi.png)<br>

Nouvelle interface graphique pour gérer les commandes de livres et de DVD.<br>
![img2](https://monportefolioanis.go.yj.fr/photo_readme_AP2/onglets_creer.png)<br>
Tri des listes sur les colonnes disponibles.<br>

Affichage des informations d'un livre/DVD et des commandes associées, triées par date décroissante.<br>

Ajout d'une nouvelle commande via un groupbox.<br>

Modification de l'étape de suivi avec des règles de progression stricte.<br>
![img3](https://monportefolioanis.go.yj.fr/photo_readme_AP2/modification_securiser.png)<br>

Alerte en cas de tentative de modification sans ligne sélectionnée au préalable.<br>
![img4](https://monportefolioanis.go.yj.fr/photo_readme_AP2/alerte_modification.png)<br>

Suppression de commande uniquement si elle n'est pas livrée.<br>

Ajout d'un trigger qui, lorsque la commande est marquée comme "livrée", génère les exemplaires correspondants dans Exemplaire.<br>

### Gestion des commandes de revues
<br>
Possibilité de sélectionner une revue et d'afficher les abonnements associés.<br>

Suppression d'une commande de revue uniquement si aucun exemplaire n'y est rattaché.<br>

Ajout d'une alerte automatique affichant les abonnements se terminant dans moins de 30 jours.<br>
![img7](https://github.com/Mathis2111/mediatekdocument/blob/main/dateExpiration.png)<br>

### Mise en place de l'authentification
<br>
Ajout des tables Utilisateur et Service pour gérer les accès.<br>
![img8](https://monportefolioanis.go.yj.fr/photo_readme_AP2/user_service_table.png)<br>

Fenêtre d'authentification à l'ouverture de l'application.<br>
![img9](https://monportefolioanis.go.yj.fr/photo_readme_AP2/connexion_form.png)<br>
Gestion des droits d'accès : certains onglets deviennent invisibles ou inactifs selon l'utilisateur.<br>

Blocage complet pour le service "Culture" avec fermeture automatique de l'application.<br>

Restriction de l'alerte de fin d'abonnement aux utilisateurs concernés.<br>

### Corrections de Sécurité
<br>
#### Problème 1 : Stockage des informations sensibles
<br>
Sécurisation des identifiants de connexion en les stockant dans App.config plutôt que directement dans le code.<br>

#### Problème 2 : Protection des routes
<br>
Ajout d'une règle dans le fichier .htaccess pour retourner une erreur 400 en cas d'URL vide<br>

### Récupération de l'Application et de l'API
