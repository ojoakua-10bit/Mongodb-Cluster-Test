namespace MongoTest.Settings
{
    public interface IAnimalDatabaseSettings
    {
        string AnimalsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}