using System;

namespace CatalogueDash.Dtos.Readable
{
    public record ItemDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}