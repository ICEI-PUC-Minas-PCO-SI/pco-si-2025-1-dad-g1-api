## Testes



## Estratégia de Teste

A estratégia de teste para o microserviço de Inscrição de Participantes contempla uma abordagem mista, utilizando testes unitários, testes de integração, testes de carga e testes manuais via Postman. Os testes têm como objetivo garantir o correto funcionamento da aplicação, a comunicação entre componentes e a estabilidade sob carga.

### Tipos de Teste:

- **Testes Unitários**: Validação de funções individuais como lógica de verificação de inscrição, cancelamento e criação de registros. Ferramenta: .
- **Testes de Integração**: Valida a interação entre o controlador, serviço e repositório. Ferramenta:  com banco em memória ou ambiente de desenvolvimento.
- **Testes de Carga**: Avaliam o comportamento do microserviço sob alta demanda de requisições simultâneas.
- **Testes de API**: Validação funcional usando Postman com diferentes cenários de uso.

### Ferramentas

- **Postman**: Para testes funcionais manuais e testes de contrato de API.
- **Swagger**: Para execução manual e exploração de endpoints.

---

| Qual microservico         | teste |
|  :----:   | ----------- |
| Microserviço de Inscrição de Participantes        |[Postman json](pco-si-2025-1-dad-g1-api/src/planodetesteincricaoevento.json) |

# Plano de Testes - Microserviço de Inscrição de Participantes

## Casos de Teste

### 1. Inscrição (POST /api/inscricoes)

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT01 | Criar inscrição válida | eventoId=1, usuarioId=201 | 201 Created |
| CT02 | Criar inscrição duplicada | eventoId=1, usuarioId=201 | 409 Conflict |
| CT03 | Criar inscrição em outro evento | eventoId=2, usuarioId=201 | 201 Created |

<img title="Ct01" alt="Alt text" src="/docs/img/Inc/teste1.jpg">
<img title="Ct02" alt="Alt text" src="/docs/img/Inc/teste2.jpg">
<img title="Ct03" alt="Alt text" src="/docs/img/Inc/teste3.jpg">

### 2. Consulta por Evento (GET /api/inscricoes/evento/{eventoId})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT04 | Evento com inscrições | eventoId=1 | Lista com 3 inscritos |
| CT05 | Evento sem inscrições | eventoId=99 | Lista vazia |

<img title="Ct04" alt="Alt text" src="/docs/img/Inc/teste4.jpg">
<img title="Ct05" alt="Alt text" src="/docs/img/Inc/teste5.jpg">

### 3. Consulta por Usuário (GET /api/inscricoes/usuario/{usuarioId})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT06 | Usuário com inscrições | usuarioId=201 | Lista com 2 eventos |
| CT07 | Usuário inexistente | usuarioId=999 | Lista vazia |

<img title="Ct06" alt="Alt text" src="/docs/img/Inc/teste6.jpg">
<img title="Ct07" alt="Alt text" src="/docs/img/Inc/teste7.jpg">

### 4. Verificação (GET /api/inscricoes/checar/{eventoId}/{usuarioId})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT08 | Inscrição existente | eventoId=1, usuarioId=201 | true |
| CT09 | Inscrição cancelada | eventoId=3, usuarioId=110 | false |
| CT10 | Inscrição inexistente | eventoId=1, usuarioId=999 | false |

<img title="Ct08" alt="Alt text" src="/docs/img/Inc/teste8.jpg">
<img title="Ct09" alt="Alt text" src="/docs/img/Inc/teste9.jpg">

### 5. Cancelamento (DELETE /api/inscricoes/{id})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT11 | Cancelar inscrição ativa | id=1 | 204 No Content |
| CT12 | Cancelar inscrição inexistente | id=999 | 404 Not Found |

<img title="Ct011" alt="Alt text" src="/docs/img/Inc/teste10.jpg">


---

## Testes de Integração

- Criação de inscrição e posterior verificação de existência
- Cancelamento de inscrição e consulta para validar flag "Ativa"
- Consulta combinada por evento e usuário em fluxo encadeado

---

## Testes de Carga ( / )

### Simulação:
- 1000 usuários simultâneos criando inscrições (POST)
- Consulta em massa de inscritos (GET)
- Alvo: endpoint de inscrição e checagem

### Indicadores:
- Tempo médio de resposta < 200ms
- Erro < 1%
- Throughput mínimo: 200 req/s

---

<img title="Ct013" alt="Alt text" src="/docs/img/Inc/teste11.jpg">

## Testes Unitários com 

- Método `VerificarInscricaoAtiva()`
- Método `CriarInscricao()` com mock de contexto
- Método `CancelarInscricao()` deve setar `Ativa = false`

---

## Conclusão

