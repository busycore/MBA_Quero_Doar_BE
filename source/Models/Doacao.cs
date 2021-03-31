using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace source.Models
{
    public class Doacao
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public Doador Doador { get; set; }
        public Instituicao Instituicao { get; set; }
        public IEnumerable<Cupom> Cupons { get; set; }
        public DateTime DataDoacao { get; set; }
        public Pagamento Pagamento { get; set; }
        public decimal ValorInstituicao { get; set; }
    }
}