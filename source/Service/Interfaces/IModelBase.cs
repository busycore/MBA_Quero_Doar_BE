using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Service.Interfaces
{
    public interface IModelBase
    {
        [BsonId]
        public ObjectId _id { get; set; }
    }
}