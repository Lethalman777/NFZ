using AutoMapper;
using NFZ.Entities;

namespace NFZ
{
    public class NFZMappingProfile : Profile
    {
        public NFZMappingProfile()
        {
            CreateMap<Product, Product>();
        }
    }
}
