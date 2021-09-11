using System.Collections.Generic;
using CatalogueDash.Dtos.Readable;
using CatalogueDash.Entities;

namespace CatalogueDash.Extensions.EntityExtensions
{
    public static class ModelExtension
    {
         public static ItemDTO AsDto(this Item item)
        {
            return new ItemDTO
            {
               Id = item.Id,
               Name = item.Name,
               Price = item.Price,
               CreatedDate = item.CreatedDate

            };
        }
    }
}