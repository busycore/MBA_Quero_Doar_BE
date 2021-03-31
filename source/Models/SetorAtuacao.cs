using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace source.Models
{
    public class SetorAtuacao
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Descricao { get; set; }
    }
}