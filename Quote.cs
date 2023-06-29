using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lingoSimApi;


[BsonIgnoreExtraElements]
public class Quote
{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("text")]
        public string? Text { get; set; }

        [BsonElement("meaning")]
        public string? Meaning { get; set; }

        [BsonElement("explanation")]
        public string? Explanation { get; set; }

        [BsonElement("language")]
        public string? Language { get; set; }

}