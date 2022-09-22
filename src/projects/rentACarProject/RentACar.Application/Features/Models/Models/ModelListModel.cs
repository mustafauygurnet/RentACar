using Core.Persistence.Paging;
using RentACar.Application.Features.Models.Dtos;

namespace RentACar.Application.Features.Models.Models;

public class ModelListModel : BasePageableModel
{
    public IList<ModelListDto> Items { get; set; }
}