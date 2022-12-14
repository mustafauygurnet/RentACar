using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Rules;

public class BrandBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCanNotBeDuplicatedWhenInserted(string brandName)
    {
        IPaginate<Brand> result = await _brandRepository.GetListAsync(b=>b.Name == brandName);
        if (result.Items.Any())
            throw new BusinessException("Brand Name Exists");

    }
}