using AutoMapper;
using PaymentGateway.Data.Dtos;
using PaymentGateway.Data.Entities;


namespace PaymentGateway.Mapper.Mappers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductsDto, Products>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow)).ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<Products, AddProductsDto>();
            CreateMap<Products, ProductResponse>()
          .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}
