using MediatR;
using RentACar.Application.Features.Brands.Dtos;

namespace RentACar.Application.Features.Brands.Commands;

public class CreateBrandCommand : IRequest<CreatedBrandDto>
{
    public string Name { get; set; }
}