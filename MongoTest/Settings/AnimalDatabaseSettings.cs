namespace MongoTest.Settings
{
    public class AnimalDatabaseSettings : IAnimalDatabaseSettings
    {
        public string AnimalsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}