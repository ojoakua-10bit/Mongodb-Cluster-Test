using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoTest.Models;
using MongoTest.Settings;

namespace MongoTest.Services
{
    public class AnimalIntakeService
    {
        private readonly IMongoCollection<AnimalIntake> animalIntake;

        public AnimalIntakeService(IAnimalDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase db = client.GetDatabase(settings.DatabaseName);
            animalIntake = db.GetCollection<AnimalIntake>(settings.AnimalsCollectionName);
        }

        public List<AnimalIntake> Get() =>
            animalIntake.Find(data => true).Limit(100).ToList();

        public AnimalIntake Get(string id) =>
            animalIntake.Find(data => data.Id == id).FirstOrDefault();

        public AnimalIntake AddData(AnimalIntake data)
        {
            animalIntake.InsertOne(data);
            return data;
        }

        public AnimalIntake ChangeData(string id, AnimalIntake newData)
        {
            newData.Id = id;
            animalIntake.ReplaceOne(data => data.Id == id, newData);
            return newData;
        }

        public void Remove(string id) =>
            animalIntake.DeleteOne(data => data.Id == id);

        public List<CountObject> GetCountByAnimal()
        {
            List<CountObject> data = new List<CountObject>();
            List<BsonDocument> temp = animalIntake.Aggregate().Group(new BsonDocument
                {{"_id", "$animal_type"}, {"count", new BsonDocument("$sum", 1)}}).ToList();
            
            foreach (var x in temp)
                data.Add(BsonSerializer.Deserialize<CountObject>(x));

            return data;
        }

        public List<CountObject> GetCountByShelter()
        {
            List<CountObject> data = new List<CountObject>();
            List<BsonDocument> temp = animalIntake.Aggregate().Group(new BsonDocument
                {{"_id", "$shelter"}, {"count", new BsonDocument("$sum", 1)}}).ToList();
            
            foreach (var x in temp)
                data.Add(BsonSerializer.Deserialize<CountObject>(x));

            return data;
        }
        
        public List<CountObject> GetCountByCondition()
        {
            List<CountObject> data = new List<CountObject>();
            List<BsonDocument> temp = animalIntake.Aggregate().Group(new BsonDocument
                {{"_id", "$intake_condition"}, {"count", new BsonDocument("$sum", 1)}}).ToList();
            
            foreach (var x in temp)
                data.Add(BsonSerializer.Deserialize<CountObject>(x));

            return data;
        }
    }
}