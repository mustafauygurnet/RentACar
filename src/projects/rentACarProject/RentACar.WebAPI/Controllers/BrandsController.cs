using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Brands.Commands;
using RentACar.Application.Features.Brands.Dtos;

namespace RentACar.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpPost]
    public async  Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        CreatedBrandDto result = await Mediator.Send(createBrandCommand);

        //Http Code 201
        return Created("",result);
    }
}