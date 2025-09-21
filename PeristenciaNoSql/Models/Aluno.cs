using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PeristenciaNoSql.Models
{
    public class Aluno
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string? Nome { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("senha")]
        public string? Senha { get; set; }

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