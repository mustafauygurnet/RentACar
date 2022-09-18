using AutoMapper;
using RentACar.Application.Features.Brands.Commands;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Brand,CreatedBrandDto>().ReverseMap();
        CreateMap<Brand,CreateBrandCommand>().ReverseMap();
    }
}