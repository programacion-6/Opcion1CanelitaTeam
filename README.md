# Option 1 - Library Management System

Canelita Team:
- Ronaldo Mendoza
- Alex Paca
- José Luis Terán

New Team Members (Los Gosus):
- Sebasthian Salinas
- Ignacion Villarroel
- Luis Espinoza
- Josue prado

UML Link in [UML](https://drive.google.com/file/d/1IVK0H_tIamvZ8Mgc8oWo6c7geZhgwR7q/view?usp=sharing)

Related Features in [Docs](https://docs.google.com/document/d/128JWc0ZBDK4FGLvrfFyhTGEVVu7W1VVpWqkQInYGBoM/edit?usp=sharing)

Dashboard in [Trello](https://trello.com/invite/b/66bfaefd90f57fac8d8a89e2/ATTIe5dc79647cc83c4c1277915c7108c2f8B6931ADF/lms-canelita-team)

## Implementation and Refactors

- Implementation of test for book and pattern managers
- Implementation of test for staff manager and models
- Implementation of template design pattern to managers  
- Implementation of validators for book and pattern managers          
- UI page layout refactoring                  
- Refactoring of the error handler                          
- Refactoring of borrow manager                         
- Refactoring and improvement of the UI                          
- Book repository refactoring                        
- Project structure refactoring              


Translated with DeepL.com (free version)

## Directory Structure

This is the directory structure that Opcion1CanelitaTeam project uses:

```bash
.
LMS.DataAccess
│
└── src
    ├── Console
    │   ├── LoginMenu
    │   ├── UserMenu
    │   ├── Utils
    ├── Core
    │   ├── Exceptions
    │   └── Handlers
    ├── Services
    │   ├── Generator
    │   ├── Reports
    │   ├── Searchers
    │   ├── Statistics
    │   └── Validators
    └── Systems
    │   ├── Concretes
    │   ├── Entities
    │   ├── Interfaces
    └── Utils
```

## Building

To build the application, navigate to the `Opcion1CanelitaTeam` directory and use the following command:

```bash
dotnet build
```

## Running

Once compiled, you can run the application with the following commands:

```bash
cd LMS.DataAccess
dotnet run
```
