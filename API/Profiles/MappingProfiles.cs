using API.Dtos;
using AutoMapper;
using Domain.Entities;
namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        
        CreateMap<Producto, ProductoDto>().ReverseMap();
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
        CreateMap<Factura, FacturaDto>().ReverseMap();
    }
}
