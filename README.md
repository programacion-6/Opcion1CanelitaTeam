# Option 1 - Library Management System

By Canelita Team:
- Ronaldo Mendoza
- Alex Paca
- José Luis Terán

Related Features in [Docs](https://docs.google.com/document/d/128JWc0ZBDK4FGLvrfFyhTGEVVu7W1VVpWqkQInYGBoM/edit?usp=sharing)

Dashboard in [Trello](https://trello.com/invite/b/66bfaefd90f57fac8d8a89e2/ATTIe5dc79647cc83c4c1277915c7108c2f8B6931ADF/lms-canelita-team)

## Directory Structure

This is the directory structure that Opcion1CanelitaTeam project uses:

```bash
.
├── LMS.DataAccess
│   ├── LMS.DataAccess.csproj
│   ├── Program.cs
│   └── src
│       ├── BookSystem
│       ├── BorrowSystem
│       ├── Console
│       ├── Core
│       ├── FineSystem
│       ├── ReportSystem
│       ├── SearchSystem
│       ├── StatisticSystem
│       ├── UserSystem
│       └── Utils
├── LMS.Tests
│   ├── GlobalUsings.cs
│   ├── LMS.Tests.csproj
│   └── UnitTest1.cs
├── Opcion1CanelitaTeam.sln
```

You can visit this [link](https://learn.microsoft.com/en-us/dotnet/core/porting/project-structure) if you want to know more about **How to Structure .Net Projects.**

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
