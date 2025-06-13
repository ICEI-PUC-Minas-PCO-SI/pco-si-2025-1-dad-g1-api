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

### 2. Consulta por Evento (GET /api/inscricoes/evento/{eventoId})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT04 | Evento com inscrições | eventoId=1 | Lista com 3 inscritos |
| CT05 | Evento sem inscrições | eventoId=99 | Lista vazia |

### 3. Consulta por Usuário (GET /api/inscricoes/usuario/{usuarioId})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT06 | Usuário com inscrições | usuarioId=201 | Lista com 2 eventos |
| CT07 | Usuário inexistente | usuarioId=999 | Lista vazia |

### 4. Verificação (GET /api/inscricoes/checar/{eventoId}/{usuarioId})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT08 | Inscrição existente | eventoId=1, usuarioId=201 | true |
| CT09 | Inscrição cancelada | eventoId=3, usuarioId=110 | false |
| CT10 | Inscrição inexistente | eventoId=1, usuarioId=999 | false |

### 5. Cancelamento (DELETE /api/inscricoes/{id})

| ID | Cenário | Entrada | Saída Esperada |
|----|---------|---------|------------------|
| CT11 | Cancelar inscrição ativa | id=1 | 204 No Content |
| CT12 | Cancelar inscrição inexistente | id=999 | 404 Not Found |

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

## Testes Unitários com 

- Método `VerificarInscricaoAtiva()`
- Método `CriarInscricao()` com mock de contexto
- Método `CancelarInscricao()` deve setar `Ativa = false`

---

## Conclusão

Este plano de testes cobre todos os requisitos funcionais e não funcionais do microserviço. A combinação de testes unitários, integração, carga e funcionais manuais garantirá confiabilidade, desempenho e consistência da API de Inscrição de Participantes.