Este plano de testes cobre todos os requisitos funcionais e não funcionais do microserviço. A combinação de testes unitários, integração, carga e funcionais manuais garantirá confiabilidade, desempenho e consistência da API de Inscrição de Participantes.

--- 

# Plano de Testes - Microserviço de Cadastro de Eventos

## Casos de Teste

### 1. Cadastro (POST /api/Events)

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT01 | Criar Evento válido | Dados do evento | 201 Created |

![Captura de tela 2025-06-14 212338](https://github.com/user-attachments/assets/515f2330-9a0b-4bcd-b69e-66a3ed2feb9d)

### 2. Consulta de evento pelo id (GET /api/Events/{id})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT02 | Listar evento | id = 10 | Exibir evento específico |

![Captura de tela 2025-06-14 211910](https://github.com/user-attachments/assets/08252363-94b1-42d6-9f13-174ebee5de0a)

### 3. Consulta de eventos pelo estado (GET /api/Events/searchByState?query={string})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT03 | Listar eventos | query = SP | Lista com todos os eventos localizados no estado de São Paulo |

![Captura de tela 2025-06-14 211932](https://github.com/user-attachments/assets/13b93f69-8f76-4d79-8ee3-21e60b024462)

### 4. Consulta de eventos pela cidade (GET /api/Events/searchByCity?query={string})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT04 | Listar eventos | query = Belo Horizonte | Lista com todos os eventos localizados em Belo horizonte |

![Captura de tela 2025-06-14 212011](https://github.com/user-attachments/assets/8627ce00-d177-4dab-939f-fab914fb881f)

### 5. Consulta de eventos pelo nome (GET /api/Events/searchByName?query={string})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT05 | Listar eventos | query = Feira | Lista com todos os eventos que tenham parte do nome como feira |

![Captura de tela 2025-06-14 212030](https://github.com/user-attachments/assets/cf630f4c-f513-4e42-9ba3-a6828f578424)

### 6. Consulta de eventos pelo criador (GET /api/Events/searchByCreator?query={string})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT06 | Listar eventos | query = Grupo Astronorte | Lista com todos os eventos que tenham o criador Grupo Astronorte |

![Captura de tela 2025-06-14 212248](https://github.com/user-attachments/assets/ff68f311-b004-4fb4-8575-4750bd721da4)

### 7. Consulta de eventos pela data (GET /api/Events/searchByDate?query={string})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT07 | Listar eventos | query = 2025-08-10 | Lista com todos os eventos que seão realizados em 10/08/2025 |

![Captura de tela 2025-06-14 212301](https://github.com/user-attachments/assets/16298410-7b3f-4edf-871f-af2136f19252)

### 8. Consulta de eventos (GET /api/Events)

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT08 | Listar todos os eventos |  | Lista com todos os eventos |

![Captura de tela 2025-06-14 211840](https://github.com/user-attachments/assets/cd8ed264-9199-458a-b1d9-561797fbbc3c)

### 9. Editar Evento (PUT /api/Event/{id})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT09 | Alterar informações do evento | id=15 | Editar evento com id = 15|

![Captura de tela 2025-06-14 212431](https://github.com/user-attachments/assets/533c8c62-3661-4469-a847-ff49500667d1)

### 10. Excluir evento (DELETE /api/Events/{id})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT10 | Exclusão de evento | id = 20 | status code = 204 evento excluído |

![Captura de tela 2025-06-14 212519](https://github.com/user-attachments/assets/c830ab77-55e3-4273-aefe-89e59ddd31c0)

# Plano de Testes - Microserviço de Notificação de eventos

## Casos de Testes

Fluxo de execução completo

<img title="Ct011" alt="Alt text" src="../src/PrintTesteNotificacao.png">

### 1. Criar token externo (POST /api/OauthTokens)

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT01 | Criar Token externo válido | Dados do terceiro/cliente | 201 Created |

### 2. Fazer login com token externo (POST (bearer) /api/OauthTokens/login)

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT02 | Login para acesso as rotas de notificações | Nome cliente/terceiro e token externo gerado | 200 Ok |

### 3. Criar uma notificação (POST (bearer) /api/Notificacaos)

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT03 | Criação de uma nova notificação | Usuário e data da notificação com seus dados cadastrais | 201 Created |

### 4. Recupera todas/uma as notificações (GET (bearer) /api/Notificacaos/{id}(query /pages={value} /pageSize={value}))

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT04 | Visualização das notificações geradas | Nenhuma/Id de notificação especifico | 200 Ok |

### 5. Deleta o token do terceiro/cliente (DELETE /api/OauthTokens/{id})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT05 | Remoção do token do terceiro/cliente assim não o permitindo mais acesso ao sistema | Identificador para exclusão do terceiro/cliente | 204 No content |

