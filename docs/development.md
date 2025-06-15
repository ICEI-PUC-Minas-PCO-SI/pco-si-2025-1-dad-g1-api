
# Desenvolvimento da Aplicação

## Modelagem da Aplicação
A arquitetura em microsserviços permitirá que cada funcionalidade principal seja desenvolvida e implantada de forma independente. Cada serviço terá seu próprio banco de dados, garantindo o baixo acoplamento.

### Estrutura de Dados e Entidades por Microsserviço
1. RF-001: Serviço de Gestão de Usuários (Responsável: __Vinícius Célio__) 
   * Entidade Principal: Usuario
   * Artefato Criado: Microsserviço de Usuários

2. RF-002: Serviço de Gestão de Eventos (Responsável: __Vinícius Andrade__) 
   * Entidade Principal: Evento
   * Artefato Criado: Microsserviço de Eventos

3. RF-003: Serviço de Inscrição de Participantes (Responsável: __Derick__) 
   * Entidade Principal: Inscricao
   * Artefato Criado: Microsserviço de Inscrições

4. RF-004: Serviço de Check-in no Evento (Responsável: __Evaldo__) 
   * Entidade Principal: Checkin
   * Artefato Criado: Microsserviço de Check-in

5. RF-005: Serviço de Notificações e Comunicação (Responsável: __Matheus__) 
   * Entidade Principal: Notificacao
   * Artefato Criado: Microsserviço de Notificações

6. RF-007: Serviço de Controle de Lista de Espera (Responsável: __Luan__) 
   * Entidade Principal: Não se aplica
   * Artefato Criado: Não foi criado

## Tecnologias Utilizadas
O software foi construído sobre uma arquitetura de microsserviços, que permite o desenvolvimento de aplicações escaláveis e flexíveis, onde cada serviço funciona de forma independente. As tecnologias que sustentam essa arquitetura incluem:

* API ASP.NET CORE, 
* Swagger
* SQLServer
* Postman
* Ocelot
* Python
* Firebase

## Programação de Funcionalidades

Implementação do sistema descritas por meio dos requisitos funcionais e/ou não funcionais. Deve relacionar os requisitos atendidos os artefatos criados (código fonte) além das estruturas de dados utilizadas e as instruções para acesso e verificação da implementação que deve estar funcional no ambiente de hospedagem.

Para cada requisito funcional, pode ser entregue um artefato desse tipo.

### Requisitos Atendidos

As tabelas que se seguem apresentam os requisitos funcionais e não-funcionais que relacionam o escopo do projeto com os artefatos criados:

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Responsavel | Artefato Criado |
|------|-----------------------------------------|----| ----|
|RF-001| A aplicação deve permitir gestão de usuários  | Vinicius Celio	 | Serviço de gestão de usuários |
|RF-002| A aplicação deve permitir gestão de eventos    | Vinícius de Andrade	 | EventApi |
|RF-003| A aplicação deve permitir inscrição de participantes   | Derick | |
|RF-004| A aplicação deve permitir fazer checkin no evento     | Evaldo | |
|RF-005| A aplicação deve fazer a notificações e comunicação    | Matheus | |
|RF-007| A aplicação deve ter controle de lista de espera   | Luan | |

---
# Gestão de Usuários

## Modelagem da Aplicação
A modelagem da aplicação do serviço de gestão de usuários é centralizada no modelo Usuario, que representa a entidade principal com dados como Nome, Email, e o hash da Senha. Para controle de acesso, cada usuário possui uma Role (Participante, Criador de Eventos, Admin), que é crucial para a autenticação via JWT. O ApplicationDbContext gerencia a persistência desses dados no SQL Server, utilizando o Entity Framework Core para mapeamento e migrações.

### Entidade: Usuario
| Campo         | Tipo     | Descrição                                                   |
| ------------- | -------- | ----------------------------------------------------------- |
| Id            | INT (PK) | Identificador único do Usuario                              |
| Nome          | string   | Nome do usuário                                             |
| Email         | string   | E-mail do usuário                                           |
| SenhaHash     | string   | Hash da senha do usuário                                    |
| PapelUsuario  | int      | Papel do usuário no sistema (Participante, Criador, Admin)  |
| CriadoEm      | DateTime | Data da criação do usuário                                  |

## Tecnologias Utilizadas

1. **ASP.NET Core 8.0**
   - Para a construção da API RESTful.
2. **Entity Framework Core e SQL Server**
   - Para acesso e gestão de dados.
3. **JSON Web Tokens (JWT)**
   - Garantir a segurança e autenticação.
4. **BCrypt.Net-Next**
   - Para hashing seguro de senhas.
5. **AutoMapper**
   - Para mapeamento de dados.
6. **Swagger/OpenAPI**
   - Para documentação da API.

# Gerenciamento de eventos

## Modelagem da Aplicação

A modelagem da aplicação do microserviço de gerenciamento de eventos foi baseada em uma estrutura simples, porém eficiente, adequada à arquitetura de microsserviços. A modelagem de dados conta com a seguinte entidade principal:

