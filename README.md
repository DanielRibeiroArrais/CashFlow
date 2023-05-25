# CashFlow
Aplicação para movimentação de fluxo de caixa e consolidação.





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

## Modelagem Arquitetural
Nesta seção será apresenta a modelagem arquitetural da solução proposta, de forma a permitir seu completo entendimento visando à implementação da prova de conceito para o Diagrama de Contexto e Container utilizaremos o modelo C4, já o Diagrama de Componentes utilizaremos o padrão UML.


### Diagrama de Contexto
Os usuários usam o sistema na Internet para realizem lançamentos de Débitos e Créditos. Também será necessário um Job para realizar a consolidação do saldo diário.



### Diagrama de Container
O diagrama de container nos mostra que o sistema CashFlow (a caixa tracejada) é composto de XXXXXX containers: uma aplicação em API, um Job para realização da consolidação dos saldos, banco de dados SQL e XXXX Elastic. A aplicação API será utilizado as tecnologias C# CORE. Utilizando API JSON/HTTPS executando no lado do servidor fornece. A aplicação API obtém informações do banco de dados (um esquema de banco de dados relacional). O worker service de alerta, se comunica com a API obtendo dados gerados pelos sensores e se for preciso gera o alerta para os usuários. Tanto o worker service de WhatsApp, SMS e Email fica aguardando a geração de uma nova mensagem e realiza o disparo necessário.


### Diagrama de Componentes
O diagrama abaixo apresenta a comunicação entre os componentes da arquitetura e as tecnologias. Os componentes estão organizados de forma que possam ser reutilizados. Fornecem interfaces bem definidas de acordo com suas responsabilidades.


### Arquitetura de Dados
Como a aplicação utiliza um único banco de dados relacional, apenas um modelo de dados foi gerado.









## Instruções
O [Docker](https://www.docker.com/get-started/) precisar estar instalado em sua máquina juntamente com o [Docker Compose](https://docs.docker.com/compose/install/). Tenha certeza de ter ambos estejam instalados, configurados e em execução. O projeto é composto por quatro componentes principais:

* API
* Banco de Dados - SQL Server
* Logs - Elasticsearch e Kibana
* Jobs - Hangfire 

Cada um destes componentes é representado por um container. Todos estes containers serão criados e configurados automaticamente, não existe a necessidade de nenhum comando manual a não ser o próprio `docker compose up -d`. Inclusive o database utilizado no projeto também será criado e configurado de forma automática.





## Repositório
--





## Organização dos Projetos
Segue abaixo uma breve descrição de cada projeto (.csproj):

- **CashFlow.Presentation:** Descrição em breve.

- **CashFlow.Application:** Descrição em breve.

- **CashFlow.Application.DTO:** Descrição em breve.

- **CashFlow.Domain:** Descrição em breve.

- **CashFlow.Domain.Core:** Descrição em breve.

- **CashFlow.Domain.Services:** Descrição em breve.

- **CashFlow.Infrastructure.Data:** Contém o DbContext e os migrations para atender os requisitos do EF.

- **CashFlow.Infrastructure.Repository:** Descrição em breve.

- **CashFlow.Infrastructure.CrossCutting.Adapter:** Descrição em breve.

- **CashFlow.Infrastructure.CrossCutting.IOC:** Descrição em breve.

- **CashFlow.Jobs:** Onde são configurados os Jobs que executam em background. Neste caso esta configurado o consolidador dos movimentos, que é executado a cada 1 minuto.

- **CashFlow.Test:** Descrição em breve.





## Acesso a Aplicação
Segue as informações de cada container e como acessar as aplicações e seus dados:

- **CashFlow.Presentation:** O acesso a API pode ser feito no endereço abaixo. Ela possui todos os métodos devidamente documentados na própria interface do [Swagger](https://swagger.io/).
  - **Url:** https://localhost:55501/swagger/index.html

- **CashFlow.Jobs:** Dashboard do Hangfire para administração dos jobs que executam em background. Nesse site é possível forçar a execução imediata do Job agendado.
  - **Url:** https://localhost:55502
  - **Usuário:** admin
  - **Senha:** admin

- **Cashflow.Kibana:** Kibana - 7.5.1 - dashboard para visualização dos logs gravados no Elasticsearch.
  - **Url:** https://localhost:5601

- **Cashflow.Elasticsearch:** Elasticsearch 7.5.1 - verificar informações do servidor/serviço.
  - **Url:** https://localhost:9200

- **Cashflow.Database:** Banco de Dados Microsoft SQL Server 2022 - Ubuntu.
  - **Server:** localhost:1433
  - **Database:** CashFlow
  - **User:** sa
  - **Password:** senha@1234