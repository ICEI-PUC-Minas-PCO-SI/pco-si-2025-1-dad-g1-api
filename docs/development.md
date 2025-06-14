
# Desenvolvimento da Aplicação

## Modelagem da Aplicação
A arquitetura em microsserviços permitirá que cada funcionalidade principal seja desenvolvida e implantada de forma independente. Cada serviço terá seu próprio banco de dados, garantindo o baixo acoplamento.

### Estrutura de Dados e Entidades por Microsserviço
1. RF-001: Serviço de Gestão de Usuários (Responsável: Vinicius Celio) 

Entidade Principal: Usuario
Artefato Criado: Microsserviço de Usuários

2. RF-002: Serviço de Gestão de Eventos (Responsável: Vinicius Andrade) 

Entidade Principal: Evento
Artefato Criado: Microsserviço de Eventos

3. RF-003: Serviço de Inscrição de Participantes (Responsável: Derick) 

Entidade Principal: Inscricao
Artefato Criado: Microsserviço de Inscrições

4. RF-004: Serviço de Check-in no Evento (Responsável: Evaldo) 

Entidade Principal: Checkin
Artefato Criado: Microsserviço de Check-in

5. RF-005: Serviço de Notificações e Comunicação (Responsável: Matheus) 🔔

Entidade Principal: Notificacao
Artefato Criado: Microsserviço de Notificações

6. RF-007: Serviço de Controle de Lista de Espera (Responsável: Luan) ⏳

Entidade Principal: ItemListaEspera
Artefato Criado: Microsserviço de Lista de Espera

## Tecnologias Utilizadas

<!-- Existem muitas tecnologias diferentes que podem ser usadas para desenvolver APIs Web. A tecnologia certa para o seu projeto dependerá dos seus objetivos, dos seus clientes e dos recursos que a API deve fornecer. -->

<ol>
    <li>ASP.NET Web API: parte que fara a construção da camada se serviços que seram oferecidos pela aplicação.</li>
    <li>SQL Server: base para armazenar os dados.</li>
</ol>


## Programação de Funcionalidades

Implementação do sistema descritas por meio dos requisitos funcionais e/ou não funcionais. Deve relacionar os requisitos atendidos os artefatos criados (código fonte) além das estruturas de dados utilizadas e as instruções para acesso e verificação da implementação que deve estar funcional no ambiente de hospedagem.

Para cada requisito funcional, pode ser entregue um artefato desse tipo.

### Requisitos Atendidos

As tabelas que se seguem apresentam os requisitos funcionais e não-funcionais que relacionam o escopo do projeto com os artefatos criados:

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Responsavel | Artefato Criado |
|------|-----------------------------------------|----| ----|
|RF-001| A aplicação deve permitir gestão de usuários  | Vinicius Celio	 |  |
|RF-002| A aplicação deve permitir gestão de eventos    | Vinicius Andrade	 | |
|RF-003| A aplicação deve permitir inscrição de participantes   | Derick | |
|RF-004| A aplicação deve permitir fazer checkin no evento     | Evaldo | |
|RF-005| A aplicação deve fazer a notificações e comunicação    | Matheus | |
|RF-007| A aplicação deve ter controle de lista de espera   | Luan | |

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
| RNF-003 | Deve ser implementado um sistema de log para registrar erros e eventos relevantes | 🔜 Parcial    | Logging via console padrão do ASP.NET          |

### Acesso e Verificação

- **URL local (Swagger):** `https://localhost:7050/swagger`
- **Testes funcionais:** realizados via Postman (arquivo de teste de carga incluído)
- **Banco:** Azure SQL Server, com estrutura de dados gerada via migrations
- **Deploy local:** `dotnet run` no Visual Studio 2022

---

Esse conjunto cobre o núcleo funcional do microserviço de inscrição, mantendo o código modular, testável e compatível com o restante da arquitetura proposta.



