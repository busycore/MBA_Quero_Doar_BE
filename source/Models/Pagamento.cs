using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using source.Service.Interfaces;

namespace source.Models
{
    public class Pagamento : IModelBase
    {
        public Pagamento()
        {
            _id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId _id { get; set; }
        public decimal Valor { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string CodigoSegurancaCartao { get; set; }
        public string ValidadeCartao { get; set; }
    }
}