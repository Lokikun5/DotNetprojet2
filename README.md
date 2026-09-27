# Lambazon - DotNetprojet2

Projet réalisé dans le cadre de la formation **Développeur d'application Back-End .NET** chez OpenClassrooms.

## Contexte

L'objectif du projet est de reprendre une application e-commerce ASP.NET Core existante afin de :

- identifier et corriger plusieurs bugs ;
- compléter les méthodes marquées par des `TODO` ;
- utiliser le débogueur pour comprendre l'origine des erreurs ;
- vérifier le bon fonctionnement du panier, des commandes, du stock et des traductions.

## Stack

- C#
- .NET 9
- ASP.NET Core MVC
- Razor
- LINQ
- Bootstrap
- jQuery Validation
- Git / GitHub

## Lancer le projet

### 1. Cloner le repository

```bash
git clone https://github.com/Lokikun5/DotNetprojet2.git
```

### 2. Aller dans le dossier du projet

```bash
cd DotNetprojet2/P2FixAnAppDotNetCode
```

### 3. Restaurer les dépendances

```bash
dotnet restore
```

### 4. Compiler le projet

```bash
dotnet build
```

### 5. Lancer l'application

```bash
dotnet run
```

L'application est ensuite accessible à l'adresse :

```text
http://localhost:62929/
```

## Lancer avec Visual Studio

Ouvrir le projet dans Visual Studio, définir :

```text
P2FixAnAppDotNetCode
```

comme projet de démarrage, puis lancer avec :

```text
F5
```

pour démarrer avec le débogueur.

## Remarque

Les produits et les stocks sont conservés uniquement en mémoire.

Lorsque l'application est arrêtée puis relancée, les données sont recréées avec leurs valeurs initiales.
