using MediatR;
using RentACar.Application.Features.Brands.Dtos;

namespace RentACar.Application.Features.Brands.Queries.GetByIdBrand;

public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
{
    public int Id { get; set; }
}