# 🧠 Realtime Chat API

## 🎯 Objetivo do Projeto

Este projeto foi criado **exclusivamente para fins de estudo e prática**, com foco em:

- Consolidação de conceitos de desenvolvimento backend
- Implementação de comunicação em **tempo real**
- Aplicação de boas práticas de arquitetura e organização de código
- Uso de containers Docker para padronizar ambientes
- Criação de um projeto sólido para **portfólio profissional**

> ⚠️ Este projeto **não é recomendado para uso em produção** sem ajustes adicionais de segurança, testes automatizados e otimizações.

---

## 🛠️ Tecnologias Utilizadas

- **.NET 8 / 9**
- **ASP.NET Core Web API**
- **WebSockets / SignalR** (comunicação em tempo real)
- **Entity Framework Core**
- **PostgreSQL**
- **Docker**
- **Docker Compose**
- **Swagger / OpenAPI**
- **C#**

---

## 🧩 Padrões de Desenvolvimento e Boas Práticas

- Separação de responsabilidades (SRP)
- Uso de **Dependency Injection**
- Configuração via **Environment Variables**
- Migrations com **Entity Framework Core**
- Containers para padronização do ambiente

---

## 📁 Estrutura do Projeto (Resumo)

```text
realtime-chat-api/
├── Controllers
├── Services
├── Domain
├── Infrastructure
├── Migrations
├── Program.cs
├── Dockerfile
├── docker-compose.yml
└── appsettings.json

```
🚀 Executando o Projeto Localmente

##✅ Pré-requisitos

- .NET SDK 8 ou superior

- PostgreSQL

- Docker (opcional)

- Git

```
git clone https://github.com/KatakiCodes/real-time-chat.git
cd real-time-chat/realtime-chat-api
```

## Configurar Variáveis de Ambiente

* Crie o arquivo appsettings.Development.json ou configure via variáveis de ambiente:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=realtime_chat;Username=postgres;Password=postgres"
  }
}

```

* Restaurar dependências:

```
dotnet restore
```

* Executar as migrações:

```
dotnet ef database update
```
* Executar a aplicação:

```
dotnet run
```

* A API estará disponível em:

➡️ https://localhost:5001

➡️ http://localhost:5000

Swagger:

➡️ https://localhost:5001/swagger
