using System;
using System.Collections.Generic;
using AutoMapper;
using CatalogueDash.Dtos.Readable;
using CatalogueDash.Entities;
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
    }
}