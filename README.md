# 🧠 Realtime Chat

## 🎯 Objetivo do Projeto

Projeto criado para estudo e prática, com foco em comunicação em tempo real (SignalR), APIs em .NET e um front-end em Angular.

> ⚠️ Não recomendado para uso em produção sem ajustes de segurança, testes e otimizações.

## 🛠️ Tecnologias

- Back-end: .NET 8+, ASP.NET Core, Entity Framework Core, SignalR
- Banco: PostgreSQL
- Front-end: Angular
- Contêineres: Docker / Docker Compose (opcional)

## Estrutura (resumo)

```
./
├─ Back-end/
│  └─ realtime-chat-api/    # API .NET
└─ front-end/
   └─ realtime-chat/        # Aplicação Angular
```

## ✅ Pré-requisitos

- .NET SDK 8 ou superior (para o back-end)
- Node.js + npm (para o front-end)
- PostgreSQL (ou container)
- Git

---

## Executando localmente (passo a passo)

1) Clonar o repositório

```bash
git clone https://github.com/KatakiCodes/real-time-chat.git
cd real-time-chat
```

2) Back-end (API .NET)

- Vá para a pasta do projeto back-end:

```bash
cd Back-end/realtime-chat-api
```

- Configurar a string de conexão (opções):
  - Crie `appsettings.Development.json` a partir de `appsettings.json` e ajuste `ConnectionStrings:DefaultConnection`, ou
  - Configure as variáveis de ambiente apropriadas para `ConnectionStrings__DefaultConnection`.

- Restaurar dependências e aplicar migrations:

```bash
dotnet restore
dotnet ef database update
```

- Executar a API:

```bash
dotnet run
```

- A API estará disponível em (padrão):

```
https://localhost:5001
http://localhost:5000
```

- Abra o Swagger em `https://localhost:5001/swagger` para inspecionar endpoints.

3) Front-end (Angular)

- Abra um novo terminal e vá para a pasta do front-end:

```bash
cd front-end/realtime-chat
```

- Instale dependências e inicie o servidor de desenvolvimento:

```bash
npm install
npm start
```

- O Angular dev server normalmente roda em `http://localhost:4200`.

- Observação: verifique onde o front-end espera a URL da API (por exemplo em `src/environments/` ou em variáveis de ambiente). Atualize o `apiBaseUrl` ou similar para apontar para `http://localhost:5000` ou `https://localhost:5001` conforme necessário.

---

## Banco de dados (PostgreSQL)

- Se preferir usar Docker Compose para o banco, crie/edite um `docker-compose.yml` com um serviço `db` (Postgres) e ajuste a connection string.

Exemplo rápido com Docker (opcional):

```bash
docker run --name rtc-postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=realtime_chat -p 5432:5432 -d postgres:15
```

Depois atualize `DefaultConnection` para `Host=localhost;Port=5432;Database=realtime_chat;Username=postgres;Password=postgres`.

---

## Observações

- Se tiver problemas com CORS, verifique nas configurações do `realtime-chat-api` (habilitar CORS para `http://localhost:4200`).
- Para executar em HTTPS local, pode ser necessário confiar no certificado de desenvolvimento do .NET.

Se quiser, eu posso:

- adicionar um `docker-compose.yml` que orquestra API + Postgres, ou
- rodar o front-end localmente agora e mostrar passos para inspecionar o layout.