### Entidade: Evento

| Campo         | Tipo     | Descrição                                                   |
| ------------- | -------- | ----------------------------------------------------------- |
| Id            | INT (PK) | Identificador único do evento                               |
| Name          | string   | Nome do evento                                              |
| Description   | string   | Descrição do evento                                         |
| Price         | double   | Preço do ingresso do evento                                 |
| Date          | DateOnly | Data de acontecimento do evento                             |
| Capacity      | int      | Capacidade de público do evento                             |
| AgeRange      | int      | Faixa etária evento                                         |
| Time          | string   | Horário do evento                                           |
| Location      | string   | Lugar do evento                                             |
| State         | string   | Estado onde o evento ocorrerá                               |
| City          | string   | Cidade onde o evento ocorrerá                               |
| Address       | string   | Endereço onde o evento ocorrerá                             |
| CreatorId     | int      | Id do produtor do evento                                    |
| CreatorName   | string   | Nome do produtor do evento                                  |
| CreatedAt     | DateTime | Data de registro do evento                                  |


## Tecnologias Utilizadas

1. **ASP.NET Web API**

   - Utilizado para construir o microserviço com todos os endpoints RESTful, seguindo boas práticas de organização em camadas (controller, models, contexto).

2. **SQL Server**

   - Banco de dados relacional para persistência das inscrições com suporte a integridade referencial e escalabilidade.

3. **Entity Framework Core**

   - ORM para otimizar o mapeamento objeto-relacional entre C# e SQL Server.

4. **Swagger**

   - Geração automática de documentação da API e ferramenta para testes manuais dos endpoints.

5. **Postman**

   - Ferramenta para testes manuais e automatizados, incluindo simulação de carga.


---

## Programação de Funcionalidades

A implementação do sistema foi guiada pelos requisitos funcionais e não funcionais definidos no escopo do projeto. O microserviço de Gerenciamento de eventos atende aos seguintes requisitos:

### Requisitos Funcionais Atendidos

| ID     | Descrição do Requisito                                                           | Responsável | Artefato Criado                          |
| ------ | -------------------------------------------------------------------------------- | ----------- | ---------------------------------------- |
| RF-002 | A aplicação deve permitir gestão de eventos                                      | Vinícius de Andrade      | `EventsController.cs`                |

### Requisitos Não Funcionais Atendidos

| ID      | Descrição do Requisito                                                            | Implementado? | Ferramenta/Justificativa                       |
| ------- | --------------------------------------------------------------------------------- | ------------- | ---------------------------------------------- |
| RNF-001 | A aplicação deve ser responsiva                                                   | (API REST)  | API stateless acessível via múltiplos clientes |
| RNF-003 | Deve ser implementado um sistema de log para registrar erros e eventos relevantes |  Parcial    | Logging via console padrão do ASP.NET          |

### Acesso e Verificação

- **URL local (Swagger):** `https://localhost:7014/swagger`
- **Testes funcionais:** realizados via Postman
- **Banco:** SQL Server, com estrutura de dados gerada via migrations
- **Deploy local:** `dotnet run` no Visual Studio 2022


Esse conjunto cobre o núcleo funcional do microserviço de inscrição, mantendo o código modular, testável e compatível com o restante da arquitetura proposta.

---

# Inscricao de evento

## Modelagem da Aplicação

A modelagem da aplicação do microserviço de Inscrição de Participantes foi baseada em uma estrutura simples, porém eficiente, adequada à arquitetura de microsserviços. A modelagem de dados conta com a seguinte entidade principal:

### Entidade: Inscrição

| Campo         | Tipo     | Descrição                                                   |
| ------------- | -------- | ----------------------------------------------------------- |
| Id            | INT (PK) | Identificador único da inscrição                            |
| EventoId      | INT      | ID do evento associado (referência externa)                 |
| UsuarioId     | INT      | ID do usuário que realizou a inscrição                      |
| DataInscricao | DATETIME | Data e hora em que a inscrição foi feita                    |
| Ativa         | BIT      | Indica se a inscrição está ativa ou cancelada (soft delete) |


## Tecnologias Utilizadas

1. **ASP.NET Web API**

   - Utilizado para construir o microserviço com todos os endpoints RESTful, seguindo boas práticas de organização em camadas (controller, models, contexto).

2. **SQL Server**

   - Banco de dados relacional para persistência das inscrições com suporte a integridade referencial e escalabilidade.

3. **Entity Framework Core**

   - ORM para facilitar o mapeamento objeto-relacional entre C# e SQL Server.

4. **Swagger**

   - Geração automática de documentação da API e ferramenta para testes manuais dos endpoints.

5. **Postman**

   - Ferramenta para testes manuais e automatizados, incluindo simulação de carga.


---

## Programação de Funcionalidades

A implementação do sistema foi guiada pelos requisitos funcionais e não funcionais definidos no escopo do projeto. O microserviço de Inscrição de Participantes atende aos seguintes requisitos:

