# 📚 Projeto de Persistência com MongoDB - .NET

Este projeto demonstra como realizar **operações de CRUD** (Create, Read, Update e Delete) utilizando o **MongoDB** em uma aplicação **.NET 8**.  

## 🚀 Tecnologias Utilizadas
- [.NET](https://dotnet.microsoft.com/) (8 ou superior)
- [MongoDB](https://www.mongodb.com/) (Banco NoSQL)
- [MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/) (Driver oficial C#)
- [MongoDB Compass](https://www.mongodb.com/products/compass) (Interface gráfica para visualizar os dados)

## 📂 Estrutura do Projeto
```
├── Models
│   └── Aluno.cs        # Classe de modelo mapeada para o MongoDB
├── Services
    └── Interfaces
    |   └── IAlunoService.cs # Interface de persistência (CRUD)
    │
    └── AlunoService.cs # Lógica de persistência (CRUD)
├── Controllers
│   └── AlunoController.cs # Endpoints da API
├── appsettings.json    # Configurações de conexão com MongoDB
└── Program.cs          # Configuração da aplicação
```

## 🗂️ Classe Aluno (Exemplo)

```csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PeristenciaNoSql.Models
{
    public class Aluno
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("email")]
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [BsonElement("senha")]
        public string Senha { get; set; }

        [BsonElement("codigoPessoa")]
        public string? CodigoPessoa { get; set; }

        [BsonElement("lembreteSenha")]
        public string? LembreteSenha { get; set; }

        [BsonElement("idade")]
        public int Idade { get; set; }

        [BsonElement("sexo")]
        public string? Sexo { get; set; }
    }
}
```

## ⚙️ Configuração do `appsettings.json`

```json
"AlunoDatabase": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "EscolaDb",
  "AlunosCollectionName": "Alunos"
}
```

## ▶️ Executando o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```

2. Instale as dependências:
   ```bash
   dotnet restore
   ```

3. Configure o `appsettings.json` com sua conexão do MongoDB.

4. Execute a aplicação:
   ```bash
   dotnet run
   ```

5. Acesse a API em:
   ```
   https://localhost:5001/swagger
   ```

## 📖 Endpoints (Exemplo)

- `GET /api/aluno` → Lista todos os alunos  
- `GET /api/aluno/{id}` → Busca um aluno por ID  
- `POST /api/aluno` → Adiciona um novo aluno  
- `PUT /api/aluno/{id}` → Atualiza um aluno  
- `DELETE /api/aluno/{id}` → Remove um aluno  

## 🛠️ Ferramentas de Apoio
- **MongoDB Compass** para visualizar os documentos.
- **Swagger** para testar os endpoints.

---

✍️ Projeto desenvolvido como prática de **Persistência NoSQL com MongoDB em .NET**.
