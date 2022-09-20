using AutoMapper;
using Core.Persistence.Paging;
using RentACar.Application.Features.Brands.Commands.CreateBrand;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Application.Features.Brands.Models;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Brand,CreatedBrandDto>().ReverseMap();
        CreateMap<Brand,CreateBrandCommand>().ReverseMap();

        CreateMap<Brand, BrandGetByIdDto>().ReverseMap();

        CreateMap<Brand,BrandListDto>().ReverseMap();
        CreateMap<IPaginate<Brand>,BrandListModel>().ReverseMap();
        
    }
}