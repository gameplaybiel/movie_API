# Movie_API

Uma API RESTful Uma API RESTful para o gerenciamento de filmes, com funcionalidades de autenticação de usuários utilizando JWT e operações CRUD para a entidade Movie.

## Tecnologias Usadas:
* .Net 8 (C#)
* Entity Framework Core
* JWT (Json Web Token)
* SQL Server

## Funcionalidades do projeto:

## 1. Autenticação com JWT:
* POST /api/Auth/login

## 2. Operações CRUD de User:
* GET /api/User
* POST /api/User
* GET /api/User/{id}
* PUT /api/User/{id}
* DELETE api/User/{id}

## 3. Operações CRUD de Filmes:
* GET /api/Movies
* GET /api/Movies/{id}
* POST /api/Movies
* PUT /api/Movies/{id}
* DELETE /api/Movies/{id}

## 1. Como rodar o projeto
```bash
git clone https://github.com/gameplaybiel/movie_API.git
```

## 2. Instale as dependências
```bash
dotnet restore
```

## 3. Execute as migrações
```bash
dotnet ef dabase update
```

## 4. Execute o projeto
```bash
dotnet run
```

- A API estará disponível em: http://localhost:5093/swagger/index.html

