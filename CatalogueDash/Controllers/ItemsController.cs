using System;
using System.Collections.Generic;
using AutoMapper;
using CatalogueDash.Dtos.Readable;
using CatalogueDash.Dtos.Writable;
using CatalogueDash.Entities;
using CatalogueDash.Extensions.EntityExtensions;
using CatalogueDash.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueDash.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _repository;
        private readonly IMapper _mapper;

        public ItemsController(IItemsRepository repository,IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public ActionResult<ItemDTO> GetItems()
        {
            var items = _repository.GetItems();
            var itemsToReturn = _mapper.Map<IEnumerable<ItemDTO>>(items);
            return Ok(itemsToReturn);
        }
        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
             var itemToReturn = _mapper.Map<ItemDTO>(item);
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<ItemDTO> CreateItem(ItemDTOW model)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            _repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id},item.AsDto());

         }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, ItemDTOW model)
         {
             var existingItem = _repository.GetItem(id);
             if(existingItem is null)
             {
                 return NotFound();
             }
             // copying existingItem into updatedItem with updated values
             var updatedItem = existingItem with 
             {
                 Name = model.Name,
                 Price = model.Price
             };
             _repository.UpdateItem(updatedItem);
             return NoContent();
         }

         [HttpDelete("{id}")]
         public ActionResult DeleteItem(Guid id)
         {
              var existingItem = _repository.GetItem(id);
             if(existingItem is null)
             {
                 return NotFound();
             }
             _repository.DeleteItem(id);
             return NoContent();
         }
    }
}