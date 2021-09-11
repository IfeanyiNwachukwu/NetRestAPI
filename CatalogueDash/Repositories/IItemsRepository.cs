using System;
using System.Collections.Generic;
using CatalogueDash.Entities;

namespace CatalogueDash.Repositories
 {
     public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
 }
 