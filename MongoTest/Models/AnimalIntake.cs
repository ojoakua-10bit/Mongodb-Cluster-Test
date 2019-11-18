using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoTest.Models
{
    public class AnimalIntake
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
 
        [BsonElement("shelter")]
        public string Shelter { get; set; }
        
        [BsonElement("animal_id")]
        public string AnimalId { get; set; }
        
        [BsonElement("intake_date")]
        public string IntakeDate { get ; set; }
        
        [BsonElement("intake_type")]
        public string IntakeType { get; set; }
        
        [BsonElement("intake_condition")]
        public string IntakeCondition { get; set; }
        
        [BsonElement("animal_type")]
        public string AnimalType { get; set; }
        
        [BsonElement("group")]
        public string Group { get; set; }
        
        [BsonElement("breed_1")]
        public string Breed1 { get; set; }
        
        [BsonElement("breed_2")]
        public string Breed2 { get; set; }
    }
}