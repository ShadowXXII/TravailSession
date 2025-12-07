# To Do List

##### 1.Validation des données

* Le programme doit valider les entrées des formulaires.
* *Un message adéquat* doit être indiqué en dessous des champs non valides à l’utilisateur en cas d’erreur.
* *Les messages comme « veuillez remplir les champs » ne sont pas acceptés.*
* Lors d’une opération réussie, on doit avoir un message qui l’indique (une boite de dialogue par exemple).



##### 2.Exportation des données

* On doit pouvoir exporter les projets dans un fichier CSV.
* Ce fichier doit contenir les informations d’un projet (on ne tient pas compte des employés du
* projet).
* *ATTENTION : On doit voir le nom du client et non son numéro.*
* Les informations d’un même projet devront être dans des colonnes distinctes.
* Les taux horaires ne doivent pas être négatifs ou trop excessifs ou encore être une valeur non numérique.



##### 3.Robustesse et cohérence du programme

* Le programme ne doit pas planter.
* La date de naissance devrait donner au moins 18 ans ou encore pas plus de l’âge de la retraite (65 ans).
* La date d’embauche ne doit pas être dans le futur.



##### 4.Connection \& Déconnection

* Un compte administrateur
* Ajouts/Modifications/Suppressions
* La création du compte administrateur devra se faire lors de la première utilisation du programme
* Entrer le nom d’utilisateur et le mot de passe qui seront stockés dans la base de données
* Le mot de passe devra être crypté dans la base de données
* Déconnexion du compte administrateur
