using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using source.Service.Interfaces;
using System;

namespace source.Models
{
    public class MeusCupons : IModelBase
    {
        public MeusCupons()
        {
            _id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId _id {get; set;}
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Empresa EmpresaParceria { get; set; }
        public Doador Doador { get; set; }
        public Cupom Cupom { get; set; }
        //public int Nivel { get; set; } ???? 
        public DateTime DataValidade { get; set; }
        public DateTime DataResgate { get; set; }
        public bool Ativo { get; set; }

    }
}