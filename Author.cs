using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace lingoSimApi
{
    [BsonIgnoreExtraElements]
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("bio")]
        public string? Bio { get; set; }
    }
}