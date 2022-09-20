using AutoMapper;
using MediatR;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Queries.GetByIdBrand;

public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetByIdBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }

    public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
    {
        Brand? brand = await _brandRepository.GetAsync(b=>b.Id == request.Id);

        BrandGetByIdDto brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(brand);

        return brandGetByIdDto;
    }
}