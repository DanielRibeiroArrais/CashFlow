# CashFlow

Aplicação para controle de fluxo de caixa e consolidação.

## Tecnologias Utilizadas

* [C# .NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* [Docker](https://docs.docker.com/engine/reference/builder/)
* [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
* [Swagger](https://swagger.io/)
* [Health Checks](https://learn.microsoft.com/pt-br/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-7.0)
* [Hangfire](https://www.hangfire.io/)
* [ElasticSearch](https://www.elastic.co/pt/)
* [Kibana](https://www.elastic.co/pt/kibana/)

## Visão geral da Arquitetura
EM BREVE

## Instruções
O Docker precisar estar instalado em sua máquina juntamente com o Docker Compose. Tenha certeza de ter ambos estejam instalados, configurados e em execução. O projeto é composto por quatro componentes principais:

* API
* Banco de Dados - SQL Server
* Logs - Elasticsearch e Kibana
* Jobs - Hangfire 

Cada um destes componentes é representado por um container. Todos estes containers serão criados e configurados automaticamente, não existe a necessidade de nenhum comando manual a não ser o próprio docker compose up -d. Inclusive o database utilizado no projeto também será criado e configurado de forma automática.

## Repositório
--

## Organização dos Projetos
Segue abaixo uma breve descrição de cada projeto (.csproj):

- **CashFlow.Presentation**: Descrição em breve.

- **CashFlow.Application**: Descrição em breve.

- **CashFlow.Application.DTO**: Descrição em breve.

- **CashFlow.Domain**: Descrição em breve.

- **CashFlow.Domain.Core**: Descrição em breve.

- **CashFlow.Domain.Services**: Descrição em breve.

- **CashFlow.Infrastructure.Data**: Contém o DbContext e os migrations para atender os requisitos do EF.

- **CashFlow.Infrastructure.Repository**: Descrição em breve.

- **CashFlow.Infrastructure.CrossCutting.Adapter**: Descrição em breve.

- **CashFlow.Infrastructure.CrossCutting.IOC**: Descrição em breve.

- **CashFlow.Jobs**: Onde são configurados os Jobs que executam em background. Neste caso esta configurado o consolidador dos movimentos, que é executado a cada 1 minuto.

- **CashFlow.Test**: Descrição em breve.