# Cross Platform SQL Project

## Thoughts behind the project

When we set up a SQL project in a new project there is always some time used to get everything up and running. To ease the effort this template is created so that everyone across Windows, Mac OS and Linux get up and running in no time.

## Warning

This project is currently in development and lot of the codebase is therefore not following best practices and is missing error handling. If you find any errors please submit an issue or feel free to contribute with a pull request.

### Limitations

The project is based on the initial state of a SQL project using Azure Data Studio. If you are opening this workspace in Azure Data Studio you may break this solution or seeing strange artifacts. The primary issue is because project files and workspace files are not updated when adding/removing files. A goal for the future would be to make sure that this solution work using Azure Data Studio and Visual Studio Code.

## Before you start

This demo is created so that it can run cross platform. Please make sure that you have the following installed on your machine before continuing.

### Required tools

- [Visual Studio Code](https://code.visualstudio.com/)
- [.NET 5 Framework](https://dotnet.microsoft.com/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Optional tools

- [Azure Data Studio](https://docs.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver15) or SSMS (SQL Server Management Studio) is an option if you are using Windows.

## Getting started

This project does not run under Azure Data Studio.

### Setting up the development environment

Before running the setup script, please install **dotnet-script** tooling.

If you have not used **dotnet-script** tooling before, please run the below command.

``` sh
dotnet tool install dotnet-script -g
```

However, if it's a long time since you last used the tooling it may be relevant to run the following command.

```sh
dotnet tool update dotnet-script -g
```

When the **dotnet-script** tooling is available, then run the following command. This will download the tSQLt framework used for our unit tests.

```sh
dotnet script setup.csx
```

### Starting the local development server

By default local development server will start automatically when opening the folder in Visual Studio Code. The startup sequence is defined in **/.vscode/tasks.json** and the task actions can be run manually from the editor using the Task Explorer extension or the command palette.

The task is named **start-database**.

### Deploying changes

Deploying database changes is done using a predefined task in Visual Studio Code. This will build the src and test project before deploying the changes to the local development server.

The task is named **publish-changes**.

### Building database project

Some times you want to build the database while doing development, but without deploying the changes locally. Building the database projects **src** or **test** is done using a predefined task in Visual Studio Code.

The tasks is named

- build-src
- build-tests
