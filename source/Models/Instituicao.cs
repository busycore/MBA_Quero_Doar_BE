using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using source.Service.Interfaces;

namespace source.Models
{
    public class Instituicao : IModelBase
    {
        public Instituicao()
        {
            _id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId _id { get; set;}
        public string Nome { get; set; }
        public SetorAtuacao SetorAtuacao { get; set; }
        public string CNPJ { get; set; }
        public string Site { get; set; }
        public string PessoaContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}