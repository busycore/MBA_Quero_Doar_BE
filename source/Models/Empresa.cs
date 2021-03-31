using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace source.Models
{
    public class Empresa
    {
        [BsonId]
        public ObjectId Id {get; set;}
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Site { get; set; }
        public string PessoaContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}