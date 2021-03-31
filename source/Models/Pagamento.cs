using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace source.Models
{
    public class Pagamento
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public decimal Valor { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string CodigoSegurancaCartao { get; set; }
        public string ValidadeCartao { get; set; }
    }
}