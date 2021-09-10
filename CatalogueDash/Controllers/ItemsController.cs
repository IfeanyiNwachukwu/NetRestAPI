using System.Collections.Generic;
using CatalogueDash.Entities;
using CatalogueDash.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueDash.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repository;

        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }
    }
}