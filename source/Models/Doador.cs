using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace source.Models
{
    public class Doador
    {
        [BsonId]
        public ObjectId Id {get; set;}
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}