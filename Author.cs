using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace lingoSimApi
{
    internal class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? name { get; set; }

        [BsonElement("bio")]
        public string? bio { get; set; }
    }
}