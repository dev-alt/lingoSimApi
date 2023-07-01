using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lingoSimApi;


[BsonIgnoreExtraElements]
public class Quote
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("language")]
    public string? Language { get; set; }

    [BsonElement("originalQuote")]
    public string? OriginalQuote { get; set; }

    [BsonElement("translation")]
    public string? Translation { get; set; }

    [BsonElement("author")]
    public string? Author { get; set; }

    [BsonElement("tags")]
    public string? Tags { get; set; }

    [BsonElement("audioUrl")]
    public string? AudioUrl { get; set; }

    [BsonElement("audioSpeedControl")]
    public bool AudioSpeedControl { get; set; }

    [BsonElement("pronunciationGuide")]
    public string? PronunciationGuide { get; set; }

    [BsonElement("culturalContext")]
    public string? CulturalContext { get; set; }

    [BsonElement("meaning")]
    public string? Meaning { get; set; }

    [BsonElement("examples")]
    public string? Examples { get; set; }

    [BsonElement("usages")]
    public string? Usages { get; set; }

    [BsonElement("rating")]
    public double Rating { get; set; }

    [BsonElement("favorites")]
    public int Favorites { get; set; }

    [BsonElement("socialShares")]
    public int SocialShares { get; set; }

}