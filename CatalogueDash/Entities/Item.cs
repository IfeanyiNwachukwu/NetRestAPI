using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogueDash.Entities
{
    public record Item
    {
        public Guid Id { get; init; }
        [Required(ErrorMessage ="Name is a required field")]
        public string Name { get; init; }
        [Required]
        [Range(1,1000,ErrorMessage ="The price must be between 1 and 1000")]
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}