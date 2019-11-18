using MongoDB.Bson.Serialization.Attributes;

namespace MongoTest.Models
{
    public class CountObject
    {
        [BsonId]
        public string Id;

        [BsonElement("count")]
        public int Count;
    }
}