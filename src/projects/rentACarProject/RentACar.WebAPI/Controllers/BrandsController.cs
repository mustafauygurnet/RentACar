using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Brands.Commands.CreateBrand;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Application.Features.Brands.Models;
using RentACar.Application.Features.Brands.Queries.GetByIdBrand;
using RentACar.Application.Features.Brands.Queries.GetListBrand;

namespace RentACar.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        CreatedBrandDto result = await Mediator.Send(createBrandCommand);

        //Http Code 201
        return Created("",result);
    }
    
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new GetListBrandQuery {PageRequest = pageRequest};

        BrandListModel result = await Mediator.Send(getListBrandQuery);

        return Ok(result);
    }
    
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery)
    {
        BrandGetByIdDto result = await Mediator.Send(getByIdBrandQuery);

        //Http Code 200
        return Ok(result);
    }
}