using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using source.Service.Interfaces;

namespace source.Models
{
    public class SetorAtuacao : IModelBase
    {
        public SetorAtuacao()
        {
            _id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId _id { get; set; }
        public string Descricao { get; set; }
    }
}