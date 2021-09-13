using System;
using System.Collections.Generic;
using CatalogueDash.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CatalogueDash.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private const string databaseName = "DashCatalogue";
        private const string collectionName = "items";

        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
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
            var filter = filterBuilder.Eq(item => item.Id,id);
            itemsCollection.DeleteOne(filter);
        }

        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id,id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();
        }   

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id,item.Id);
            itemsCollection.ReplaceOne(filter,item);
           
        }
    }
}