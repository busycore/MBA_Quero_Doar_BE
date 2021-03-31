using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace source.Models
{
    public class Cupom
    {
        [BsonId]
        public ObjectId Id {get; set;}
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Empresa Parceria { get; set; }
        public int Nivel { get; set; }
        public string Descricao { get; set; }
        public string CodigoCupom { get; set; }
        public bool CupomUtilizado { get; set; }
        public DateTime DataAquisicao { get; set; }
        public DateTime? DataUtilizacao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}