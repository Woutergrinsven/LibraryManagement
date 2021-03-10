using Bibliotheek.Models.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Bibliotheek.Database
{
    public class MongoBase
    {
        private IMongoDatabase _database = null;

        public MongoBase() { }

        public bool OpenConnection()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                _database = client.GetDatabase("library");

                // TODO: Verify if collections exist?

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Find methods.
        public List<T> GetCollection<T>(string collectionName) where T : DataModelBase
        {
            var collection = _database.GetCollection<T>(collectionName);
            var items = collection.Find(new BsonDocument());
            return items.ToList();
        }

        public List<T> FindMultipleByFilter<T>(string collectionName, FilterDefinition<T> filter)
        {
            var collection = _database.GetCollection<T>(collectionName);
            var items = collection.Find(filter);
            return items.ToList();
        }

        public T FindOneById<T>(string collectionName, ObjectId id) where T : DataModelBase
        {
            var collection = _database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);
            var item = collection.Find(filter).FirstOrDefault();
            return item;
        }

        public T FindOneByFilter<T>(string collectionName, FilterDefinition<T> filter)
        {
            var collection = _database.GetCollection<T>(collectionName);
            var item = collection.Find(filter).FirstOrDefault();
            return item;
        }

        // CRUD methods.
        public void Create<T>(T entity, string collectionName) where T : DataModelBase
        {
            var collection = _database.GetCollection<T>(collectionName);
            collection.InsertOne(entity);
        }

        public void UpdateOne<T>(string collectionName, ObjectId id, UpdateDefinition<T> updateDefinition) where T : DataModelBase
        {
            var collection = _database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);
            collection.UpdateOne(filter, updateDefinition);
        }

        public void DeleteOne<T>(string collectionName, ObjectId id) where T : DataModelBase
        {
            var collection = _database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);
            collection.DeleteOne(filter);
        }
    }
}
