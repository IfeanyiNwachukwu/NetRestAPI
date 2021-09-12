using System;
using System.Collections.Generic;
using CatalogueDash.Entities;
using MongoDB.Driver;

namespace CatalogueDash.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private const string databaseName = "DashCatalogue";
        private const string collectionName = "items";

        private readonly IMongoCollection<Item> itemsCollection;
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            //Gets the database but if the database does not exist, it creates it
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);

        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();

           
        }
    }
}