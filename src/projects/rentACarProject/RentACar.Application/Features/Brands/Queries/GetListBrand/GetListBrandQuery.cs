using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using RentACar.Application.Features.Brands.Models;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Queries.GetListBrand;

public class GetListBrandQuery : IRequest<BrandListModel>
{
    public PageRequest PageRequest { get; set; }
}

public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetListBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }

    public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page,
            size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

        BrandListModel mappedBrandList = _mapper.Map<BrandListModel>(brands);

        return mappedBrandList;
    }
}