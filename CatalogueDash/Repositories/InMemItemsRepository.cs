using System;
using System.Collections.Generic;
using System.Linq;
using CatalogueDash.Entities;

namespace CatalogueDash.Repositories
{
   

    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id.Equals(id)).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id.Equals(item.Id));
            items[index] = item;
        }

      

        public void DeleteItem(Guid id)
        {
           var index = items.FindIndex(existingItem => existingItem.Id.Equals(id));
           items.RemoveAt(index);
        }
    }
}