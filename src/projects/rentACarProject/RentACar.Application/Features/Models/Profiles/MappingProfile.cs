using AutoMapper;
using Core.Persistence.Paging;
using RentACar.Application.Features.Models.Dtos;
using RentACar.Application.Features.Models.Models;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
        CreateMap<Model, ModelListDto>()
            .ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();
    }
}