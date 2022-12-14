using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Features.Models.Models;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Queries.GetListModel;

public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models =
            await _modelRepository.GetListAsync(
                include: m=>m.Include(c=>c.Brand),
                index: request.PageRequest.Page, 
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

        ModelListModel modelListModel = _mapper.Map<ModelListModel>(models);

        return modelListModel;
    }
}