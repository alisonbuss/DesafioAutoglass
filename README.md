
# CREATE A SOLUTION:

```bash
$ dotnet new sln --name DesafioAutoglass --output ./DesafioAutoglass;

$ dotnet new gitignore;
```

## CREATE PROJECT: DesafioAutoglass.Service.API

```bash
$ dotnet new webapi --name DesafioAutoglass.Service.API --no-https true --output ./DesafioAutoglass/src/DesafioAutoglass.Service.API;
$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Service.API/DesafioAutoglass.Service.API.csproj --solution-folder '1 - Services';

$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Service.API/Controllers;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Service.API/Configurations;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Service.API/StaticContents/private;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Service.API/StaticContents/public;
```

## CREATE PROJECT: DesafioAutoglass.Application

```bash
$ dotnet new classlib --name DesafioAutoglass.Application --output ./DesafioAutoglass/src/DesafioAutoglass.Application --framework net7.0;

$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Application/DesafioAutoglass.Application.csproj --solution-folder '2 - Application';

$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Application/Dtos;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Application/Interfaces;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Application/Mappers;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Application/Services;
```

## CREATE PROJECT: DesafioAutoglass.Domain

```bash
$ dotnet new classlib --name DesafioAutoglass.Domain --output ./DesafioAutoglass/src/DesafioAutoglass.Domain --framework net7.0;

$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Domain/DesafioAutoglass.Domain.csproj --solution-folder '3 - Domain';

$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Domain/Entities;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Domain/Enums;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Domain/Interfaces;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Domain/Interfaces/Repositories;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Domain/Interfaces/Services;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Domain/Services;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Domain/Validators;
```

## CREATE PROJECT: DesafioAutoglass.Infra.Data

```bash
$ dotnet new classlib --name DesafioAutoglass.Infra.Data --output ./DesafioAutoglass/src/DesafioAutoglass.Infra.Data --framework net7.0;

$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Infra.Data/DesafioAutoglass.Infra.Data.csproj --solution-folder '4 - Infra';

$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Infra.Data/Context;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Infra.Data/Mappings;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Infra.Data/Migrations;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Infra.Data/Repositories;
```

## CREATE PROJECT: DesafioAutoglass.Infra.Cache

```bash
$ dotnet new classlib --name DesafioAutoglass.Infra.Cache --output ./DesafioAutoglass/src/DesafioAutoglass.Infra.Cache --framework net7.0;

$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Infra.Cache/DesafioAutoglass.Infra.Cache.csproj --solution-folder '4 - Infra';

$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Infra.Cache/Repositories;
```

## CREATE PROJECT: DesafioAutoglass.Infra.CrossCutting

```bash
$ dotnet new classlib --name DesafioAutoglass.Infra.CrossCutting --output ./DesafioAutoglass/src/DesafioAutoglass.Infra.CrossCutting --framework net7.0;

$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Infra.CrossCutting/DesafioAutoglass.Infra.CrossCutting.csproj --solution-folder '4 - Infra';

$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Infra.CrossCutting/Interfaces;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Infra.CrossCutting/IoC;
```

## CREATE PROJECT: DesafioAutoglass.Common

```bash
$ dotnet new classlib --name DesafioAutoglass.Common --output ./DesafioAutoglass/src/DesafioAutoglass.Common --framework net7.0;
$ dotnet add ./DesafioAutoglass/src/DesafioAutoglass.Common/DesafioAutoglass.Common.csproj package Microsoft.Extensions.Logging.Abstractions -v 7.0.0;
$ dotnet add ./DesafioAutoglass/src/DesafioAutoglass.Common/DesafioAutoglass.Common.csproj package FluentValidation -v 11.4.0;

$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Common/DesafioAutoglass.Common.csproj --solution-folder '5 - Common';

$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Common/Constants;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Common/Enums;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Common/Impls;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Common/Interfaces;
$ mkdir -p -v ./DesafioAutoglass/src/DesafioAutoglass.Common/Objects;
```

## RESTORE SOLUTION:

```bash
$ dotnet restore ./DesafioAutoglass/DesafioAutoglass.sln;
```

## RUN SOLUTION:

```bash
$ cd ./DesafioAutoglass

$ dotnet restore --force --verbosity n;

$ dotnet build --configuration Debug --output ./builds/webapi --verbosity n --force;

$ dotnet publish --configuration Debug --output ./builds/webapi/publish --verbosity n --force;

$ export ASPNETCORE_ENVIRONMENT=Development;

$ dotnet "./builds/webapi/publish/DesafioAutoglass.Service.API.dll" --verbosity n --force;

# OU:

$ dotnet run --project ./src/DesafioAutoglass.Service.API/DesafioAutoglass.Service.API.csproj --verbosity n --force;

# Migration:

$ dotnet ef migrations add Initial --output-dir Migrations --context DbContextMigration --startup-project "./src/DesafioAutoglass.Infra.Data" --verbose;

$ dotnet ef database update --context DbContextMigration --startup-project "./src/DesafioAutoglass.Infra.Data" --verbose;

# Docker:

docker-compose up --detach --build;
```
