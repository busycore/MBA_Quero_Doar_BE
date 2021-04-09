using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using source.Service.Interfaces;
using System;

namespace source.Models
{
    public class Cupom : IModelBase
    {
        public Cupom()
        {
            _id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId _id {get; set;}
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Empresa EmpresaParceria { get; set; }
        public int Nivel { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public bool Ativo { get; set; }

    }
}