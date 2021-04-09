using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace source.Service.Interfaces
{
    public interface IModelBase
    {
        [BsonId]
        public ObjectId _id { get; set; }
    }
}