using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace lingoSimApi
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("name")] public string Name { get; set; } = null!;

        [BsonElement("biography")] public string Biography { get; set; } = null!;

        [BsonElement("life_events")] public List<LifeEvent?>? LifeEvents { get; set; }

        [BsonElement("philosophy")] public List<PhilosophyConcept?>? Philosophy { get; set; }

        [BsonElement("books")] public List<Book>? Books { get; set; }

        [BsonElement("cultural_impacts")] public List<CulturalImpact?>? CulturalImpacts { get; set; }

        [BsonElement("relevance_today")] public List<RelevanceToday>? RelevanceToday { get; set; }

        [BsonElement("resources")] public List<string>? Resources { get; set; }

        [BsonElement("birth_date")] public DateTime? BirthDate { get; set; }

        [BsonElement("death_date")] public DateTime? DeathDate { get; set; }

        [BsonElement("nationality")] public string? Nationality { get; set; }
    }

    public class LifeEvent
    {
        [BsonElement("title")] public string? Title { get; set; }

        [BsonElement("description")] public string? Description { get; set; }

        [BsonElement("date")] public DateTime? Date { get; set; }
    }

    public class PhilosophyConcept
    {
        [BsonElement("title")] public string? Title { get; set; }

        [BsonElement("description")] public string? Description { get; set; }
    }

    public class Book
    {
        [BsonElement("title")] public string? Title { get; set; }

        [BsonElement("description")] public string? Description { get; set; }

        [BsonElement("publication_date")] public DateTime? PublicationDate { get; set; }
    }

    public class CulturalImpact
    {
        [BsonElement("title")] public string? Title { get; set; }

        [BsonElement("description")] public string? Description { get; set; }
    }

    public class RelevanceToday
    {
        [BsonElement("title")] public string? Title { get; set; }

        [BsonElement("description")] public string? Description { get; set; }
    }
}