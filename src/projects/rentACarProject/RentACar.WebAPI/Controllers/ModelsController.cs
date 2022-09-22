using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Models.Models;
using RentACar.Application.Features.Models.Queries.GetListModel;
using RentACar.Application.Features.Models.Queries.GetListModelByDynamic;

namespace RentACar.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModelQuery getListModelQuery = new GetListModelQuery() { PageRequest = pageRequest };
        ModelListModel result = await Mediator.Send(getListModelQuery);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, Dynamic dynamic)
    {
        GetListModelByDynamicQuery getListModelQuery = new GetListModelByDynamicQuery()
            { PageRequest = pageRequest, Dynamic = dynamic };
        
        ModelListModel result = await Mediator.Send(getListModelQuery);

        return Ok(result);
    }
}