### Requisitos Funcionais Atendidos

| ID     | Descrição do Requisito                                                           | Responsável | Artefato Criado                          |
| ------ | -------------------------------------------------------------------------------- | ----------- | ---------------------------------------- |
| RF-003 | A aplicação deve permitir inscrição de participantes em eventos                  | Derick      | `InscricoesController.cs`                |
| RF-006 | A aplicação deve emitir relatórios e análises (total de inscritos)               | Derick      | método `TotalInscritos(eventoId)` na API |

### Requisitos Não Funcionais Atendidos

| ID      | Descrição do Requisito                                                            | Implementado? | Ferramenta/Justificativa                       |
| ------- | --------------------------------------------------------------------------------- | ------------- | ---------------------------------------------- |
| RNF-001 | A aplicação deve ser responsiva                                                   | (API REST)  | API stateless acessível via múltiplos clientes |
| RNF-003 | Deve ser implementado um sistema de log para registrar erros e eventos relevantes |  Parcial    | Logging via console padrão do ASP.NET          |

### Acesso e Verificação

- **URL local (Swagger):** `https://localhost:7050/swagger`
- **Testes funcionais:** realizados via Postman (arquivo de teste de carga incluído)
- **Banco:** Azure SQL Server, com estrutura de dados gerada via migrations
- **Deploy local:** `dotnet run` no Visual Studio 2022

---

Esse conjunto cobre o núcleo funcional do microserviço de inscrição, mantendo o código modular, testável e compatível com o restante da arquitetura proposta.

# Notificação de evento

## Modelagem da Aplicação

A modelagem da aplicação do microserviço de Notificação de eventos foi baseada em uma estrutura de tabela unica de notificação e uma tabela para acesso de terceiro para uso das rotas de notificação. De maneira que se entrega a um terceiro/cliente uma maneira de acesso a API e com isso ele tem permisão de uso a notificações. A modelagem de dados conta com a seguinte entidade principal:

### Entidade: Notificação

##### Tabela: Notificacao

| Campo         | Tipo     | Descrição                                                   |
| ------------- | -------- | ----------------------------------------------------------- |
| codigoNotificacao | INT (PK) | Identificador unico da notificação |
| codigoUsuario | INT | Identificador externo do usuário |
| nome | STRING | Nome |
| email | STRING | Email |
| dataNotificacao | DATETIME  | Data de quando o ususuário sera notificado |
| status | INT | Indicativo de controle da notificação 0 - Criado 1 - Notificado |
| dataPreNotificacao | STRING NULL | Campo onde futuramente poderia ser usado para criar notificações que podem vir antes para o usuario |

### Entidade: Acesso terceiro

##### Tabela: OauthToken

| Campo         | Tipo     | Descrição                                                   |
| ------------- | -------- | ----------------------------------------------------------- |
| id | INT (PK) | Identificador unico do acesso externo
| client | STRING | Nome de identificação do terceiro/cliente
| token | STRING | Token referencia para login do terceiro
| updated_at | DATETIME | Data de atualização do acesso
| expires_at | DATETIME | Data de expiração do acesso 
| created_at | DATETIME | Data de criação do acesso

## Tecnologias Utilizadas

1. **ASP.NET Web API**

   - Utilizado para construir o microserviço com todos os endpoints RESTful, seguindo boas práticas de organização em camadas (controller, models, contexto).

2. **SQL Server**

   - Banco de dados relacional para persistência das inscrições com suporte a integridade referencial e escalabilidade.

3. **Entity Framework Core**

   - ORM para facilitar o mapeamento objeto-relacional entre C# e SQL Server.

4. **Hang Fire**

   - Usado para a execução do job.

5. **ByCript**

   - Geração de criptografia e uso do JWT.

4. **Swagger**

   - Geração automática de documentação da API e ferramenta para testes manuais dos endpoints.

5. **Postman**

   - Ferramenta para testes manuais e automatizados, incluindo simulação de carga.

---

## Programação de Funcionalidades

A implementação do sistema foi guiada pelos requisitos funcionais e não funcionais definidos no escopo do projeto. O microserviço de Inscrição de Participantes atende aos seguintes requisitos:

### Requisitos Funcionais Atendidos

| ID     | Descrição do Requisito                                                           | Responsável | Artefato Criado                          |
| ------ | -------------------------------------------------------------------------------- | ----------- | ---------------------------------------- |
| RF-005 | A aplicação deve fazer a notificações e comunicação                  | Matheus      | `NotificacaosController.cs`                |

### Acesso e Verificação

- **URL local (Swagger):** `https://localhost:5076/swagger`
- **Testes funcionais:** realizados via Postman (arquivo de teste de carga incluído)
- **Banco:** SQL Server, com estrutura de dados gerada via migrations
- **Deploy local:** `dotnet run` no Visual Studio 2022

---

Esse conjunto cobre o núcleo funcional do microserviço de notificação, mantendo o código modular, testável e compatível com o restante da arquitetura proposta.


