using AutoMapper;
using CatalogueDash.Dtos.Readable;
using CatalogueDash.Entities;

namespace CatalogueDash.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Item,ItemDTO>();
        }
    }
}