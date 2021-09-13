using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<ItemDTO>> GetItemsAsync()
        {
            var items = await _repository.GetItemsAsync();
            var itemsToReturn = _mapper.Map<IEnumerable<ItemDTO>>(items);
            return Ok(itemsToReturn);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);
            if(item is null)
            {
                return NotFound();
            }
             var itemToReturn = _mapper.Map<ItemDTO>(item);
            return Ok(item);
        }

        [HttpPost]
        public async  Task<ActionResult<ItemDTO>> CreateItemAsync(ItemDTOW model)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await _repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id},item.AsDto());

         }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, ItemDTOW model)
         {
             var existingItem = await _repository.GetItemAsync(id);
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
             await _repository.UpdateItemAsync(updatedItem);
             return NoContent();
         }

         [HttpDelete("{id}")]
         public async Task<ActionResult> DeleteItemAsync(Guid id)
         {
              var existingItem = await _repository.GetItemAsync(id);
             if(existingItem is null)
             {
                 return NotFound();
             }
             await _repository.DeleteItemAsync(id);
             return NoContent();
         }
    }
}