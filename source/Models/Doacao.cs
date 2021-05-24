using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace source.Models
{
    public class Doacao : IModelBase
    {
        public Doacao()
        {
            _id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId _id { get; set; }

        public Doador Doador { get; set; }
        public Instituicao Instituicao { get; set; }
        public IEnumerable<Cupom> Cupom { get; set; } = Array.Empty<Cupom>();
        public DateTime DataDoacao { get; set; }
        public Pagamento Pagamento { get; set; }
        public decimal ValorInstituicao { get; set; }
    }
}