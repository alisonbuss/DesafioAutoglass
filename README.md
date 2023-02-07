
#### Translation for: **[English](https://github.com/alisonbuss/nx-stack-reactjs/blob/master/README_LANG_EN.md)**.

# Implementar um desafio prático de programação do Autoglass.

#### Status do Projeto: *(Finalizado)*.

### Projeto foi Inspirado:

Há um tempo atrás, criei dois projetos, um para me auxiliar na criação de projetos Domain-Driven Design (DDD) em .Net Core, e o outro, um CRUD de usuários em Domain-Driven Design, abaixo os projetos que me inspiraram a criar esse desafio:

  - **[[create-basic-structure-for-ddd](https://github.com/alisonbuss/create-basic-structure-for-ddd)]** Script to create basic structure for DDD(Domain-Driven Design) projects in .Net Core.
  - **[[quickstart-dotnet-core-ddd](https://github.com/alisonbuss/quickstart-dotnet-core-ddd)]** User CRUD in a structure (Domain-Driven Design) in .Net Core.

### Objetivo:

Criar uma API para gestão de produtos, com os seguintes recursos:

- Recuperar um registro por código; ***(IMPLEMENTADO)***
- Listar registros, filtrando a partir de parâmetros e paginando a resposta; ***(PARCIALMENTE IMPLEMENTADO)***
- Inserir e criar validação para o campo data de fabricação que não poderá ser maior ou igual a data de validade; ***(PARCIALMENTE IMPLEMENTADO)***
- Editar e criar validação para o campo data de fabricação que não poderá ser maior ou igual a data de validade; ***(PARCIALMENTE IMPLEMENTADO)***
- Exclusão deverá ser lógica, atualizando o campo situação com o valor Inativo; ***(IMPLEMENTADO)***

Campos do escopo do produto: ***(IMPLEMENTADO)***

- Código do produto (sequencial e não nulo);
- Descrição do produto (não nulo);
- Situação do produto (Ativo ou Inativo);
- Data de fabricação;
- Data de validade;
- Código do fornecedor;
- Descrição do fornecedor;
- CNPJ do fornecedor;

Criterio de aceite:

- Construir a Web-api em dotnet core ou dotnet 5; ***(IMPLEMENTADO)***
- Construir a estrutura em camadas e em Domain-Driven Design (DDD); ***(IMPLEMENTADO)***

Diferenciais:

- Utilizar ORM; ***(IMPLEMENTADO)***
- Utilizar a biblioteca Automapper para fazer o mapeamento entity-DTO; ***(IMPLEMENTADO)***
- Fazer teste unitários; ***(NÃO IMPLEMENTADO)***

### Dependências do Ambiente:

Todo o projeto foi criado e desenvolvido em uma máquina Linux, com as seguintes dependências:

- **[[VS Code](https://code.visualstudio.com/download)]** 1.74.0 ou superior...
- **[[Dotnet](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)]** 7.0.1 ou superior...
- **[[Docker](https://docs.docker.com/engine/docker-overview/)]** 20.10.9 ou superior...
- **[[Docker Compose](https://docs.docker.com/compose/)]** 2.7.0 ou superior...

> **Nota:**
>
> - _É necessário ter instalado as dependências citadas a cima, para que o projeto funcione._
> - _O desenvolvimento desse projeto foi feita através de um **Desktop Ubuntu 22.04.1 LTS (Jammy Jellyfish)**._


### Command-line usados para criar o projeto:

Documentação de apoio:

- **[.NET Core Command-line](https://learn.microsoft.com/en-us/dotnet/core/tools/)**

#### Criar o Solution:

```bash
$ dotnet new sln --name DesafioAutoglass --output ./DesafioAutoglass;
$ dotnet new gitignore;
```

#### Criar o projeto: DesafioAutoglass.Service.API:

```bash
$ dotnet new webapi --name DesafioAutoglass.Service.API --no-https true --output ./DesafioAutoglass/src/DesafioAutoglass.Service.API;
# Adicionar projeto a Solution:
$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Service.API/DesafioAutoglass.Service.API.csproj --solution-folder '1 - Services';
```

#### Criar o projeto: DesafioAutoglass.Application:

```bash
$ dotnet new classlib --name DesafioAutoglass.Application --output ./DesafioAutoglass/src/DesafioAutoglass.Application --framework net7.0;
# Adicionar projeto a Solution:
$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Application/DesafioAutoglass.Application.csproj --solution-folder '2 - Application';
```

#### Criar o projeto: DesafioAutoglass.Domain:

```bash
$ dotnet new classlib --name DesafioAutoglass.Domain --output ./DesafioAutoglass/src/DesafioAutoglass.Domain --framework net7.0;
# Adicionar projeto a Solution:
$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Domain/DesafioAutoglass.Domain.csproj --solution-folder '3 - Domain';
```

#### Criar o projeto: DesafioAutoglass.Infra.Data:

```bash
$ dotnet new classlib --name DesafioAutoglass.Infra.Data --output ./DesafioAutoglass/src/DesafioAutoglass.Infra.Data --framework net7.0;
# Adicionar projeto a Solution:
$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Infra.Data/DesafioAutoglass.Infra.Data.csproj --solution-folder '4 - Infra';
```

#### Criar o projeto: DesafioAutoglass.Infra.Cache:

```bash
$ dotnet new classlib --name DesafioAutoglass.Infra.Cache --output ./DesafioAutoglass/src/DesafioAutoglass.Infra.Cache --framework net7.0;
# Adicionar projeto a Solution:
$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Infra.Cache/DesafioAutoglass.Infra.Cache.csproj --solution-folder '4 - Infra';
```

#### Criar o projeto: DesafioAutoglass.Infra.CrossCutting:

```bash
$ dotnet new classlib --name DesafioAutoglass.Infra.CrossCutting --output ./DesafioAutoglass/src/DesafioAutoglass.Infra.CrossCutting --framework net7.0;
# Adicionar projeto a Solution:
$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Infra.CrossCutting/DesafioAutoglass.Infra.CrossCutting.csproj --solution-folder '4 - Infra';
```

#### Criar o projeto: DesafioAutoglass.Common:

```bash
$ dotnet new classlib --name DesafioAutoglass.Common --output ./DesafioAutoglass/src/DesafioAutoglass.Common --framework net7.0;
$ dotnet add ./DesafioAutoglass/src/DesafioAutoglass.Common/DesafioAutoglass.Common.csproj package Microsoft.Extensions.Logging.Abstractions -v 7.0.0;
$ dotnet add ./DesafioAutoglass/src/DesafioAutoglass.Common/DesafioAutoglass.Common.csproj package FluentValidation -v 11.4.0;
# Adicionar projeto a Solution:
$ dotnet sln ./DesafioAutoglass/DesafioAutoglass.sln add ./DesafioAutoglass/src/DesafioAutoglass.Common/DesafioAutoglass.Common.csproj --solution-folder '5 - Common';
```

#### Aplicar o restore de toda a Solution:

```bash
$ dotnet restore ./DesafioAutoglass/DesafioAutoglass.sln;
```

### Estrutura do projeto:

Descrição dos arquivos e diretórios do projeto:

```text
.
├── .vscode.........................Arquivos de configuração do VS Code
│   ├── extensions.json
│   ├── launch.json
│   ├── settings.json
│   └── tasks.json
├── files
│   |── docs
│   |   └── ...
│   └── services....................Arquivos de suporte e configuração dos serviços Docker
│       ├── mssql
│       │   ├── entrypoint.sh
│       │   └── sql-scripts
│       │       ├── 01-base.sql
│       │       ├── 02-tables.sql
│       │       ├── 03-procedures.sql
│       │       ├── 04-views.sql
│       │       └── 05-inserts.sql
│       ├── rabbitmq
│       │   └── rabbitmq-3.11.conf
│       └── redis
│           ├── redis-custom.conf
│           └── redis-default-6.0.conf
├── src............................................Pasta dos códigos fontes do projeto
│   ├── DesafioAutoglass.Application
│   │   ├── DesafioAutoglass.Application.csproj
│   │   └── ...
│   ├── DesafioAutoglass.Common
│   │   ├── DesafioAutoglass.Common.csproj
│   │   └── ...
│   ├── DesafioAutoglass.Domain
│   │   ├── DesafioAutoglass.Domain.csproj
│   │   └── ...
│   ├── DesafioAutoglass.Infra.Cache
│   │   ├── DesafioAutoglass.Infra.Cache.csproj
│   │   └── ...
│   ├── DesafioAutoglass.Infra.CrossCutting
│   │   ├── DesafioAutoglass.Infra.CrossCutting.csproj
│   │   └── ...
│   ├── DesafioAutoglass.Infra.Data
│   │   ├── DesafioAutoglass.Infra.Data.csproj
│   │   ├── appsettings.Migration.json.............Arquivo de configuração do .NET Core
│   │   └── ...
│   └── DesafioAutoglass.Service.API
│       ├── DesafioAutoglass.Service.API.csproj
│       ├── appsettings.Development.json...........Arquivo de configuração do .NET Core (Ambiente DEV)
│       ├── appsettings.json.......................Arquivo de configuração do .NET Core (Ambiente GLOBAL)
│       │── StaticContents.........................Pasta de arquivos estático
│       │   ├── private
│       │   │   └── .gitkeep
│       │   └── public
│       │       └── index.html
│       └── ...
├── test............................Pasta dos códigos fontes do projeto de testes
│   └── .gitkeep
├── .dockerignore...................Arquivo para excluir arquivos ou diretórios desnecessários do seu contexto de build
├── .env............................Arquivo de variáveis de ambiente
├── .gitignore......................Arquivo que diz ao Git quais arquivos ou pastas ele deve ignorar em um projeto
├── creation-commands.txt...........Arquivo com a descrição dos comandos que gerou o projeto
├── DesafioAutoglass.sln............Arquivo de configuração da estrutura e organização dos projetos no Visual Studio
├── docker-compose.services.yml.....Docker Compose dos serviços externos
├── docker-compose.webapi.yml.......Docker Compose da aplicação do projeto
├── Dockerfile.webapi...............Dockerfile da aplicação do projeto
├── LICENSE.........................Licença (MIT)
├── Makefile........................Arquivo principal de start do projeto "$ make help".
├── README_LANG_EN.md...............Arquivo de tradução do README.md.
└── README.md.......................Documentação Geral do Projeto.
```

### Serviços externos do projeto:

O projeto contém 5 serviços encapsulados em um Docker Compose, os serviços são eles:

- **[Redis](https://hub.docker.com/_/redis)**
    - Serviço: redis_server
    - Imagem: redis:6.0.5
    - Porta: 6379
    - Rede: localhost ou redis_server
    - Pass: password

- **[Redis Commander](https://hub.docker.com/r/rediscommander/redis-commander)**
    - Serviço: redis_webapp
    - Imagem: rediscommander/redis-commander:latest
    - Porta: 8081
    - Rede: localhost
    - UI Web: http://localhost:8081
        - User: admin
        - Pass: password

- **[RabbitMQ](https://hub.docker.com/_/rabbitmq)**
    - Serviço: rabbitmq_server
    - Imagem: rabbitmq:3.11-management
    - Porta: 5672 e 15672
    - Rede: localhost ou rabbitmq_server
    - UI Web: http://localhost:15672
        - User: admin
        - Pass: password

- **[Microsoft SQL Server](https://hub.docker.com/_/microsoft-mssql-server)**
    - Serviço: mssql_server
    - Imagem: mcr.microsoft.com/mssql/server:2019-latest
    - Porta: 1433 e 5022
    - Rede: localhost ou mssql_server
    - User: sa
    - Pass: !demo54321

- **[Microsoft SQL Server Command Line Tools](https://hub.docker.com/_/microsoft-mssql-tools)**
    - Serviço: mssql_tools
    - Imagem: mcr.microsoft.com/mssql-tools

- **[SQLPad](https://hub.docker.com/r/sqlpad/sqlpad)**
    - Serviço: sqlpad_webapp
    - Imagem: sqlpad/sqlpad:6
    - Porta: 3001
    - Rede: localhost
    - UI Web: http://localhost:3001
        - User: admin
        - Pass: password

#### Executando o Serviços via Docker Compose:

Para rodar os serviços no Docker Compose, siga com os comandos abaixo:

```bash
# Exibir informações gerais do ambiente Docker.
$ docker image ls && docker network ls && docker volume ls && docker container ls;

# Valide e visualize o arquivo de composição.
$ docker-compose --file ./docker-compose.services.yml config;

# Criar ou reconstruir serviços e construa imagens em paralelo.
$ docker-compose --file ./docker-compose.services.yml build --parallel;

# Criar ou reconstruir serviços no modo desanexado.
$ docker-compose --file ./docker-compose.services.yml up --detach;

# Lista todos os containers do Compose.
$ docker-compose --file ./docker-compose.services.yml ps;
```

Para destruir todos os serviços, network, volumes e imagens:

```bash
# Parar e remover contêineres, redes, imagens e volumes.
$ docker-compose --file ./docker-compose.services.yml down;
$ docker-compose --file ./docker-compose.services.yml rm -f;

# DANDO UMA LIMPADA NO AMBIENTE:
# Esse comando remove todos os contêineres parados, redes não utilizadas, imagens pendentes e caches de compilação...
# É o satanais!!!
$ docker system prune -a;

## OU...
$ docker stop $(docker ps -a -q) && docker rm $(docker ps -a -q) && docker rmi $(docker images -q);
```

### Executando o projeto:

#### Executando via VS Code:

...

#### Executando via .NET Core Command-line:

Para executar o projeto .NET Core, siga com os comandos abaixo:

Documentação de apoio:

- **[.NET Core Command-line](https://learn.microsoft.com/en-us/dotnet/core/tools/)**

```bash
# Restaura as dependências e as ferramentas de um projeto.
$ dotnet restore --force --verbosity n;

# Compila um projeto e todas as suas dependências.
$ dotnet build --configuration Debug --output ./builds/webapi --verbosity n --force;

# Publica o aplicativo e suas dependências em uma pasta para implantação em um sistema de hospedagem.
$ dotnet publish --configuration Debug --output ./builds/webapi/publish --verbosity n --force;

# Exportar variável de ambiente à nivel global, para determinar o ambiente de tempo de execução do .NET Core.
$ export ASPNETCORE_ENVIRONMENT=Development;
# OU:
$ export ASPNETCORE_ENVIRONMENT=Production;

# O comando ($ dotnet) tem duas funções:
# -- Ele fornece comandos para trabalhar com projetos .NET.
# -- Ele executa aplicativos .NET.
$ dotnet ./builds/webapi/publish/DesafioAutoglass.Service.API.dll --verbosity n --force;

# OU:

# Executa o código-fonte sem qualquer comando de compilação ou inicialização explícito.
$ dotnet run --project ./src/DesafioAutoglass.Service.API/DesafioAutoglass.Service.API.csproj --verbosity n --force;
```

Aplicando o Migrations do Entity Framework Core, siga com os comandos abaixo:

Documentação de apoio:

- **[Installing Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install)**
- **[Migrations Overview](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)**

```bash
# Primeiramente, temos que instalar o Entity Framework Core no computador.
# OBS: Basta fazer apenas uma vez no computador.
$ dotnet tool install --global dotnet-ef;

# Adiciona uma nova migração, o nome da migração, o diretório usa para gerar os arquivos.
# Os caminhos são relativos ao diretório do projeto de destino.
$ dotnet ef migrations add Initial --output-dir Migrations --context DbContextMigration --startup-project "./src/DesafioAutoglass.Infra.Data" --verbose;

# Aplica as atualizações o banco de dados para a última migração ou para uma migração especificada.
$ dotnet ef database update --context DbContextMigration --startup-project "./src/DesafioAutoglass.Infra.Data" --verbose;
```

#### Executando via Docker Compose:

Para rodar a aplicação no Docker Compose, siga com os comandos abaixo:

```bash
# Exibir informações gerais do ambiente Docker.
$ docker image ls && docker network ls && docker volume ls && docker container ls;

# Valide e visualize o arquivo de composição.
$ docker-compose --file ./docker-compose.webapi.yml config;

# Criar ou reconstruir serviços e construa imagens em paralelo.
$ docker-compose --file ./docker-compose.webapi.yml build --parallel;

# Criar ou reconstruir serviços no modo desanexado.
$ docker-compose --file ./docker-compose.webapi.yml up --detach;

# Lista todos os containers do Compose.
$ docker-compose --file ./docker-compose.webapi.yml ps;
```

Para destruir toda a aplicação, network, volumes e imagens:

```bash
# Parar e remover contêineres, redes, imagens e volumes.
$ docker-compose --file ./docker-compose.webapi.yml down;
$ docker-compose --file ./docker-compose.webapi.yml rm -f;

# DANDO UMA LIMPADA NO AMBIENTE:
# Esse comando remove todos os contêineres parados, redes não utilizadas, imagens pendentes e caches de compilação...
# É o satanais!!!
$ docker system prune -a;

## OU...
$ docker stop $(docker ps -a -q) && docker rm $(docker ps -a -q) && docker rmi $(docker images -q);
```

### Referências:

- Documentação oficial. **ASP.NET documentation** <br/>
  Disponível: _[https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0)_

- Documentação oficial. **.NET Core Command-line** <br/>
  Disponível: _[https://learn.microsoft.com/en-us/dotnet/core/tools/](https://learn.microsoft.com/en-us/dotnet/core/tools/)_

- Documentação oficial. **Installing Entity Framework Core** <br/>
  Disponível: _[https://learn.microsoft.com/en-us/ef/core/get-started/overview/install](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install)_

- Documentação oficial. **Migrations Overview** <br/>
  Disponível: _[https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)_

- Canal YouTube, Filipe Brito Dev. ***Web API C#*** <br/>
  Disponível: _[https://www.youtube.com/playlist?list=PLIICLSbtN_uFPLnXg7VPq30pMymwCd8hX](https://www.youtube.com/playlist?list=PLIICLSbtN_uFPLnXg7VPq30pMymwCd8hX)_

- Canal YouTube, desenvolvedor.io. ***ASP.NET 6 - O QUE ACONTECEU COM A CLASSE STARTUP?*** <br/>
  Disponível: _[https://www.youtube.com/watch?v=VgjHQvprRy0](https://www.youtube.com/watch?v=VgjHQvprRy0)_

- Canal YouTube, Daniel Jesus. ***REST API C# - Construindo um REST API com conceitos DDD + EF + Docker + IOC em .NET CORE 3.1*** <br/>
  Disponível: _[https://www.youtube.com/watch?v=plS-rf2UIPI](https://www.youtube.com/watch?v=plS-rf2UIPI)_

- Canal YouTube, DEV NET CORE Valdir Ferreira. ***(EM FIM SAIU DO FORNO) DDD domain driven design 2020 .NET Core 3.1.1 C# usando (Async Task)*** <br/>
  Disponível: _[https://www.youtube.com/watch?v=MjnO2mcE-AQ](https://www.youtube.com/watch?v=MjnO2mcE-AQ)_

## Licença:

[<img width="190" src="https://raw.githubusercontent.com/alisonbuss/my-files/master/files/images/logo-open-source-550x200px.png">](https://opensource.org/licenses)
[<img width="166" src="https://raw.githubusercontent.com/alisonbuss/my-files/master/files/images/icon-license-mit-500px.png">](https://github.com/alisonbuss/DesafioAutoglass/blob/master/LICENSE)
