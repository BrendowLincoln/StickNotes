# 📌 Sticky Notes — CRUD Simples com Blazor

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-blue)
![MudBlazor](https://img.shields.io/badge/MudBlazor-UI-purple)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-ORM-green)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-14-336791)
![Docker](https://img.shields.io/badge/Docker-Containerized-2496ED)

Aplicação web desenvolvida em **.NET (Blazor)** com **MudBlazor** e banco de dados **PostgreSQL**, com objetivo de demonstrar:

- Estrutura modular simples
- CRUD completo
- Uso do Entity Framework Core
- Integração com Docker para o banco

---

## 🧱 Tecnologias utilizadas

| Tecnologia | Função |
|-----------|--------|
| .NET 8 | Backend + Blazor |
| MudBlazor | Componentes UI |
| Entity Framework Core | ORM |
| PostgreSQL 14 | Banco de dados |
| Docker | Subida do banco |

---

## 📂 Estrutura do projeto

```
Modules/
 └── Notes/
     ├── Components/
     ├── Entities/
     ├── Repositories/
     ├── Services/
     ├── Pages/

Shared/
 └── Infrastructure/
     ├── Maps/
     └── AppDbContext.cs
```

---

## 🚀 Como rodar o projeto

### 1️⃣ Subir o banco de dados

Na raiz do projeto, execute:

```bash
docker compose up -d
```

Isso criará um container PostgreSQL com:

| Configuração | Valor |
|--------------|-------|
| Host | localhost |
| Porta | **5434** |
| Banco | sticky_notes_db |
| Usuário | sticknotes |
| Senha | sticknotes1234 |

---

### 2️⃣ Restaurar pacotes

```bash
dotnet restore
```

---

### 3️⃣ Criar o banco (migrations)

```bash
dotnet ef database update
```

---

### 4️⃣ Rodar a aplicação

```bash
dotnet run
```

Acesse:

```
https://localhost:7005/notes
```

---

## 🔗 Connection String

Arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "Default": "Host=localhost;Port=5434;Database=sticky_notes_db;Username=sticknotes;Password=sticknotes1234;"
}
```

---

## 📝 Funcionalidades

✔ Criar notas  
✔ Editar notas  
✔ Excluir notas  
✔ Fixar (pin) notas  
✔ Ordenação automática  
✔ Busca por título

---

## 🎨 Tema

O projeto utiliza **MudBlazor Dark Theme** customizado.

---

## 🧪 Resetar banco (caso necessário)

```bash
docker compose down -v
docker compose up -d
```

---

## 🛠 Comandos úteis

| Comando | Descrição |
|--------|-----------|
| `dotnet build` | Compila o projeto |
| `dotnet run` | Executa o projeto |
| `dotnet ef migrations add Nome` | Cria migration |
| `dotnet ef database update` | Atualiza banco |

---

## 👨‍💻 Autor

Projeto para fins de estudo e prática de arquitetura e CRUD com Blazor.
