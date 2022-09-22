using Core.Application.Requests;
using MediatR;
using RentACar.Application.Features.Models.Models;

namespace RentACar.Application.Features.Models.Queries.GetListModel;

public class GetListModelQuery : IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
}