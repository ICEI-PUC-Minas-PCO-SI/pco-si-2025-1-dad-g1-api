# 🚀 Usuario Service API

## 💡 Sobre o Projeto

Este é um serviço RESTful para **gestão de usuários**, fundamental para um sistema de gestão de eventos. Ele permite o **cadastro, consulta, atualização e exclusão de usuários**, e o mais importante, gerencia a **segregação de perfis** (como Criadores de Eventos e Participantes) e a **autenticação segura via JWT** (JSON Web Tokens).

---

## 💻 Tecnologias Utilizadas

* **.NET 8.0**
* **ASP.NET Core Web API**
* **Entity Framework Core** (com SQL Server)
* **AutoMapper**
* **BCrypt.Net-Next** (para hashing de senhas)
* **JSON Web Tokens (JWT)** para autenticação
* **Swagger/OpenAPI** para documentação da API

---

## 🌐 Endpoints da API

| Método | Endpoint                    | Descrição                                                               |
| :----- | :-------------------------- | :---------------------------------------------------------------------- |
| `POST` | `/api/Users`                | Cria um novo usuário (com `nome`, `email`, `senha`, `papel`). |
| `GET`  | `/api/Users`                | Lista todos os usuários.                                                |
| `GET`  | `/api/Users/{id}`           | Retorna os detalhes de um usuário específico por ID.                    |
| `PUT`  | `/api/Users/{id}`           | Atualiza um usuário existente por ID.                                   |
| `DELETE`| `/api/Users/{id}`           | Exclui um usuário por ID.                                               |
| `POST` | `/api/Users/authenticate`   | Autentica um usuário (com `email`, `senha`) e retorna um **JWT**. |

Os papeis de usuário são definidas como `Participante` (0), `Criador` (1) e `Admin` (2), e são incluídas no JWT.